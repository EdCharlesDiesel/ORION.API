using ORION.DataAccess.Models;

namespace ORION.Admin.Models
{
    public class BusinessOwnerToSearchResultRowAdapter
    {
        public void Adapt(BusinessOwner fromValue, SearchResultRow toValue)
        {
            if (fromValue == null)
                throw new ArgumentNullException("fromValue", "fromValue is null.");
            if (toValue == null)
                throw new ArgumentNullException("toValue", "toValue is null.");

            toValue.Id = fromValue.Id;
            toValue.LastName = fromValue.LastName;
            toValue.FirstName = fromValue.FirstName;
        }
    }
}
