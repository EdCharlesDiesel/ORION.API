using ORION.HumanResources.Business;
using ORION.HumanResources.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ORION.HumanResources.Controllers
{
    [Route("api/promotions")]
    [ApiController]
    public class PromotionsController : ControllerBase
    {
        private readonly IEmployeeService _employeeService;
        private readonly IPromotionService _promotionService;

        public PromotionsController(IEmployeeService employeeService, 
            IPromotionService promotionService)
        {
            _employeeService = employeeService;
            _promotionService = promotionService;
        }

        [HttpPost]
        public async Task<IActionResult> CreatePromotion(PromotionForCreationDto promotionForCreation)
        { 
            var internalEmployeeToPromote = await _employeeService
                .FetchInternalEmployeeAsync(promotionForCreation.EmployeeId);

            if (internalEmployeeToPromote == null)
            {
                return BadRequest();
            } 

            if (await _promotionService.PromoteInternalEmployeeAsync(internalEmployeeToPromote))
            {
                return Ok(new PromotionResultDto() 
                            { EmployeeId = internalEmployeeToPromote.Id, 
                             JobLevel = internalEmployeeToPromote.JobLevel });
            }
            else
            {
                return BadRequest("Employee not eligible for promotion.");
            }              
        }
    }
}
