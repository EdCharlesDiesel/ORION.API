using AutoMapper;
using ORION.HumanResources.Business;
using ORION.HumanResources.Models; 
using Microsoft.AspNetCore.Mvc;

namespace ORION.HumanResources.Controllers
{
    [Route("api/Calendars")]
    [ApiController]
    public class CalendarsController : ControllerBase
    {
        private readonly IEmployeeService _employeeService;
        private readonly IMapper _mapper;

        public CalendarsController(IEmployeeService employeeService, 
            IMapper mapper)
        {
            _employeeService = employeeService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<CalendarDto>>> GetCalendars()
        {
            var Calendars = await _employeeService.FetchCalendarsAsync();

            // with manual mapping
            //var CalendarDtos =
            //    Calendars.Select(e => new CalendarDto()
            //    {
            //        Id = e.Id,
            //        FirstName = e.FirstName,
            //        LastName = e.LastName,
            //        Salary = e.Salary,
            //        SuggestedBonus = e.SuggestedBonus,
            //        YearsInService = e.YearsInService
            //    });

            // with AutoMapper
            var CalendarDtos =
                _mapper.Map<IEnumerable<CalendarDto>>(Calendars);

            return Ok(CalendarDtos);
        }

        [HttpGet("{employeeId}", Name = "GetCalendar")]
        public async Task<ActionResult<CalendarDto>> GetCalendar(
            Guid? employeeId)
        {
            if (!employeeId.HasValue)
            { 
                return NotFound(); 
            }

            var Calendar = await _employeeService.FetchCalendarAsync(employeeId.Value);
            if (Calendar == null)
            { 
                return NotFound();
            }             

            return Ok(_mapper.Map<CalendarDto>(Calendar));
        }


        [HttpPost]
        public async Task<ActionResult<CalendarDto>> CreateCalendar(
            CalendarForCreationDto CalendarForCreation)
        { 
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
                new { employeeId = Calendar.Id } );
        }
    }
}
