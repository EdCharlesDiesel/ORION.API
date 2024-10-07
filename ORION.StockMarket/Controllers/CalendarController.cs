using System.Globalization;
using AutoMapper;
using CsvHelper;
using CsvHelper.Configuration;
using Microsoft.AspNetCore.Mvc;
using ORION.StockMarket.DataAccess.Entities;
using ORION.StockMarket.DataAccess.Models;
using ORION.StockMarket.DataAccess.Services;
using CreditCard = ORION.StockMarket.DataAccess.Entities.CreditCard;

namespace ORION.StockMarket.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CreditCardController : ControllerBase
    {
        private readonly ILogger<CreditCardController> _logger;
        private readonly ICreditCardRepository _CreditCardRepository;
        private readonly IMapper _mapper;
        public CreditCardController(ILogger<CreditCardController> logger,
            ICreditCardRepository CreditCardRepository,
            IMapper mapper
            )
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _CreditCardRepository = CreditCardRepository ?? throw new ArgumentNullException(nameof(CreditCardRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }
   

        [HttpOptions()]
        public IActionResult GetEconomicCreditCardOptions()
        {
            Response.Headers.Add("Allow", "GET,HEAD,POST,OPTIONS");
            return Ok();
        }

        [HttpGet(Name = "GetEconomicCalenders")]

        public async Task<ActionResult<IEnumerable<EconomicCreditCardDto>>> GetEconomicCalenders()
        {
            var economicCreditCards = await _CreditCardRepository.GetCreditCardsAsync();

            return Ok(_mapper.Map<IEnumerable<EconomicCreditCardDto>>(economicCreditCards));
        }


        //[HttpPost(Name = "CreateCreditCard")]
        //public async Task<ActionResult<EconomicCreditCardDto>> CreateCreditCard(EconomicCreditCardForCreationDto CreditCard)
        //{
        //    var CreditCardToSave = _mapper.Map<CreditCard>(CreditCard);

        //    _CreditCardRepository.AddCreditCard(CreditCardToSave);
        //    await _CreditCardRepository.SaveChangesAsync();

        //    var CreditCardToReturn = _mapper.Map<EconomicCreditCardDto>(CreditCardToSave);
        //    return CreatedAtAction("GetEconomicCalenders",
        //        new
        //        {
        //            CreditCardId = CreditCardToReturn.CreditCardId
        //        },
        //        CreditCardToReturn);

        //}

        [HttpPost(Name = "CreateCreditCards")]
        public async Task<ActionResult<IEnumerable<EconomicCreditCardDto>>> CreateCreditCards([FromBody] List<CreditCard> CreditCards)
        {
            if (CreditCards == null || !CreditCards.Any())
            {
                return BadRequest("List of CreditCards cannot be empty.");
            }


            await _CreditCardRepository.AddCreditCardsAsync(CreditCards);
            await _CreditCardRepository.SaveChangesAsync();
            return Ok("CreditCards added successfully");
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

            var records = csvReader.GetRecords<CreditCard>().ToList();

            //_CreditCardRepository.People.AddRange(records);
            await _CreditCardRepository.AddCreditCardsAsync(records);   
            await _CreditCardRepository.SaveChangesAsync();

            return Ok("CSV data saved successfully!");
        }

        //[HttpPost]
        //public async Task<ActionResult<CreditCard>> GetEcomomicCreditCardFromAPI()
        //{
        //    var response = await _httpClient.GetAsync("https://api.tradingeconomics.com/CreditCard?c=e9f95eed6aa6465:blsksmd6c5y89rx");
        //    response.EnsureSuccessStatusCode();
        //    var content = await response.Content.ReadAsStringAsync();
        //    List<CreditCard> CreditCards =
        //        //if (response.Content.Headers.ContentType.MediaType == "application/json")
        //        //{
        //        JsonConvert.DeserializeObject<List<CreditCard>>(content);
        //    //}
        //    //else if (response.Content.Headers.ContentType.MediaType == "application/xml")
        //    //{
        //    var serializer = new XmlSerializer(typeof(List<CreditCard>));
        //        CreditCards = (List<CreditCard>)serializer.Deserialize(new StringReader(content));
        //    //}

        //    return Ok(CreditCards);
        //}



    }
}
