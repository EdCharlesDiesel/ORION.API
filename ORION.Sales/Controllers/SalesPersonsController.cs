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
        public SalesPersonsController(ISalesPersonRepository salesPersonService, IMapper mapper)
        {
            _salesPersonRepository = salesPersonService ?? throw new ArgumentException(nameof(salesPersonService));
            _mapper = mapper ?? throw new ArgumentException(nameof(mapper));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="salesPersonForCreation"></param>
        /// <returns></returns>
        [HttpPost(Name = "CreateSalesPerson")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult<SalesPersonDto>> CreateSalesPerson(SalesPersonForCreationDto salesPersonForCreation)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            // create an internal SalesPerson entity with default values filled out
            // and the values inputted via the POST request
            var salesPerson = await _mapper.Map<SalesPersonDto>(salesPersonForCreation);

            // persist it
            await _salesPersonRepository.CreateSalesPersonAsync(salesPerson);
            await _salesPersonRepository.SaveChangesAsync();

            // return created SalesPerson after mapping to a DTO
            return CreatedAtAction("GetSalesPerson",
                _mapper.Map<SalesPersonDto>(salesPerson),
                new { SalesPersonId = SalesPersonDto.BusinessEntityId });
        }

        /// <summary>
        /// Gets a list of Sales Persons data.
        /// </summary>
        /// <returns>Action</returns>
        [HttpGet(Name = "GetListOfSalesPersons")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult<IEnumerable<SalesPersonDto>>> GetListOfSalesPersons()
        {
            var salesPersons = await _salesPersonRepository.ReadSalesPersonsAsync();

            var salesPersonDtos = _mapper.Map<IEnumerable<SalesPersonDto>>(salesPersons);

            return Ok(salesPersonDtos);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="salesPersonId"></param>
        /// <returns></returns>
        [HttpGet("{salesPersonId}", Name = "GetSalesPerson")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult<SalesPersonDto>> GetSalesPerson(Guid salesPersonId)
        {
            if (salesPersonId == new Guid())
            {
                return NotFound();
            }
            var salesPerson = await _salesPersonRepository.ReadSalesPersonAsync(salesPersonId)!;

            return Ok(_mapper.Map<SalesPersonDto>(salesPerson));
        }

        /// <summary>
        /// Update Sales person.
        /// </summary>
        /// <param name="salesPersonId"></param>
        /// <param name="salesPersonForUpdate"></param>
        /// <returns>An ActionResult of type SalesPerson</returns>
        [HttpPut("{salesPersonId}", Name = "UpdateSalesPerson")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult<SalesPerson>> UpdateSalesPerson(Guid salesPersonId, SalesPersonForUpdateDto salesPersonForUpdate)
        {
            var salesPersonFromRepo = await _salesPersonRepository.ReadSalesPersonAsync(salesPersonId)!;
            if (salesPersonFromRepo == null)
            {
                return NotFound();
            }

            _mapper.Map(salesPersonForUpdate, salesPersonFromRepo);

            // update & save
            await _salesPersonRepository.UpdateSalesPersonAsync(salesPersonId,salesPersonFromRepo);
            await _salesPersonRepository.SaveChangesAsync();

            
            return Ok(_mapper.Map<SalesPerson>(salesPersonFromRepo));
        }

        /// <summary>
        /// Partially update an salesPerson
        /// </summary>
        /// <param name="salesPersonId">The id of the salesPerson you want to get</param>
        /// <param name="patchDocument">The set of operations to apply to the salesPerson</param>
        /// <returns>An ActionResult of type SalesPerson</returns>
        /// <remarks>
        /// Sample request (this request updates the salesPerson's **first name**):    
        /// 
        ///     PATCH /salesPersons/salesPersonId
        ///     [ 
        ///         {
        ///             "op": "replace", 
        ///             "path": "/firstname", 
        ///             "value": "new first name" 
        ///         } 
        ///     ] 
        /// </remarks>
        [HttpPatch("{salesPersonId}", Name = "PatchSalesPerson")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult<SalesPerson>> PatchSalesPerson(Guid salesPersonId, JsonPatchDocument<SalesPersonForUpdateDto> patchDocument)
        {
            var salesPersonFromRepo = await _salesPersonRepository.ReadSalesPersonAsync(salesPersonId)!;
            if (salesPersonFromRepo == null)
            {
                return NotFound();
            }

            // map to DTO to apply the patch to
            var salesPerson = _mapper.Map<SalesPersonForCreationDto>(salesPersonFromRepo);
            patchDocument.ApplyTo(salesPerson, ModelState);

            // if there are errors when applying the patch the patch doc 
            // was badly formed  These aren't caught via the ApiController
            // validation, so we must manually check the modelstate and
            // potentially return these errors.
            if (!ModelState.IsValid)
            {
                return new UnprocessableEntityObjectResult(ModelState);
            }

            // map the applied changes on the DTO back into the entity
           // _mapper.Map(salesPerson, salesPersonFromRepo);

            // update & save
            await _salesPersonRepository.UpdateSalesPersonAsync(salesPersonId,salesPersonFromRepo);
            await _salesPersonRepository.SaveChangesAsync();

            // return the salesPerson
            return Ok(_mapper.Map<SalesPerson>(salesPersonFromRepo));
        }

        /// <summary>
        /// Delete a sales person.
        /// </summary>
        /// <param name="salesPersonId"></param>
        /// <returns></returns>
        [HttpGet("{salesPersonId}", Name = "DeleteSalesPerson")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult<SalesPersonDto>> DeleteSalesPerson(Guid salesPersonId)
        {
            if (salesPersonId == new Guid())
            {
                return NotFound();
            }
            var salesPerson = await _salesPersonRepository.DeleteSalesPersonAsync(salesPersonId)!;
            await _salesPersonRepository.SaveChangesAsync();

            return NoContent();
        }
    }
}

    

