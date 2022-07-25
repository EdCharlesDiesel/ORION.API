using System;

namespace ORION.Tests.Common
{
    public static class UnitTestDataUtility
    {
        public static string GetUniqueValue(string prefix)
        {
            string fullValue = String.Format("{0}{1}", prefix, Guid.NewGuid());

            if (fullValue.Length > 20)
            {
                return fullValue.Substring(0, 20);
            }
            else
            {
                return fullValue;
            }
        }
    }
}
