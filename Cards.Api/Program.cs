using System.Text;
using Cards.Api;
using Cards.Application;
using Cards.Models;
using Cards.DataAccess;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
ConfigurationManager configuration = builder.Configuration;
builder.Services.Configure<JwtConfig>(configuration.GetSection("JWTConfig"));
builder.Services.AddScoped<CardService, CardService>();
builder.Services.AddScoped<UserService, UserService>();
builder.Services.AddSingleton<IConfiguration>(provider => configuration);

var connection = builder.Configuration                //#C
    .GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<CardsDbContext>(
    options => options.UseSqlServer(connection, b => b.MigrationsAssembly("Cards.DataAccess"))); //#D

builder.Services.AddCors(options =>
{
    options.AddPolicy(name: "default",
        policy =>
        {
            policy.WithOrigins("http://localhost:8080")
                .AllowAnyHeader().
                AllowAnyMethod()
                ;
        });
});

var key = configuration["JWTConfig:Secret"];
builder.Services.AddAuthentication(options =>
    {
        options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
        options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
        options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
    })
    .AddJwtBearer(jwt =>
    {
        var key = Encoding.ASCII.GetBytes(configuration["JWTConfig:Secret"]);
        jwt.SaveToken = true;
        jwt.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuerSigningKey = true,
            IssuerSigningKey = new SymmetricSecurityKey(key),
            ValidateAudience = false,
            ValidateIssuer = false,
            ValidateLifetime = true,
            RequireExpirationTime = false
        };
    });

builder.Services.AddIdentityCore<User>(options =>
    {
        //Disable account confirmation.
        options.SignIn.RequireConfirmedAccount = true;
        options.Password.RequireNonAlphanumeric = false;
        //options.SignIn.RequireConfirmedEmail = false;
        //options.SignIn.RequireConfirmedPhoneNumber = false;
    })
    .AddEntityFrameworkStores<CardsDbContext>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
