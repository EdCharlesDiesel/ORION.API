using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ORION.Sales.MapperProfiles;

namespace ORION.Sales.Controllers
{

    [Route("api/sales/salespersons")]
    public class SalesPersonsController : ControllerBase
    {
        private readonly ISalesPersonService _SalesPersonService;
        private readonly IMapper _mapper;


        public SalesPersonsController(ISalesPersonService SalesPersonService,
            IMapper mapper)
        {
            _SalesPersonService = SalesPersonService;
            _mapper = mapper;
        }

        [HttpPost]
        public async Task<ActionResult<SalesPersonDto>> CreateSalesPerson(SalesPersonForCreationDto
                                                                                    SalesPersonForCreation, ISalesPersonService SalesPersonService)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            // create an internal SalesPerson entity with default values filled out
            // and the values inputted via the POST request
            var SalesPerson =
                    await SalesPersonService.CreateSalesPersonAsync(
                        SalesPersonForCreation.FirstName, SalesPersonForCreation.LastName);

            // persist it
            await SalesPersonService.AddSalesPersonAsync(SalesPerson);

            // return created SalesPerson after mapping to a DTO
            return CreatedAtAction("GetSalesPerson",
                _mapper.Map<SalesPersonDto>(SalesPerson),
                new { SalesPersonId = SalesPerson.Id });
        }


        [HttpGet]
        public IActionResult GetProtectedSalesPersons()
        {
            // depending on the role, redirect to another action
            if (User.IsInRole("Admin"))
            {
                return RedirectToAction(
                    "GetSalesPersons", "ProtectedSalesPersons");
            }

            return RedirectToAction("GetSalesPersons", "SalesPersons");
        }


        [HttpGet]
        public async Task<ActionResult<IEnumerable<SalesPersonDto>>> GetSalesPersons()
        {
            var SalesPersons = await _SalesPersonService.FetchSalesPersonsAsync();

            var SalesPersonDtos =
                _mapper.Map<IEnumerable<SalesPersonDto>>(SalesPersons);

            return Ok(SalesPersonDtos);
        }

        [HttpGet("{SalesPersonId}", Name = "GetSalesPerson")]
        public async Task<ActionResult<SalesPersonDto>> GetSalesPerson(
            Guid? SalesPersonId)
        {
            if (!SalesPersonId.HasValue)
            {
                return NotFound();
            }

            var SalesPerson = await _SalesPersonService.FetchSalesPersonAsync(value: SalesPersonId.Value);
            if (SalesPerson == null)
            {
                return NotFound();
            }

            return Ok(_mapper.Map<SalesPersonDto>(SalesPerson));
        }


        [HttpPost]
        public async Task<ActionResult<SalesPersonDto>> CreateSalesPerson(
            SalesPersonForCreationDto SalesPersonForCreation)
        {
            // create an internal SalesPerson entity with default values filled out
            // and the values inputted via the POST request
            var SalesPerson =
                    await _SalesPersonService.CreateSalesPersonAsync(
                        SalesPersonForCreation.FirstName, SalesPersonForCreation.LastName);

            // persist it
            await _SalesPersonService.AddSalesPersonAsync(SalesPerson);

            // return created SalesPerson after mapping to a DTO
            return CreatedAtAction("GetSalesPerson",
                _mapper.Map<SalesPersonDto>(SalesPerson),
                new { SalesPersonId = SalesPerson.Id });
        }


        [HttpPost]
        public async Task<IActionResult> CreatePromotion(PromotionForCreationDto promotionForCreation)
        {
            var SalesPersonToPromote = await _SalesPersonService
                .FetchSalesPersonAsync(promotionForCreation.SalesPersonId);

            if (SalesPersonToPromote == null)
            {
                return BadRequest();
            }

            if (await _promotionService.PromoteSalesPersonAsync(SalesPersonToPromote))
            {
                return Ok(new PromotionResultDto()
                {
                    SalesPersonId = SalesPersonToPromote.Id,
                    JobLevel = SalesPersonToPromote.JobLevel
                });
            }
            else
            {
                return BadRequest("SalesPerson not eligible for promotion.");
            }
        }
    }

    
}
