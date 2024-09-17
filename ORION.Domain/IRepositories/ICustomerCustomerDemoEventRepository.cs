using System.Threading.Tasks;
using ORION.Domain.Tools;

namespace ORION.Domain.IRepositories
{
    public interface ICustomerCustomerDemoEvent:IRepository<ICustomerCustomerDemoEvent>
    {
        Task<ICustomerCustomerDemoEvent> Get(int id);
        ICustomerCustomerDemoEvent New();
    }
}
