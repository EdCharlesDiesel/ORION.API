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
            if (terms == null || terms.Count() == 0)
            {
                return 0;
            }
            else
            {
                int totalDays = 0;

                foreach (var term in terms)
                {
                    var diff = term.EndOfTerm - term.StartOfTerm;

                    totalDays += Convert.ToInt32(diff.TotalDays);
                }

                return totalDays;
            }
        }
    }
}
