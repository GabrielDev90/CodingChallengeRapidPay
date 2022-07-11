
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RapidPay.CardManagement.Module.Facade;
using RapidPay.CardManagement.Module.Models;
using System.ComponentModel.DataAnnotations;

namespace RapidPayChallenge.Controllers
{
    [Route("api/Card")]
    [ApiController]
    [Authorize]
    public class CardController : ControllerBase
    {
        private readonly IFacadeCard _facadeCard;

        public CardController(IFacadeCard facadeCard)
        {
            _facadeCard = facadeCard;
        }

        [HttpPost("CreateCard")]
        public async Task<IActionResult> CreateCard()
        {
            var result = await _facadeCard.CreateCard(new Card() { Guid = new Guid(), Balance = 100} );
            return StatusCode(result.StatusCode, result);
        }

        [HttpPost("Payment")]
        public async Task<IActionResult> Payment([Required] float paymentValue, [Required] long cardNumber)
        {
            var result = await _facadeCard.MakePayment(paymentValue, cardNumber);

            return StatusCode(result.StatusCode, result);
        }

        [HttpGet("GetBalance")]
        public async Task<IActionResult> GetBalance([Required] long cardNumber)
        {
            var result = await _facadeCard.GetBalance(cardNumber);
            return StatusCode(result.StatusCode, result);
        }
    }
}
