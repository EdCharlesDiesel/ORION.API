using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ORION.Sales.DataAccess.Models;
using ORION.Sales.DataAccess.Services;
using ORION.Sales.MapperProfiles;

namespace ORION.Sales.Controllers
{

    [Route("api/sales/salespersons")]
    public class SalesPersonsController : ControllerBase
    {
        private readonly ISalesPersonRepository _salesPersonRepository;
        private readonly IMapper _mapper;


        public SalesPersonsController(ISalesPersonRepository salesPersonRepository,
            IMapper mapper)
        {
            _salesPersonRepository = salesPersonRepository;
            _mapper = mapper;
        }

        [HttpGet(Name = "GetListOfSalesPersons")]
        public async Task<ActionResult<IEnumerable<SalesPersonDto>>> GetListOfSalesPersons()
        {
            var salesPersons = await _salesPersonRepository.GetListOfSalesPersonsAsync();

            var salesPersonDtos = _mapper.Map<IEnumerable<SalesPersonDto>>(salesPersons);

            return Ok(salesPersonDtos);
        }

        [HttpGet("{SalesPersonId}", Name = "GetSalesPerson")]
        public async Task<ActionResult<SalesPersonDto>> GetSalesPerson(Guid SalesPersonId)
        {
            if (SalesPersonId == new Guid())
            {
                return NotFound();
            }

            var SalesPerson = await _salesPersonRepository.GetSalesPersonAsync(SalesPersonId);
            if (SalesPerson == null)
            {
                return NotFound();
            }

            return Ok(_mapper.Map<SalesPersonDto>(SalesPerson));
        }
       
    }

    public class SalesPersonDto
    {
    }
}

    

