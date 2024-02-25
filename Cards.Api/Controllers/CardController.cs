
using Cards.Application;
using Cards.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CardsWeb.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CardController : Controller
    {
        private readonly CardService _cardService;
        public async Task<IActionResult> GetById()
        {
            return Ok();
        }

        [HttpPost]
        public async Task<IActionResult> AddCard(Card card)
        {
            try
            {
                return Ok(await _cardService.AddCard(card));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpPut]
        public async Task<IActionResult> UpdateCard(Card card)
        {
            try
            {
                return Ok(await _cardService.UpdateCard(card));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpDelete]
        [Route("{itemId}")]
        public async Task<IActionResult> DeleteAuction([FromRoute] Guid cardId)
        {
            try
            {
                await _cardService.DeleteCard(cardId);
                return Ok();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return Conflict(e.Message);
            }
        }

    }

}
