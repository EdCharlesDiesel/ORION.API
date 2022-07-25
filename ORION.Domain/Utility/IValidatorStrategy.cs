using System;
using System.Collections.Generic;
using System.Text;

namespace ORION.Domain.Utility
{
    public interface IValidatorStrategy<T>
    {
        bool IsValid(T validateThis);
    }
}
