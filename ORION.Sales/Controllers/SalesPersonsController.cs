using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ORION.Sales.Controllers
{

    [Route("api/sales/salespersons")]
    [ApiController]
    [Authorize]
    public class SalesPersonsController : ControllerBase
    {
        //private readonly ICreditCardService _CreditCardService;
        //private readonly IMapper _mapper;


        //public SalesPersonsController(ICreditCardService CreditCardService,
        //    IMapper mapper)
        //{
        //    _CreditCardService = CreditCardService;
        //    _mapper = mapper;
        //}

        //[HttpPost]
        //public async Task<ActionResult<InternalCreditCardDto>> CreateInternalCreditCard(
        //                                                                                InternalCreditCardForCreationDto 
        //                                                                            internalCreditCardForCreation, ICreditCardService CreditCardService)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }

        //    // create an internal CreditCard entity with default values filled out
        //    // and the values inputted via the POST request
        //    var internalCreditCard =
        //            await CreditCardService.CreateInternalCreditCardAsync(
        //                internalCreditCardForCreation.FirstName, internalCreditCardForCreation.LastName);

        //    // persist it
        //    await CreditCardService.AddInternalCreditCardAsync(internalCreditCard);

        //    // return created CreditCard after mapping to a DTO
        //    return CreatedAtAction("GetInternalCreditCard",
        //        _mapper.Map<InternalCreditCardDto>(internalCreditCard),
        //        new { CreditCardId = internalCreditCard.Id });
        //}


        //[HttpGet]
        ////[Authorize]
        //public IActionResult GetProtectedInternalCreditCards()
        //{
        //    // depending on the role, redirect to another action
        //    if (User.IsInRole("Admin"))
        //    {
        //        return RedirectToAction(
        //            "GetInternalCreditCards", "ProtectedInternalCreditCards");
        //    }

        //    return RedirectToAction("GetInternalCreditCards", "InternalCreditCards");
        //}
        

        //[HttpGet]
        //public async Task<ActionResult<IEnumerable<InternalCreditCardDto>>> GetInternalCreditCards()
        //{
        //    var internalCreditCards = await _CreditCardService.FetchInternalCreditCardsAsync();
            
        //    var internalCreditCardDtos =
        //        _mapper.Map<IEnumerable<InternalCreditCardDto>>(internalCreditCards);

        //    return Ok(internalCreditCardDtos);
        //}

        //[HttpGet("{CreditCardId}", Name = "GetInternalCreditCard")]
        //public async Task<ActionResult<InternalCreditCardDto>> GetInternalCreditCard(
        //    Guid? CreditCardId)
        //{
        //    if (!CreditCardId.HasValue)
        //    {
        //        return NotFound();
        //    }

        //    var internalCreditCard = await _CreditCardService.FetchInternalCreditCardAsync(value: CreditCardId.Value);
        //    if (internalCreditCard == null)
        //    {
        //        return NotFound();
        //    }

        //    return Ok(_mapper.Map<InternalCreditCardDto>(internalCreditCard));
        //}


        //[HttpPost]
        //public async Task<ActionResult<InternalCreditCardDto>> CreateInternalCreditCard(
        //    InternalCreditCardForCreationDto internalCreditCardForCreation)
        //{
        //    // create an internal CreditCard entity with default values filled out
        //    // and the values inputted via the POST request
        //    var internalCreditCard =
        //            await _CreditCardService.CreateInternalCreditCardAsync(
        //                internalCreditCardForCreation.FirstName, internalCreditCardForCreation.LastName);

        //    // persist it
        //    await _CreditCardService.AddInternalCreditCardAsync(internalCreditCard);

        //    // return created CreditCard after mapping to a DTO
        //    return CreatedAtAction("GetInternalCreditCard",
        //        _mapper.Map<InternalCreditCardDto>(internalCreditCard),
        //        new { CreditCardId = internalCreditCard.Id });
        //}


        //[HttpPost]
        //public async Task<IActionResult> CreatePromotion(PromotionForCreationDto promotionForCreation)
        //{
        //    var internalCreditCardToPromote = await _CreditCardService
        //        .FetchInternalCreditCardAsync(promotionForCreation.CreditCardId);

        //    if (internalCreditCardToPromote == null)
        //    {
        //        return BadRequest();
        //    }

        //    if (await _promotionService.PromoteInternalCreditCardAsync(internalCreditCardToPromote))
        //    {
        //        return Ok(new PromotionResultDto()
        //        {
        //            CreditCardId = internalCreditCardToPromote.Id,
        //            JobLevel = internalCreditCardToPromote.JobLevel
        //        });
        //    }
        //    else
        //    {
        //        return BadRequest("CreditCard not eligible for promotion.");
        //    }
        //}
    }
}
