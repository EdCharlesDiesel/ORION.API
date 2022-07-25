using System;
using System.Collections.Generic;
using ORION.DataAccess.Models;
using ORION.Domain.Constants;
using ORION.Domain.Extensions;
using System.Linq;

namespace ORION.DataAccess.Services
{
    public class PersonToBusinessOwnerAdapter
    {

        public PersonToBusinessOwnerAdapter()
        {

        }

        public void Adapt(IEnumerable<Person> fromValues, IList<BusinessOwner> toValues)
        {
            if (fromValues == null)
                throw new ArgumentNullException("fromValues", "fromValues is null.");

            BusinessOwner toValue;

            foreach (var fromValue in fromValues)
            {
                toValue = new BusinessOwner();

                Adapt(fromValue, toValue);

                toValues.Add(toValue);
            }
        }

        public void Adapt(Person fromValue, BusinessOwner toValue)
        {
            if (fromValue == null)
                throw new ArgumentNullException("fromValue", "fromValue is null.");
            if (toValue == null)
                throw new ArgumentNullException("toValue", "toValue is null.");

            //FIXME fromValueId
            toValue.Id = fromValue.Id;
            toValue.FirstName = fromValue.FirstName;
            toValue.LastName = fromValue.LastName;

            toValue.ImageFilename = fromValue.Businesses.GetBusinessValueAsString(
                BusinessOwnerConstants.ImageFilename);

            toValue.BirthCity = fromValue.Businesses.GetBusinessValueAsString(
                BusinessOwnerConstants.BirthCity);

            toValue.BirthDate = fromValue.Businesses.GetBusinessValueAsDateTime(
                BusinessOwnerConstants.BirthDate);

            toValue.BusinessProvince = fromValue.Businesses.GetBusinessValueAsString(
                BusinessOwnerConstants.BirthProvince);

            toValue.BusinessCity = fromValue.Businesses.GetBusinessValueAsString(
                BusinessOwnerConstants.BusinessCity);

            toValue.BusinessDate = fromValue.Businesses.GetBusinessValueAsDateTime(
                BusinessOwnerConstants.BusinessDate);

            toValue.BusinessProvince = fromValue.Businesses.GetBusinessValueAsString(
                BusinessOwnerConstants.BusinessProvince);

            // FIXME later need to fix
            // var businessList = fromValue.Businesses.GetBusiness(BusinessOwnerConstants.BusinessOwner);

            // foreach (var fromBusiness in businessList.ToList()
            //     )
            // {
            //     var temp = new Term();

            //     temp.Id = fromBusiness.Id;
            //     temp.Role = fromBusiness.BusinessType;
            //     temp.StartOfTerm = fromBusiness.StartDate;
            //     temp.EndOfTerm = fromBusiness.EndDate;
            //     temp.NumberOfTerms = SafeToInt32(fromBusiness.BusinessValue, -1);

            //     toValue.Terms.Add(temp);
            // }
        }

        private int SafeToInt32(string valueAsString, int defaultInt32Value)
        {
            int temp;

            if (Int32.TryParse(valueAsString, out temp) == false)
            {
                return defaultInt32Value;
            }
            else
            {
                return temp;
            }
        }

        private void AdaptBusiness(BusinessOwner fromValue, Person toValue)
        {
            AdaptValueToPersonBusiness(fromValue.ImageFilename,
                            toValue,
                            BusinessOwnerConstants.ImageFilename);

            AdaptValueToPersonBusiness(fromValue.BirthCity,
                toValue,
                BusinessOwnerConstants.BirthCity);

            AdaptValueToPersonBusiness(fromValue.BirthDate,
                toValue,
                BusinessOwnerConstants.BirthDate);

            AdaptValueToPersonBusiness(fromValue.BirthProvince,
                toValue,
                BusinessOwnerConstants.BirthProvince);

            AdaptValueToPersonBusiness(fromValue.BusinessCity,
                toValue,
                BusinessOwnerConstants.BusinessCity);

            AdaptValueToPersonBusiness(fromValue.BusinessDate,
                toValue,
                BusinessOwnerConstants.BusinessDate);

            AdaptValueToPersonBusiness(fromValue.BusinessProvince,
                toValue,
                BusinessOwnerConstants.BusinessProvince);
        }

        public void Adapt(BusinessOwner fromValue, Person toValue)
        {
            if (fromValue == null)
                throw new ArgumentNullException("fromValue", "fromValue is null.");
            if (toValue == null)
                throw new ArgumentNullException("toValue", "toValue is null.");
        
            toValue.Id = fromValue.Id;
            toValue.FirstName = fromValue.FirstName;
            toValue.LastName = fromValue.LastName;

            if (fromValue.Id == 0)
            {
                toValue.Businesses.Clear();
            }

            AdaptBusiness(fromValue, toValue);

            AdaptTerms(fromValue, toValue);
        }

        private static void AdaptTerms(BusinessOwner fromValue, Person toValue)
        {
            foreach (var fromTerm in fromValue.Terms)
            {
                if (fromTerm.IsDeleted == false)
                {
                    toValue.AddBusiness(fromTerm.Id,
                        fromTerm.Role,
                        fromTerm.NumberOfTerms.ToString(),
                        fromTerm.StartOfTerm,
                        fromTerm.EndOfTerm
                        );
                }
                else if (fromTerm.IsDeleted == true && fromTerm.Id > 0)
                {
                    toValue.RemoveBusiness(fromTerm.Id);
                }
            }
        }
        public void AdaptValueToPersonBusiness(string fromValue,
        Person toPerson, 
            string toPersonBusinessType)
        {
            toPerson.AddBusiness(toPersonBusinessType, fromValue);
        }

        public void AdaptValueToPersonBusiness(DateTime fromValue,
            Person toPerson,
            string toPersonBusinessType)
        {
            toPerson.AddBusiness(toPersonBusinessType, fromValue);
        }
    }
}
