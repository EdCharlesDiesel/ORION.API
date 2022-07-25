using Microsoft.AspNetCore.Mvc;
using ORION.Admin.Models;
using ORION.DataAccess.Interfaces;
using ORION.DataAccess.Models;
using ORION.DataAccess.Services;

namespace ORION.Admin.Controllers
{
    public class SearchController : Controller
    {
        private IBusinessOwnerService _Service;
        private IFeatureManager _FeatureManager;

        public SearchController(IBusinessOwnerService service, 
            IFeatureManager featureManager)
        {
            if (service == null)
                throw new ArgumentNullException("service", "service is null.");
            if (featureManager == null)
                throw new ArgumentNullException("featureManager", "featureManager is null.");

            _Service = service;
            _FeatureManager = featureManager;
        }

        // GET: Search
        public ActionResult Index()
        {
            if (_FeatureManager.Search == false)
            {
                return NotFound();
            }

            var model = new SearchViewModel();

            if (_FeatureManager.SearchByBirthBusinessProvince == true)
            {
                return View("IndexProvinceSearch", model);
            }
            else
            {
                return View(model);
            }            
        }

        [HttpPost]
        public ActionResult Index(SearchViewModel model)
        {
            if (model == null)
            {
                throw new InvalidOperationException("Argument cannot be null.");
            }

            if (_FeatureManager.Search == false)
            {
                return NotFound();
            }

            // var results = _Service.Search(model.FirstName, model.LastName);

            IList<BusinessOwner>? results = null;

            if (_FeatureManager.SearchByBirthBusinessProvince == true)
            {
                results = _Service.Search(
                    model.FirstName, model.LastName,
                    model.BirthProvince, model.BusinessProvince);
            }
            else
            {
                results = _Service.Search(
                    model.FirstName, model.LastName);
            }

            var modelToReturn = new SearchViewModel();

            modelToReturn.FirstName = model.FirstName;
            modelToReturn.LastName = model.LastName;

            if (results != null)
            {
                Adapt(results, modelToReturn.Results);
            }

            if (_FeatureManager.SearchByBirthBusinessProvince == true)
            {
                return View("IndexProvinceSearch", modelToReturn);
            }
            else
            {
                return View(modelToReturn);
            }
        }

        private void Adapt(IList<BusinessOwner> fromValues, List<SearchResultRow> toValues)
        {
            if (fromValues == null)
                throw new ArgumentNullException("fromValues", "fromValues is null.");
            if (toValues == null)
                throw new ArgumentNullException("toValues", "toValues is null.");

            var adapter = new BusinessOwnerToSearchResultRowAdapter();

            SearchResultRow toValue;

            foreach (var fromValue in fromValues)
            {
                toValue = new SearchResultRow();

                adapter.Adapt(fromValue, toValue);

                toValues.Add(toValue);
            }
        }
    }
}