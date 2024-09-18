using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ORION.Sales.DataAccess.Models;
using ORION.Sales.DataAccess.Services;

namespace ORION.Sales.Controllers
{
    [Authorize]
    [Route("api/sales/creditcard")]
    [ApiController]
    public class CreditCardsController : ControllerBase
    {
        private readonly ICreditCardRepository _creditCardService;
        private readonly IMapper _mapper;


        public CreditCardsController(ICreditCardRepository creditCardService,
            IMapper mapper)
        {
            _creditCardService = creditCardService;
            _mapper = mapper;
        }

        [HttpGet(Name = "GetListOfCreditCards")]
        public async Task<ActionResult<IEnumerable<CreditCardDto>>> GetListOfCreditCards()
        {
            var creditCards = await _creditCardService.GetListOfCreditCardsAsync();

            var creditCardDtos = _mapper.Map<IEnumerable<CreditCardDto>>(creditCards);

            return Ok(creditCardDtos);
        }

        [HttpGet("{CreditCardId}", Name = "GetCreditCard")]
        public async Task<ActionResult<CreditCardDto>> GetCreditCard(Guid creditCardId)
        {
            if (creditCardId == new Guid())
            {
                return NotFound();
            }

            var CreditCard = await _creditCardService.GetCreditCardAsync(creditCardId);
            if (CreditCard == null)
            {
                return NotFound();
            }

            return Ok(_mapper.Map<CreditCardDto>(CreditCard));
        }

        //[HttpPost]
        //public async Task<ActionResult<CreditCardDto>> CreateCreditCard(CreditCardForCreationDto creditCardForCreation)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }

        //    // create an internal CreditCard entity with default values filled out
        //    // and the values inputted via the POST request
        //    var creditCard = await _mapper.Map<CreditCardDto>(creditCardForCreation);

        //    // persist it
        //    await _creditCardService.AddCreditCardAsync(creditCard);

        //    // return created CreditCard after mapping to a DTO
        //    return CreatedAtAction("GetCreditCard",
        //        _mapper.Map<CreditCardDto>(creditCard),
        //        new { CreditCardId = CreditCard.CreditCardId });
        //}
    }
}
