using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ORION.Sales.DataAccess.Models;
using ORION.Sales.DataAccess.Services;
using ORION.Sales.MapperProfiles;

namespace ORION.Sales.Controllers
{
    [Authorize]
    [Route("api/sales/creditcard")]
    [ApiController]
    public class CreditCardsController : ControllerBase
    {
        private readonly ICreditCardService _creditCardService;
        private readonly IMapper _mapper;


        public CreditCardsController(ICreditCardService creditCardService,
            IMapper mapper)
        {
            _creditCardService = creditCardService;
            _mapper = mapper;
        }

        [HttpPost]
        public async Task<ActionResult<CreditCardDto>> CreateCreditCard(
                                                                                        CreditCardForCreationDto
                                                                                    CreditCardForCreation, ICreditCardService CreditCardService)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            // create an internal CreditCard entity with default values filled out
            // and the values inputted via the POST request
            var CreditCard =
                    await CreditCardService.CreateCreditCardAsync(
                        CreditCardForCreation.FirstName, CreditCardForCreation.LastName);

            // persist it
            await CreditCardService.AddCreditCardAsync(CreditCard);

            // return created CreditCard after mapping to a DTO
            return CreatedAtAction("GetCreditCard",
                _mapper.Map<CreditCardDto>(CreditCard),
                new { CreditCardId = CreditCard.Id });
        }


        [HttpGet]
        //[Authorize]
        public IActionResult GetProtectedCreditCards()
        {
            // depending on the role, redirect to another action
            if (User.IsInRole("Admin"))
            {
                return RedirectToAction(
                    "GetCreditCards", "ProtectedCreditCards");
            }

            return RedirectToAction("GetCreditCards", "CreditCards");
        }


        [HttpGet]
        public async Task<ActionResult<IEnumerable<CreditCardDto>>> GetCreditCards()
        {
            var CreditCards = await _CreditCardService.FetchCreditCardsAsync();

            var CreditCardDtos =
                _mapper.Map<IEnumerable<CreditCardDto>>(CreditCards);

            return Ok(CreditCardDtos);
        }

        [HttpGet("{CreditCardId}", Name = "GetCreditCard")]
        public async Task<ActionResult<CreditCardDto>> GetCreditCard(
            Guid? CreditCardId)
        {
            if (!CreditCardId.HasValue)
            {
                return NotFound();
            }

            var CreditCard = await _CreditCardService.FetchCreditCardAsync(value: CreditCardId.Value);
            if (CreditCard == null)
            {
                return NotFound();
            }

            return Ok(_mapper.Map<CreditCardDto>(CreditCard));
        }


        [HttpPost]
        public async Task<ActionResult<CreditCardDto>> CreateCreditCard(
            CreditCardForCreationDto CreditCardForCreation)
        {
            // create an internal CreditCard entity with default values filled out
            // and the values inputted via the POST request
            var CreditCard =
                    await _CreditCardService.CreateCreditCardAsync(
                        CreditCardForCreation.FirstName, CreditCardForCreation.LastName);

            // persist it
            await _CreditCardService.AddCreditCardAsync(CreditCard);

            // return created CreditCard after mapping to a DTO
            return CreatedAtAction("GetCreditCard",
                _mapper.Map<CreditCardDto>(CreditCard),
                new { CreditCardId = CreditCard.Id });
        }


        [HttpPost]
        public async Task<IActionResult> CreatePromotion(PromotionForCreationDto promotionForCreation)
        {
            var CreditCardToPromote = await _CreditCardService
                .FetchCreditCardAsync(promotionForCreation.CreditCardId);

            if (CreditCardToPromote == null)
            {
                return BadRequest();
            }

            if (await _promotionService.PromoteCreditCardAsync(CreditCardToPromote))
            {
                return Ok(new PromotionResultDto()
                {
                    CreditCardId = CreditCardToPromote.Id,
                    JobLevel = CreditCardToPromote.JobLevel
                });
            }
            else
            {
                return BadRequest("CreditCard not eligible for promotion.");
            }
        }
    }
}
