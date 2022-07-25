using DDD.ApplicationLayer;
using ORION.Admin.Models.Orders;

namespace ORION.Admin.Queries
{
    public interface IOrdersListQuery: IQuery
    {
        Task<IEnumerable<OrderInfosViewModel>> GetAllOrders();        
    }
}
