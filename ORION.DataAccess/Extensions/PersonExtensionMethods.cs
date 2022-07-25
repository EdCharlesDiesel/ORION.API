using System;
using System.Collections.Generic;
using System.Linq;
using ORION.DataAccess.Models;

namespace ORION.Domain.Extensions
{
    public static class PersonExtensionMethods
    {
        public static PersonBusiness GetBusiness(
            this IList<PersonBusiness> businesses,
            string businessType)
        {
            var returnValue = (
                from temp in businesses
                where temp.BusinessType == businessType
                select temp
                ).FirstOrDefault();

            return returnValue;
        }

        public static IList<PersonBusiness> GetBusinesses(
            this IList<PersonBusiness> businesses,
            string businessType)
        {
            var returnValue = (
                from temp in businesses
                where temp.BusinessType == businessType
                select temp
                ).ToList();

            return returnValue;
        }

        // GetBusinessValueAsString

        public static string GetBusinessValueAsString(
            this IList<PersonBusiness> businesses,
            string businessType)
        {
            var temp = businesses.GetBusiness(businessType);

            if (temp == null)
            {
                return null;
            }
            else
            {
                return temp.BusinessValue;
            }
        }

        public static DateTime GetBusinessValueAsDateTime(
            this IList<PersonBusiness> businesses,
            string businessType)
        {
            var temp = businesses.GetBusiness(businessType);

            if (temp == null)
            {
                return default(DateTime);
            }
            else
            {
                return temp.StartDate;
            }
        }
    }
}
