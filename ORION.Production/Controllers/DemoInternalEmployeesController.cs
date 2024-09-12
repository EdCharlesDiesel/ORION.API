using AutoMapper;
using ORION.HumanResources.Business;
using ORION.HumanResources.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ORION.HumanResources.Controllers
{
    [Route("api/demoCalendars")]
    public class DemoCalendarsController : ControllerBase
    {
        private readonly IEmployeeService _employeeService;
        private readonly IMapper _mapper;

        public DemoCalendarsController(IEmployeeService employeeService,
            IMapper mapper)
        {
            _employeeService = employeeService;
            _mapper = mapper;
        }

        [HttpPost]
        public async Task<ActionResult<CalendarDto>> CreateCalendar(
            CalendarForCreationDto CalendarForCreation)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            // create an internal employee entity with default values filled out
            // and the values inputted via the POST request
            var Calendar =
                    await _employeeService.CreateCalendarAsync(
                        CalendarForCreation.FirstName, CalendarForCreation.LastName);

            // persist it
            await _employeeService.AddCalendarAsync(Calendar);

            // return created employee after mapping to a DTO
            return CreatedAtAction("GetCalendar",
                _mapper.Map<CalendarDto>(Calendar),
                new { employeeId = Calendar.Id });
        }


        [HttpGet]
        [Authorize]
        public IActionResult GetProtectedCalendars()
        {
            // depending on the role, redirect to another action
            if (User.IsInRole("Admin"))
            {
                return RedirectToAction(
                    "GetCalendars", "ProtectedCalendars");
            }

            return RedirectToAction("GetCalendars", "Calendars");
        }

    }
}
