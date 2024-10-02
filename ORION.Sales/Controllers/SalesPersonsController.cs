using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ORION.Sales.DataAccess.Entities;
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
        public SalesPersonsController(ISalesPersonRepository creditCardService, IMapper mapper)
        {
            _salesPersonRepository = creditCardService ?? throw new ArgumentException(nameof(creditCardService));
            _mapper = mapper ?? throw new ArgumentException(nameof(mapper));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="creditCardForCreation"></param>
        /// <returns></returns>
        [HttpPost(Name = "CreateSalesPerson")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult<SalesPersonDto>> CreateSalesPerson(SalesPersonForCreationDto creditCardForCreation)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            // create an internal SalesPerson entity with default values filled out
            // and the values inputted via the POST request
            var creditCard = await _mapper.Map<SalesPersonDto>(creditCardForCreation);

            // persist it
            await _salesPersonRepository.CreateSalesPersonAsync(creditCard);
            await _salesPersonRepository.SaveChangesAsync();

            // return created SalesPerson after mapping to a DTO
            return CreatedAtAction("GetSalesPerson",
                _mapper.Map<SalesPersonDto>(creditCard),
                new { SalesPersonId = SalesPersonDto.BusinessEntityId });
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [HttpGet(Name = "GetListOfSalesPersons")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult<IEnumerable<SalesPersonDto>>> GetListOfSalesPersons()
        {
            var creditCards = await _salesPersonRepository.ReadSalesPersonsAsync();

            var creditCardDtos = _mapper.Map<IEnumerable<SalesPersonDto>>(creditCards);

            return Ok(creditCardDtos);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="creditCardId"></param>
        /// <returns></returns>
        [HttpGet("{creditCardId}", Name = "GetSalesPerson")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult<SalesPersonDto>> GetSalesPerson(Guid creditCardId)
        {
            if (creditCardId == new Guid())
            {
                return NotFound();
            }
            var creditCard = await _salesPersonRepository.ReadSalesPersonAsync(creditCardId)!;

            return Ok(_mapper.Map<SalesPersonDto>(creditCard));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="creditCardId"></param>
        /// <param name="creditCardForUpdate"></param>
        /// <returns></returns>
        [HttpPut("{creditCardId}", Name = "UpdateSalesPerson")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult<SalesPerson>> UpdateSalesPerson(Guid creditCardId, SalesPersonForUpdateDto creditCardForUpdate)
        {
            var creditCardFromRepo = await _salesPersonRepository.ReadSalesPersonAsync(creditCardId)!;
            if (creditCardFromRepo == null)
            {
                return NotFound();
            }

            _mapper.Map(creditCardForUpdate, creditCardFromRepo);

            // update & save
            _salesPersonRepository.UpdateSalesPersonAsync(creditCardFromRepo);
            await _salesPersonRepository.SaveChangesAsync();

            // return the creditCard
            return Ok(_mapper.Map<SalesPerson>(creditCardFromRepo));
        }

        /// <summary>
        /// Partially update an creditCard
        /// </summary>
        /// <param name="creditCardId">The id of the creditCard you want to get</param>
        /// <param name="patchDocument">The set of operations to apply to the creditCard</param>
        /// <returns>An ActionResult of type SalesPerson</returns>
        /// <remarks>
        /// Sample request (this request updates the creditCard's **first name**):    
        /// 
        ///     PATCH /creditCards/creditCardId
        ///     [ 
        ///         {
        ///             "op": "replace", 
        ///             "path": "/firstname", 
        ///             "value": "new first name" 
        ///         } 
        ///     ] 
        /// </remarks>
        [HttpPatch("{creditCardId}", Name = "PatchSalesPerson")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult<SalesPerson>> PutchSalesPerson(Guid creditCardId, JsonPatchDocument<SalesPersonForUpdateDto> patchDocument)
        {
            var creditCardFromRepo = await _salesPersonRepository.ReadSalesPersonAsync(creditCardId);
            if (creditCardFromRepo == null)
            {
                return NotFound();
            }

            // map to DTO to apply the patch to
            var creditCard = _mapper.Map<ORION.Sales.DataAccess.Models.SalesPersonForCreateDto>(creditCardFromRepo);
            patchDocument.ApplyTo(creditCard, ModelState);

            // if there are errors when applying the patch the patch doc 
            // was badly formed  These aren't caught via the ApiController
            // validation, so we must manually check the modelstate and
            // potentially return these errors.
            if (!ModelState.IsValid)
            {
                return new UnprocessableEntityObjectResult(ModelState);
            }

            // map the applied changes on the DTO back into the entity
            _mapper.Map(creditCard, creditCardFromRepo);

            // update & save
            _salesPersonRepository.UpdateSalesPersonAsync(creditCardFromRepo);
            await _salesPersonRepository.SaveChangesAsync();

            // return the creditCard
            return Ok(_mapper.Map<SalesPerson>(creditCardFromRepo));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="creditCardId"></param>
        /// <returns></returns>
        [HttpGet("{creditCardId}", Name = "DeleteSalesPerson")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult<SalesPersonDto>> DeleteSalesPerson(Guid creditCardId)
        {
            if (creditCardId == new Guid())
            {
                return NotFound();
            }
            var creditCard = await _salesPersonRepository.DeleteSalesPersonAsync(creditCardId)!;
            await _salesPersonRepository.SaveChangesAsync();

            return Ok(_mapper.Map<SalesPersonDto>(creditCard));
        }
    }
}

    

