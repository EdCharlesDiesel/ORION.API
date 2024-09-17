using System.Threading.Tasks;
using ORION.Domain.Aggregates;
using ORION.Domain.IRepositories;
using ORION.Domain.Tools;

namespace ORION.DataAccess.Repositories
{
    public class CustomerRepository : ICustomerRepository
    {
        //private OrionDbContext context;
        //public CustomerRepository(OrionDbContext context)
        //{
        //    this.context = context;
        //}
        //public IUnitOfWork UnitOfWork => context;

        //public async Task<ICustomer> Get(int id)
        //{
        //    return await context.Customers.Where(m => m.Id == id)
        //        .FirstOrDefaultAsync();
        //}

        //public async Task<ICustomer> Delete(int id)
        //{
        //    var model = await Get(id);
        //    if (model == null) return null;
        //    context.Customers.Remove(model as Customer);
        //    model.AddDomainEvent(
        //        new CustomerDeleteEvent(
        //            model.Id, (model as Customer).EntityVersion));
        //    return model;
        //}

        //public ICustomer New()
        //{
        //    var model = new Customer() { EntityVersion = 1 };
        //    context.Customers.Add(model);
        //    return model;
        //}

        //public object GetAll()
        //{
        //    throw new System.NotImplementedException();
        //}

        //public object GetById(int id)
        //{
        //    throw new System.NotImplementedException();
        //}
        public IUnitOfWork UnitOfWork { get; }
        public Task<ICustomer> Get(int id)
        {
            throw new System.NotImplementedException();
        }

        public ICustomer New()
        {
            throw new System.NotImplementedException();
        }

        public Task Delete(int customerId)
        {
            throw new System.NotImplementedException();
        }
    }
}
