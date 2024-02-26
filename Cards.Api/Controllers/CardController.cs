﻿
using Cards.Application;
using Cards.Application.Filters;
using Cards.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CardsWeb.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CardController : Controller
    {
        private readonly CardService _cardService;
        [HttpGet]
        public async Task<IActionResult> GetById()
        {
            return Ok();
        }
        [HttpGet("userId")]
        public async Task<IActionResult> GetCards([FromRoute]Guid userId, [FromQuery] CardFilter cardFilter)
        {
            return Ok(_cardService.GetByUserId(userId,cardFilter));
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
        [Route("{cardId}")]
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
