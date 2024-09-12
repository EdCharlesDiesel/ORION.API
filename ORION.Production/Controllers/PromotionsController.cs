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
            var CalendarToPromote = await _employeeService
                .FetchCalendarAsync(promotionForCreation.EmployeeId);

            if (CalendarToPromote == null)
            {
                return BadRequest();
            } 

            if (await _promotionService.PromoteCalendarAsync(CalendarToPromote))
            {
                return Ok(new PromotionResultDto() 
                            { EmployeeId = CalendarToPromote.Id, 
                             JobLevel = CalendarToPromote.JobLevel });
            }
            else
            {
                return BadRequest("Employee not eligible for promotion.");
            }              
        }
    }
}
