using CardsWeb.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CardsWeb.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CardController : Controller
    {
        public async Task<IActionResult> GetById()
        {
            return Ok(new Card());
        }
    }
}
