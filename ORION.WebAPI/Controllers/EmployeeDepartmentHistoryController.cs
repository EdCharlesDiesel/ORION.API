using Asp.Versioning;
using AutoMapper;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ORION.Domain.IRepositories;
using ORION.WebAPI.Entities;
using ORION.WebAPI.Models;
using System.Text.Json;

namespace ORION.WebAPI.Controllers
{
   
    //[Authorize]
    [Route("api/employeedepartmenthistory")]
    [ApiController]
    //[ApiVersion(1)]
    //[ApiVersion(2)]
    public class EmployeeDepartmentHistoryController : ControllerBase
    {
        private readonly IEmployeeDepartmentHistoryRepository _iemployeeDepartmentHistoryRepository;
        private readonly IMapper _mapper;
        const int maxEmployeeDepartmentHistoryPageSize = 20;

        public EmployeeDepartmentHistoryController(IEmployeeDepartmentHistoryRepository iemployeeDepartmentHistoryRepository,
            IMapper mapper)
        {
            _iemployeeDepartmentHistoryRepository = iemployeeDepartmentHistoryRepository ??
                throw new ArgumentNullException(nameof(iemployeeDepartmentHistoryRepository));
            _mapper = mapper ??
                throw new ArgumentNullException(nameof(mapper));
        }

        /// <summary>
        /// Get a list of employement history.
        /// </summary>
        /// <param name="name"></param>
        /// <param name="searchQuery"></param>
        /// <param name="pageNumber"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        
        [HttpGet]        
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<IEnumerable<EmployeeDepartmentHistoryDto>>> GetEmployeeDepartmentHistory(
                    string? name, string? searchQuery, int pageNumber = 1, int pageSize = 10)
        {
            //if (pageSize > maxEmployeeDepartmentHistoryPageSize)
            //{
            //    pageSize = maxEmployeeDepartmentHistoryPageSize;
            //}

            //var (shiftEntities, paginationMetadata) = await _iemployeeDepartmentHistoryRepository
            //    .GetEmployeeDepartmentHistoryAsync(name, searchQuery, pageNumber, pageSize);

            //Response.Headers.Add("X-Pagination",
            //    JsonSerializer.Serialize(paginationMetadata));

            //return Ok(_mapper.Map<IEnumerable<ShiftWithoutEmployeeDepartmentHistoryDto>>(cityEntities));

            throw new NotFiniteNumberException();
        }

    
        //[HttpGet("{employeeDepartmentHistoryId}")]
        //[ProducesResponseType(StatusCodes.Status404NotFound)]
        //[ProducesResponseType(StatusCodes.Status400BadRequest)]
        //[ProducesResponseType(StatusCodes.Status200OK)]
        //public async Task<IActionResult> GetCity(
        //    int employeeDepartmentHistoryId, bool includeEmployee = false)
        //{
        //    var employeeDepartmentHistory = await _employeeDepartmentHistoryRepository.GetCityAsync(employeeDepartmentHistoryId, includeEmployee);
        //    if (employeeDepartmentHistory == null)
        //    {
        //        return NotFound();
        //    }

        //    if (includeEmployee)
        //    {
        //        return Ok(_mapper.Map<EmployeeDepartmentHistoryDto>(employeeDepartmentHistory));
        //    }

        //    return Ok(_mapper.Map<ShiftWithoutEmployeeDepartmentHistoryDto>(employeeDepartmentHistory));
        //}
    }
}
