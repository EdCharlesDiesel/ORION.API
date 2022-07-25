using System.Threading.Tasks;
using DDD.DomainLayer;
using ORION.Domain.Aggregates;
using ORION.Domain.IRepositories;
// FIXME Refactor Unit Test
namespace ORION.Admin.UnitTests.Presentation
{
    public class MockIOrderRepository : IOrderRepository
    {
        public MockIOrderRepository()
        {
            IsDeleteCalled = false;
            IsGetCalled = false;
            IsNewCalled = false;
        }

        public bool IsDeleteCalled
        {
            get; private set;
        }

        public bool IsGetCalled
        {
            get; private set;
        }

        public bool IsNewCalled
        {
            get; private set;
        }

        // public MockIOrderRepository(IOrder resultSet)
        // {
        //     this.ResultSet = resultSet;

        // }
        // public MockIOrderRepository(IOrder resultSet) 
        // {
        //     this.ResultSet = resultSet;
               
        // }
                public IOrder ResultSet { get; set; }


        public IUnitOfWork UnitOfWork => throw new System.NotImplementedException();

        IUnitOfWork IRepository<IOrder>.UnitOfWork => throw new System.NotImplementedException();

        public async Task<IOrder> Delete(int id)
        {
            IsDeleteCalled = true;
            return ResultSet;
        }

        public async Task<IOrder> Get(int id)
        {
            IsGetCalled = true;
            return ResultSet;
        }

        public IOrder New()
        {
            IsNewCalled = true;
            return ResultSet;
        }

        Task<IOrder> IOrderRepository.Get(int id)
        {
            throw new System.NotImplementedException();
        }

        IOrder IOrderRepository.New()
        {
            throw new System.NotImplementedException();
        }

        Task IOrderRepository.Delete(int orderId)
        {
            throw new System.NotImplementedException();
        }

        // Task<IOrder> IOrderRepository.Delete(int id)
        // {
        //     throw new System.NotImplementedException();
        // }

        // public object GetAll()
        // {
        //     throw new System.NotImplementedException();
        // }

        // public object GetById(int id)
        // {
        //     throw new System.NotImplementedException();
        // }
    }
}
