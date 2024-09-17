using System.Globalization;
using AutoMapper;
using CsvHelper;
using CsvHelper.Configuration;
using Microsoft.AspNetCore.Mvc;
using ORION.StockMarket.DataAccess.Entities;
using ORION.StockMarket.DataAccess.Models;
using ORION.StockMarket.DataAccess.Services;
using SalesPerson = ORION.StockMarket.DataAccess.Entities.SalesPerson;

namespace ORION.StockMarket.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SalesPersonController : ControllerBase
    {
        private readonly ILogger<SalesPersonController> _logger;
        private readonly ISalesPersonRepository _SalesPersonRepository;
        private readonly IMapper _mapper;
   //     private static HttpClient _httpClient;
        public SalesPersonController(ILogger<SalesPersonController> logger,
            ISalesPersonRepository SalesPersonRepository,
            IMapper mapper
            )
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _SalesPersonRepository = SalesPersonRepository ?? throw new ArgumentNullException(nameof(SalesPersonRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));

            //_httpClient.BaseAddress = new Uri("http://localhost:57863");
     //       _httpClient.Timeout = new TimeSpan(0, 0, 30);
       //     _httpClient.DefaultRequestHeaders.Clear();
        }
   

        [HttpOptions()]
        public IActionResult GetEconomicSalesPersonOptions()
        {
            Response.Headers.Add("Allow", "GET,HEAD,POST,OPTIONS");
            return Ok();
        }

        [HttpGet(Name = "GetEconomicCalenders")]

        public async Task<ActionResult<IEnumerable<EconomicSalesPersonDto>>> GetEconomicCalenders()
        {
            var economicSalesPersons = await _SalesPersonRepository.GetSalesPersonsAsync();

            return Ok(_mapper.Map<IEnumerable<EconomicSalesPersonDto>>(economicSalesPersons));
        }


        //[HttpPost(Name = "CreateSalesPerson")]
        //public async Task<ActionResult<EconomicSalesPersonDto>> CreateSalesPerson(EconomicSalesPersonForCreationDto SalesPerson)
        //{
        //    var SalesPersonToSave = _mapper.Map<SalesPerson>(SalesPerson);

        //    _SalesPersonRepository.AddSalesPerson(SalesPersonToSave);
        //    await _SalesPersonRepository.SaveChangesAsync();

        //    var SalesPersonToReturn = _mapper.Map<EconomicSalesPersonDto>(SalesPersonToSave);
        //    return CreatedAtAction("GetEconomicCalenders",
        //        new
        //        {
        //            SalesPersonId = SalesPersonToReturn.SalesPersonId
        //        },
        //        SalesPersonToReturn);

        //}

        [HttpPost(Name = "CreateSalesPersons")]
        public async Task<ActionResult<IEnumerable<EconomicSalesPersonDto>>> CreateSalesPersons([FromBody] List<SalesPerson> SalesPersons)
        {
            if (SalesPersons == null || !SalesPersons.Any())
            {
                return BadRequest("List of SalesPersons cannot be empty.");
            }


            await _SalesPersonRepository.AddSalesPersonsAsync(SalesPersons);
            await _SalesPersonRepository.SaveChangesAsync();
            return Ok("SalesPersons added successfully");
        }

        [HttpPost("upload")]
        public async Task<IActionResult> UploadCsv(IFormFile file)
        {
            if (file == null || file.Length == 0)
            {
                return BadRequest("No file uploaded.");
            }

            using var stream = new StreamReader(file.OpenReadStream());
            using var csvReader = new CsvReader(stream, new CsvConfiguration(CultureInfo.InvariantCulture)
            {
                HeaderValidated = null,
                MissingFieldFound = null
            });

            var records = csvReader.GetRecords<SalesPerson>().ToList();

            //_SalesPersonRepository.People.AddRange(records);
            await _SalesPersonRepository.AddSalesPersonsAsync(records);   
            await _SalesPersonRepository.SaveChangesAsync();

            return Ok("CSV data saved successfully!");
        }

        //[HttpPost]
        //public async Task<ActionResult<SalesPerson>> GetEcomomicSalesPersonFromAPI()
        //{
        //    var response = await _httpClient.GetAsync("https://api.tradingeconomics.com/SalesPerson?c=e9f95eed6aa6465:blsksmd6c5y89rx");
        //    response.EnsureSuccessStatusCode();
        //    var content = await response.Content.ReadAsStringAsync();
        //    List<SalesPerson> SalesPersons =
        //        //if (response.Content.Headers.ContentType.MediaType == "application/json")
        //        //{
        //        JsonConvert.DeserializeObject<List<SalesPerson>>(content);
        //    //}
        //    //else if (response.Content.Headers.ContentType.MediaType == "application/xml")
        //    //{
        //    var serializer = new XmlSerializer(typeof(List<SalesPerson>));
        //        SalesPersons = (List<SalesPerson>)serializer.Deserialize(new StringReader(content));
        //    //}

        //    return Ok(SalesPersons);
        //}



    }
}
