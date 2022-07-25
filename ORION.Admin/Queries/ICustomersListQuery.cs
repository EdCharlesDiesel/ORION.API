using DDD.ApplicationLayer;
using ORION.Admin.Models.Customers;

namespace ORION.Admin.Queries
{
    public interface ICustomersListQuery: IQuery
    {
        Task<IEnumerable<CustomerInfosViewModel>> GetAllCustomers();
        
    }
}
