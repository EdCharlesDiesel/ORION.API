using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ORION.Sales.DataAccess.Entities;
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
        public CreditCardsController(ICreditCardRepository creditCardService, IMapper mapper)
        {
            _creditCardService = creditCardService ?? throw new ArgumentException(nameof(creditCardService));
            _mapper = mapper ?? throw new ArgumentException(nameof(mapper));
        }

        [HttpPost(Name = "CreateCreditCard")]
        public async Task<ActionResult<CreditCardDto>> CreateCreditCard(CreditCardForCreationDto creditCardForCreation)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            // create an internal CreditCard entity with default values filled out
            // and the values inputted via the POST request
            var creditCard = await _mapper.Map<CreditCardDto>(creditCardForCreation);

            // persist it
            await _creditCardService.CreateCreditCardAsync(creditCard);

            // return created CreditCard after mapping to a DTO
            return CreatedAtAction("GetCreditCard",
                _mapper.Map<CreditCardDto>(creditCard),
                new { CreditCardId = CreditCard.CreditCardId });
        }

   
        [HttpGet(Name = "GetListOfCreditCards")]
        public async Task<ActionResult<IEnumerable<CreditCardDto>>> GetListOfCreditCards()
        {
            var creditCards = await _creditCardService.ReadCreditCardsAsync();

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
            var creditCard = await _creditCardService.ReadCreditCardAsync(creditCardId)!;

            return Ok(_mapper.Map<CreditCardDto>(creditCard));
        }

        public async Task<>
    }
}
