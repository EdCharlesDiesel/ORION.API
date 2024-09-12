using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using ORION.StockMarket.DataAccess.Models;
using ORION.StockMarket.DataAccess.Services;

namespace ORION.StockMarket.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CalendarController : ControllerBase
    {
        private readonly ILogger<CalendarController> _logger;
        private readonly ICalendarRepository _calendarRepository;
        private readonly IMapper _mapper;
        public CalendarController(ILogger<CalendarController> logger, 
            ICalendarRepository calendarRepository,
                IMapper mapper)
        {
            _logger = logger ;
            _calendarRepository = calendarRepository;
            _mapper = mapper;
        }
        
        [HttpGet( Name = "GetEconomicCalenders")]
        public async Task<ActionResult<EconomicCalendarDto>> GetEconomicCalenders()
        {
            var EcomonicCalendars = await _calendarRepository.GetCalendarsAsync();

            return Ok(_mapper.Map<EconomicCalendarDto>());
        }


        [HttpPost]
        public async Task<ActionResult<EconomicCalendarDto>> PostCalendar(EconomicCalendarForCreationDto calendarForCreation)
        {
            // create an internal employee entity with default values filled out
            // and the values inputted via the POST request
            var calendar = await _calendarRepository.AddCalendarAsync(calendarForCreation);
                    

            // persist it
            await _calendarRepository.AddCalendarAsync(calendar);

            // return created employee after mapping to a DTO
            return CreatedAtAction("GetEconomicCalenders",
                _mapper.Map<EconomicCalendarForCreationDto>(calendar),
                new { CalendarId = calendar.CalendarId });
        }
    }
}
