using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DDD.DomainLayer;
using ORION.DataAccess.Models;
using ORION.DataAccess.Strategy;
using ORION.Domain.Utility;

namespace ORION.DataAccess.Services
{
    public class BusinessOwnerService : IBusinessOwnerService
    {
        private IRepository<Person> _RepositoryInstance;
        private IValidatorStrategy<BusinessOwner> _ValidatorInstance;

        private PersonToBusinessOwnerAdapter _Adapter;
        private IDaysInOfficeStrategy _DaysInOfficeStrategy;

        public BusinessOwnerService(
            IRepository<Person> personRepositoryInstance,
            IValidatorStrategy<BusinessOwner> validator,
            IDaysInOfficeStrategy daysInOfficeStrategy)
        {
            if (personRepositoryInstance == null)
                throw new ArgumentNullException("personRepositoryInstance", "personRepositoryInstance is null.");
            if (validator == null)
                throw new ArgumentNullException("validator", "Argument cannot be null.");

            _RepositoryInstance = personRepositoryInstance;
            _ValidatorInstance = validator;
            _Adapter = new PersonToBusinessOwnerAdapter();
            _DaysInOfficeStrategy = daysInOfficeStrategy;
        }

        public void Save(BusinessOwner saveThis)
        {
            if (saveThis == null)
                throw new ArgumentNullException("saveThis", "saveThis is null.");

            if (_ValidatorInstance.IsValid(saveThis) == false)
            {
                throw new InvalidOperationException("BusinessOwner is invalid.");
            }

            Person toValue;

            if (saveThis.Id == 0)
            {
                toValue = new Person();
            }
            // else
            // {
            //   //  toValue = _RepositoryInstance.GetById(saveThis.Id);

            //     if (toValue == null)
            //     {
            //         throw new InvalidOperationException(
            //             $"Could not locate a person with an id of '{saveThis.Id}'."
            //             );
            //     }
            // }

            // _Adapter.Adapt(saveThis, toValue);

            // _RepositoryInstance.Save(toValue);

            // remove terms that are marked for delete
            saveThis.Terms
                .Where(term => term.IsDeleted == true)
                .ToList()
                .ForEach(term => saveThis.Terms.Remove(term));

         //   saveThis.Id = toValue.Id;
        }

        public void DeleteBusinessOwnerById(int id)
        {
            //FIXME DeleteBusinessOwnerById
            throw new NotImplementedException();
            // var match = _RepositoryInstance.GetById(id);

            // if (match == null)
            // {
            //     throw new InvalidOperationException(
            //             $"Could not locate a person with an id of '{id}'."
            //             );
            // }
        //     else
        //     {
        //         _RepositoryInstance.Delete(match);
        //     }
         }

        public BusinessOwner GetBusinessOwnerById(int id)
        {
            //FIXME GetBusinessOwnerById
            // var match = _RepositoryInstance.GetById(id);

            // if (match == null)
            // {
            //     return null;
            // }
            // else
            // {
            //     return ToBusinessOwner(match);
            // }
            throw new NotImplementedException();
        }

        public IList<BusinessOwner> GetBusinessOwners()
        {
            //FIXME GetBusinessOwners
            //var allPeople = _RepositoryInstance.GetAll();

            // var peopleWhoWereBusinessOwner =
            //     (
            //     from temp in allPeople
            //     where temp.Facts.GetFact(BusinessOwnerConstants.BusinessOwner) != null
            //     select temp
            //     );

            // return ToBusinessOwners(peopleWhoWereBusinessOwner);
            throw new NotImplementedException();
        }

        private BusinessOwner ToBusinessOwner(Person fromValue)
        {
            var toValue = new BusinessOwner();

            _Adapter.Adapt(fromValue, toValue);

            return toValue;
        }

        private IList<BusinessOwner> ToBusinessOwners(IEnumerable<Person> peopleWhoWereBusinessOwner)
        {
            var returnValues = new List<BusinessOwner>();

            _Adapter.Adapt(peopleWhoWereBusinessOwner, returnValues);

            foreach (var businessOwner in returnValues)
            {
                businessOwner.DaysInOffice = 
                    _DaysInOfficeStrategy.GetDaysInOffice
                        (businessOwner.Terms);
            }

            return returnValues;
        }

        public IList<BusinessOwner> Search(
            string firstName, string lastName)
        {
            var allBusinessOwners = GetBusinessOwners();

            IEnumerable<BusinessOwner> returnValues =
                allBusinessOwners;

            if (String.IsNullOrWhiteSpace(firstName) == false)
            {
                returnValues =
                    returnValues.Where(p => p.FirstName.ToLower().Contains(firstName.ToLower()));
            }

            if (String.IsNullOrWhiteSpace(lastName) == false)
            {
                returnValues =
                    returnValues.Where(p => p.LastName.ToLower().Contains(lastName.ToLower()));
            }

            return returnValues.ToList();
        }

        public IList<BusinessOwner> Search(string firstName, string lastName, string birthProvince, string deathProvince)
        {
            var allBusinessOwners = GetBusinessOwners();

            IEnumerable<BusinessOwner> returnValues =
                allBusinessOwners;

            if (String.IsNullOrWhiteSpace(firstName) == false)
            {
                returnValues =
                    returnValues.Where(p => p.FirstName.ToLower().Contains(firstName.ToLower()));
            }

            if (String.IsNullOrWhiteSpace(lastName) == false)
            {
                returnValues =
                    returnValues.Where(p => p.LastName.ToLower().Contains(lastName.ToLower()));
            }

            if (String.IsNullOrWhiteSpace(birthProvince) == false)
            {
                returnValues =
                    returnValues.Where(p => p.BirthProvince != null && p.BirthProvince.ToLower().Contains(birthProvince.ToLower()));
            }

            if (String.IsNullOrWhiteSpace(deathProvince) == false)
            {
                returnValues =
                    returnValues.Where(p => p.BusinessProvince != null && p.BusinessProvince.ToLower().Contains(deathProvince.ToLower()));
            }

            return returnValues.ToList();
        }
    }
}
