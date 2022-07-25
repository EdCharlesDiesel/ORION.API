using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using ORION.Domain.Utility;
using ORION.DataAccess.Models;
using ORION.DataAccess.Services;
using ORION.Domain.Constants;


namespace ORION.Admin.Controllers
{

    // [Authorize(Roles = SecurityConstants.RoleName_Admin)]
    public class BusinessOwnerController : Controller
    {
        private const int ID_FOR_CREATE_NEW_BUSINESSOWNER = 0;
        private IBusinessOwnerService _BusinessOwnerService;
        private IValidatorStrategy<BusinessOwner> _Validator;
        private ITestDataUtility _TestDataUtility;

        public BusinessOwnerController(IBusinessOwnerService businessOwnerService,
            IValidatorStrategy<BusinessOwner> validator,
            ITestDataUtility testDataUtility
            )
        {
            if (businessOwnerService == null)
                throw new ArgumentNullException("service", "service is null.");

            if (validator == null)
            {
                throw new ArgumentNullException("validator", "Argument cannot be null.");
            }

            _Validator = validator;
            _BusinessOwnerService = businessOwnerService;
            _TestDataUtility = testDataUtility;
        }

        [AllowAnonymous]
        public ActionResult Index()
        {
            var businessOwners = _BusinessOwnerService.GetBusinessOwners();

            return View(businessOwners);
        }

        [AllowAnonymous]
        [Route("/[controller]/[action]/{id}")]
        [Route("/businessOwner/{id}.aspx")]
        public ActionResult Details(int? id)
        {
            if (id == null || id.HasValue == false)
            {
                return new BadRequestResult();
            }

            var businessOwner = _BusinessOwnerService.GetBusinessOwnerById(id.Value);

            if (businessOwner == null)
            {
                return NotFound();
            }

            return View(businessOwner);
        }

        [Route("/businessOwner/{last:alpha}/{first:alpha}")]
        public ActionResult Details(string last, string first)
        {
            if (String.IsNullOrWhiteSpace(last) == true ||
                String.IsNullOrWhiteSpace(first) == true)
            {
                return new BadRequestResult();
            }

            var businessOwner = _BusinessOwnerService.Search(
                first, last).FirstOrDefault();

            if (businessOwner == null)
            {
                return NotFound();
            }

            return View("Details", businessOwner);
        }

        public ActionResult Create()
        {
            return RedirectToAction("Edit", new { id = ID_FOR_CREATE_NEW_BUSINESSOWNER });
        }

        // [Authorize(Roles = SecurityConstants.RoleName_Admin)]
        [Authorize(Policy = SecurityConstants.PolicyName_EditBusinessOwner)]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new BadRequestResult();
            }

            BusinessOwner businessOwner;

            if (id.Value == ID_FOR_CREATE_NEW_BUSINESSOWNER)
            {
                // create new
                businessOwner = new BusinessOwner();
                businessOwner.AddTerm(BusinessOwnerConstants.BusinessOwner,
                    default(DateTime),
                    default(DateTime), 0);
            }
            else
            {
                businessOwner = _BusinessOwnerService.GetBusinessOwnerById(id.Value);
            }

            if (businessOwner == null)
            {
                return NotFound();
            }

            return View(businessOwner);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        // [Authorize(Roles = SecurityConstants.RoleName_Admin)]
        [Authorize(Policy = SecurityConstants.PolicyName_EditBusinessOwner)]
        public ActionResult Edit(BusinessOwner businessOwner)
        {
            if (_Validator.IsValid(businessOwner) == true)
            {
                bool isCreateNew = false;

                if (businessOwner.Id == ID_FOR_CREATE_NEW_BUSINESSOWNER)
                {
                    isCreateNew = true;
                }
                else
                {
                    BusinessOwner toValue =
                        _BusinessOwnerService.GetBusinessOwnerById(businessOwner.Id);

                    if (toValue == null)
                    {
                        return new BadRequestObjectResult(
                            String.Format("Unknown businessOwner id '{0}'.", businessOwner.Id));
                    }
                }

                _BusinessOwnerService.Save(businessOwner);

                if (isCreateNew == true)
                {
                    RedirectToAction("Edit", new { id = businessOwner.Id });
                }
                else
                {
                    return RedirectToAction("Edit");
                }
            }

            return View(businessOwner);
        }

        //[AllowAnonymous]
        public async Task<ActionResult> ResetDatabase()
        {
            await _TestDataUtility.CreateBusinessOwnerTestData();

            return RedirectToAction("Index");
        }

        //[AllowAnonymous]
        public ActionResult VerifyDatabaseIsPopulated()
        {
            _TestDataUtility.VerifyDatabaseIsPopulated();

            return RedirectToAction("Index");
        }
    }
}