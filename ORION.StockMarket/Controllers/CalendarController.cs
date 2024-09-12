using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using ORION.StockMarket.DataAccess.Entities;
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
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _calendarRepository = calendarRepository ?? throw new ArgumentNullException(nameof(calendarRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        [HttpOptions()]
        public IActionResult GetEconomicCalendarOptions()
        {
            Response.Headers.Add("Allow", "GET,HEAD,POST,OPTIONS");
            return Ok();
        }

        [HttpGet(Name = "GetEconomicCalenders")]

        public async Task<ActionResult<IEnumerable<EconomicCalendarDto>>> GetEconomicCalenders()
        {
            var economicCalendars = await _calendarRepository.GetCalendarsAsync();

            return Ok(_mapper.Map<IEnumerable<EconomicCalendarDto>>(economicCalendars));
        }


        [HttpPost(Name = "CreateCalendar")]
        public async Task<ActionResult<EconomicCalendarDto>> CreateCalendar(EconomicCalendarForCreationDto calendar)
        {
            var calendarToSave = _mapper.Map<Calendar>(calendar);

            _calendarRepository.AddCalendar(calendarToSave);
            await _calendarRepository.SaveChangesAsync();

            var calendarToReturn = _mapper.Map<EconomicCalendarDto>(calendarToSave);
            return CreatedAtAction("GetEconomicCalenders",
                new
                {
                    CalendarId = calendarToReturn.CalendarId },
                calendarToReturn);

        }
    }
}
