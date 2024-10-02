using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using ORION.Sales.DataAccess.Entities;
using ORION.Sales.DataAccess.Models;
using ORION.Sales.DataAccess.Services;

namespace ORION.Sales.Controllers
{
    [Authorize]
    [Route("api/sales/creditcard")]
    [ApiController]
    public class CreditCardsController : ControllerBase
    {
        private readonly ICreditCardRepository _creditCardRepository;
        private readonly IMapper _mapper;
        public CreditCardsController(ICreditCardRepository creditCardService, IMapper mapper)
        {
            _creditCardRepository = creditCardService ?? throw new ArgumentException(nameof(creditCardService));
            _mapper = mapper ?? throw new ArgumentException(nameof(mapper));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="creditCardForCreation"></param>
        /// <returns></returns>
        [HttpPost(Name = "CreateCreditCard")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult<CreditCardDto>> CreateCreditCard(CreditCardForCreationDto creditCardForCreation)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            // create an internal CreditCard entity with default values filled out
            // and the values inputted via the POST request
            var creditCard = await _mapper.Map<CreditCardDto>(creditCardForCreation);

            // persist it
            await _creditCardRepository.CreateCreditCardAsync(creditCard);
            await _creditCardRepository.SaveChangesAsync();

            // return created CreditCard after mapping to a DTO
            return CreatedAtAction("GetCreditCard",
                _mapper.Map<CreditCardDto>(creditCard),
                new { CreditCardId = CreditCard.CreditCardId });
        }
   
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [HttpGet(Name = "GetListOfCreditCards")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult<IEnumerable<CreditCardDto>>> GetListOfCreditCards()
        {
            var creditCards = await _creditCardRepository.ReadCreditCardsAsync();

            var creditCardDtos = _mapper.Map<IEnumerable<CreditCardDto>>(creditCards);

            return Ok(creditCardDtos);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="creditCardId"></param>
        /// <returns></returns>
        [HttpGet("{creditCardId}", Name = "GetCreditCard")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult<CreditCardDto>> GetCreditCard(Guid creditCardId)
        {
            if (creditCardId == new Guid())
            {
                return NotFound();
            }
            var creditCard = await _creditCardRepository.ReadCreditCardAsync(creditCardId)!;

            return Ok(_mapper.Map<CreditCardDto>(creditCard));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="creditCardId"></param>
        /// <param name="creditCardForUpdate"></param>
        /// <returns></returns>
        [HttpPut("{creditCardId}", Name = "UpdateCreditCard")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult<CreditCard>> UpdateCreditCard(Guid creditCardId, CreditCardForUpdateDto creditCardForUpdate)
        {
            var creditCardFromRepo = await _creditCardRepository.ReadCreditCardAsync(creditCardId)!;
            if (creditCardFromRepo == null)
            {
                return NotFound();
            }

            _mapper.Map(creditCardForUpdate, creditCardFromRepo);

            // update & save
            _creditCardRepository.UpdateCreditCardAsync(creditCardFromRepo);
            await _creditCardRepository.SaveChangesAsync();

            // return the creditCard
            return Ok(_mapper.Map<CreditCard>(creditCardFromRepo));
        }

        /// <summary>
        /// Partially update an creditCard
        /// </summary>
        /// <param name="creditCardId">The id of the creditCard you want to get</param>
        /// <param name="patchDocument">The set of operations to apply to the creditCard</param>
        /// <returns>An ActionResult of type CreditCard</returns>
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
        [HttpPatch("{creditCardId}",Name = "PatchCreditCard")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult<CreditCard>> PutchCreditCard(Guid creditCardId, JsonPatchDocument<CreditCardForUpdateDto> patchDocument)
        {
            var creditCardFromRepo = await _creditCardRepository.ReadCreditCardAsync(creditCardId);
            if (creditCardFromRepo == null)
            {
                return NotFound();
            }

            // map to DTO to apply the patch to
            var creditCard = _mapper.Map< ORION.Sales.DataAccess.Models.CreditCardForCreateDto >(creditCardFromRepo);
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
            _creditCardRepository.UpdateCreditCardAsync(creditCardFromRepo);
            await _creditCardRepository.SaveChangesAsync();

            // return the creditCard
            return Ok(_mapper.Map<CreditCard>(creditCardFromRepo));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="creditCardId"></param>
        /// <returns></returns>
        [HttpGet("{creditCardId}", Name = "DeleteCreditCard")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult<CreditCardDto>> DeleteCreditCard(Guid creditCardId)
        {
            if (creditCardId == new Guid())
            {
                return NotFound();
            }
            var creditCard = await _creditCardRepository.DeleteCreditCardAsync(creditCardId)!;
            await _creditCardRepository.SaveChangesAsync();

            return Ok(_mapper.Map<CreditCardDto>(creditCard));
        }
    }
    
}
