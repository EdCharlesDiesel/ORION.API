using System;
using System.Linq;
using System.Collections.Generic;
using ORION.DataAccess.Models;


namespace ORION.DataAccess.Strategy
{
    public class DefaultDaysInOfficeStrategy : IDaysInOfficeStrategy
    {
        public int GetDaysInOffice(IEnumerable<Term> terms)
        {
            var enumerable = terms as Term[] ?? terms.ToArray();
            if (terms == null || !enumerable.Any())
            {
                return 0;
            }
            else
            {
                int totalDays = 0;

                foreach (var term in enumerable)
                {
                    var diff = term.EndOfTerm - term.StartOfTerm;

                    totalDays += Convert.ToInt32(diff.TotalDays);
                }

                return totalDays;
            }
        }
    }
}
