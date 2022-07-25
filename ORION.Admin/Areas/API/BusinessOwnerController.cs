
using Microsoft.AspNetCore.Mvc;
using ORION.DataAccess.Models;
using ORION.DataAccess.Services;

namespace ORION.Admin.Areas.API
{
    [Route("api/[controller]")]
    public class BusinessOwnerController : ControllerBase
    {
        private IBusinessOwnerService _Service;

        public BusinessOwnerController(IBusinessOwnerService service)
        {
            _Service = service;
        }

        // GET: api/BusinessOwner
        [HttpGet]
        public IEnumerable<BusinessOwner> Get()
        {
            return _Service.GetBusinessOwners();
        }

        // GET: api/BusinessOwner/5
        [HttpGet("{id}", Name = "Get")]
        public BusinessOwner Get(int id)
        {
            return _Service.GetBusinessOwnerById(id);
        }
    }
}
