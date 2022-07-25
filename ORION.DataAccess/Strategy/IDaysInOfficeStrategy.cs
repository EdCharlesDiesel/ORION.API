using System.Collections.Generic;
using ORION.DataAccess.Models;

namespace ORION.DataAccess.Strategy
{
    public interface IDaysInOfficeStrategy
    {
         int GetDaysInOffice(IEnumerable<Term> terms);
    }
}