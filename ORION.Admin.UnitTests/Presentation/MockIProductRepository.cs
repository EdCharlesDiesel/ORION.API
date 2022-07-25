using System.Threading.Tasks;
using DDD.DomainLayer;
using ORION.Domain.Aggregates;
using ORION.Domain.IRepositories;
// FIXME Refactor Unit Test
namespace ORION.Admin.UnitTests.Presentation
{
    public class MockIProductRepository : IProductRepository
    {
        public MockIProductRepository()
        {
            IsDeleteCalled=false;
            IsGetCalled = false;
            IsNewCalled= false;
        }

        public  bool IsDeleteCalled
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

        public MockIProductRepository(IProduct resultSet) 
        {
            this.ResultSet = resultSet;
               
        }
                public IProduct ResultSet { get; set; }
        
        
        public IUnitOfWork UnitOfWork => throw new System.NotImplementedException();

    IUnitOfWork IRepository<IProduct>.UnitOfWork => throw new System.NotImplementedException();

    public async Task<IProduct> Delete(int id)
        {
            IsDeleteCalled = true;
            return  ResultSet;
        }

        public async Task<IProduct> Get(int id)
        {
            IsGetCalled = true;
            return ResultSet;
        }

        public IProduct New()
        {
            IsNewCalled = true;
            return ResultSet;
        }

    Task<IProduct> IProductRepository.Get(int id)
    {
        throw new System.NotImplementedException();
    }

    IProduct IProductRepository.New()
    {
        throw new System.NotImplementedException();
    }

    Task<IProduct> IProductRepository.Delete(int id)
    {
        throw new System.NotImplementedException();
    }

        public object GetAll()
        {
            throw new System.NotImplementedException();
        }

        public object GetById(int id)
        {
            throw new System.NotImplementedException();
        }
    }
}
