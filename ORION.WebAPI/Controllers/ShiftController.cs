using Asp.Versioning;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using ORION.WebAPI.Models;
using ORION.WebAPI.Services;

namespace ORION.WebAPI.Controllers
{
    [Route("api/v{version:apiVersion}/shifts/{shiftId}/employeedepartmenthistory")]
    //[Authorize(Policy = "MustBeFromAntwerp")]
    [ApiVersion(2)]
    [ApiController]
    public class ShiftController : ControllerBase
    {
        private readonly ILogger<ShiftController> _logger;
        private readonly IMailService _mailService;
        private readonly IShiftRepository _shiftRepository;
        private readonly IMapper _mapper;

        public ShiftController(ILogger<ShiftController> logger,
            IMailService mailService,
            IShiftRepository shiftRepository,
            IMapper mapper)
        {
            _logger = logger ??
                throw new ArgumentNullException(nameof(logger));
            _mailService = mailService ??
                throw new ArgumentNullException(nameof(mailService));
            _shiftRepository = shiftRepository ??
                throw new ArgumentNullException(nameof(shiftRepository));
            _mapper = mapper ??
                throw new ArgumentNullException(nameof(mapper));
        }

        /// <summary>
        /// Get shift 
        /// </summary>
        /// <param name="shiftId"></param>
        /// <returns></returns>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<EmployeeDepartmentHistoryDto>>> GetShift(
            int shiftId)
        {
            if (!await _shiftRepository.ShiftExistsAsync(shiftId))
            {
                _logger.LogInformation(
                    $"Shift with id {shiftId} wasn't found when accessing employee department history.");
                return NotFound();
            }

            var employeeDepartmentHistoryForShift = await _shiftRepository.GetEmployeeDepartmentHistoryForShiftAsync(shiftId);

            return Ok(_mapper.Map<IEnumerable<EmployeeDepartmentHistoryDto>>(employeeDepartmentHistoryForShift));
        }

        //[HttpGet("{pointofinterestid}", Name = "GetPointOfInterest")]
        //public async Task<ActionResult<PointOfInterestDto>> GetPointOfInterest(
        //    int cityId, int pointOfInterestId)
        //{
        //    if (!await _shiftRepository.CityExistsAsync(cityId))
        //    {
        //        return NotFound();
        //    }

        //    var pointOfInterest = await _shiftRepository
        //        .GetPointOfInterestForCityAsync(cityId, pointOfInterestId);

        //    if (pointOfInterest == null)
        //    {
        //        return NotFound();
        //    }

        //    return Ok(_mapper.Map<PointOfInterestDto>(pointOfInterest));
        //}

        //[HttpPost]
        //public async Task<ActionResult<PointOfInterestDto>> CreatePointOfInterest(
        //       int cityId,
        //       PointOfInterestForCreationDto pointOfInterest)
        //{
        //    if (!await _shiftRepository.CityExistsAsync(cityId))
        //    {
        //        return NotFound();
        //    }

        //    var finalPointOfInterest = _mapper.Map<Entities.PointOfInterest>(pointOfInterest);

        //    await _shiftRepository.AddPointOfInterestForCityAsync(
        //        cityId, finalPointOfInterest);

        //    await _shiftRepository.SaveChangesAsync();

        //    var createdPointOfInterestToReturn =
        //        _mapper.Map<Models.EmployeeDepartmentHistoryDto>(finalPointOfInterest);

        //    return CreatedAtRoute("GetPointOfInterest",
        //         new
        //         {
        //             cityId = cityId,
        //             pointOfInterestId = createdPointOfInterestToReturn.Id
        //         },
        //         createdPointOfInterestToReturn);
        //}

        //[HttpPut("{pointofinterestid}")]
        //public async Task<ActionResult> UpdatePointOfInterest(int cityId, int pointOfInterestId,
        //    PointOfInterestForUpdateDto pointOfInterest)
        //{
        //    if (!await _shiftRepository.CityExistsAsync(cityId))
        //    {
        //        return NotFound();
        //    }

        //    var pointOfInterestEntity = await _shiftRepository
        //        .GetPointOfInterestForCityAsync(cityId, pointOfInterestId);
        //    if (pointOfInterestEntity == null)
        //    {
        //        return NotFound();
        //    }

        //    _mapper.Map(pointOfInterest, pointOfInterestEntity);

        //    await _shiftRepository.SaveChangesAsync();

        //    return NoContent();
        //}

        //[HttpPatch("{pointofinterestid}")]
        //public async Task<ActionResult> PartiallyUpdatePointOfInterest(
        //   int cityId, int pointOfInterestId,
        //   JsonPatchDocument<PointOfInterestForUpdateDto> patchDocument)
        //{

        //    if (!await _shiftRepository.CityExistsAsync(cityId))
        //    {
        //        return NotFound();
        //    }

        //    var pointOfInterestEntity = await _shiftRepository
        //        .GetPointOfInterestForCityAsync(cityId, pointOfInterestId);
        //    if (pointOfInterestEntity == null)
        //    {
        //        return NotFound();
        //    }

        //    var pointOfInterestToPatch = _mapper.Map<PointOfInterestForUpdateDto>(
        //        pointOfInterestEntity);

        //    patchDocument.ApplyTo(pointOfInterestToPatch, ModelState);

        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }

        //    if (!TryValidateModel(pointOfInterestToPatch))
        //    {
        //        return BadRequest(ModelState);
        //    }

        //    _mapper.Map(pointOfInterestToPatch, pointOfInterestEntity);
        //    await _shiftRepository.SaveChangesAsync();

        //    return NoContent();
        //}

        //[HttpDelete("{pointOfInterestId}")]
        //public async Task<ActionResult> DeletePointOfInterest(
        //    int cityId, int pointOfInterestId)
        //{
        //    if (!await _shiftRepository.CityExistsAsync(cityId))
        //    {
        //        return NotFound();
        //    }

        //    var pointOfInterestEntity = await _shiftRepository
        //        .GetPointOfInterestForCityAsync(cityId, pointOfInterestId);
        //    if (pointOfInterestEntity == null)
        //    {
        //        return NotFound();
        //    }

        //    _shiftRepository.DeletePointOfInterest(pointOfInterestEntity);
        //    await _shiftRepository.SaveChangesAsync();

        //    _mailService.Send(
        //        "Point of interest deleted.",
        //        $"Point of interest {pointOfInterestEntity.Name} with id {pointOfInterestEntity.Id} was deleted.");

        //    return NoContent();
        //}

    }
}
