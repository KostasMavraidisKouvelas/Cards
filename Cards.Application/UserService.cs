using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Cards.DataAccess;
using Cards.Models;
using Cards.Models.Dto;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Identity.Client;
using Microsoft.IdentityModel.Tokens;

namespace Cards.Application
{
    public class UserService : BaseService
    {
        private readonly UserManager<User> _usersManager;
        private readonly SignInManager<User> _signInManager;
        private readonly IConfiguration _configuration;

        public UserService(CardsDbContext context, UserManager<User> userManager,
            IConfiguration configuration) : base(context)
        {
            _usersManager = userManager;
            _configuration = configuration;
        }

        public async Task<string> Login(UserLoginDto user)
        {
            var existingUser = await _usersManager.FindByEmailAsync(user.UserName);

            if (existingUser == null)
            {
                throw new Exception("Invalid username or password.");
            }

            var result = await _signInManager.PasswordSignInAsync(existingUser, user.Password, false, lockoutOnFailure: false);

            if (!result.Succeeded)
            {
                throw new Exception("Invalid username or password.");
            }

            var secret = _configuration["JWTConfig:Secret"];
            var claims = await _usersManager.GetClaimsAsync(existingUser);
            var jwtToken = GenerateJwtToken(existingUser, secret, claims);

            return jwtToken;
        }

        private static string GenerateJwtToken(User user, string secret,IList<Claim> claims)
        {
            var jwtTokenHandler = new JwtSecurityTokenHandler();


            claims.Add(new Claim("id", user.Id.ToString()));
            var key = Encoding.ASCII.GetBytes(secret);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key),
                    SecurityAlgorithms.HmacSha256Signature)
            };

            var token = jwtTokenHandler.CreateToken(tokenDescriptor);
            var jwtToken = jwtTokenHandler.WriteToken(token);

            return jwtToken;
        }
    }
}
