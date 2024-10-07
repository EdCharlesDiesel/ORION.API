using ORION.Domain.Aggregates;
using ORION.Domain.IRepositories;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ORION.Domain.Tools;


namespace ORION.DataAccess.Repositories
{
    public class ProductEventRepository : IProductEventRepository
    {
        //private OrionDbContext context;
        //public ProductEventRepository(OrionDbContext context)
        //{
        //    this.context = context;
        //}
        //public IUnitOfWork UnitOfWork => context;

        //public object GetAll()
        //{
        //    throw new NotImplementedException();
        //}

        //public object GetById(int id)
        //{
        //    throw new NotImplementedException();
        //}

        //public async Task<IEnumerable<IProductEvent>> GetFirstN(int n)
        //{
        //    return await context.ProductEvents
        //        .OrderBy(m => m.Id)
        //        .Take(n)
        //        .ToListAsync();
        //}

        //public IProductEvent New(ProductEventType type, int id, long oldVersion, long? newVersion=null, decimal unitPrice=0)
        //{
        //    var model = new ProductEvent
        //    {
        //        Type = type,
        //        ProductId = id,
        //        OldVersion = oldVersion,
        //        NewVersion = newVersion,
        //        NewUnitPrice = unitPrice
        //    };
        //    context.ProductEvents.Add(model);
        //    return model;
        //}
        public IUnitOfWork UnitOfWork { get; }
        public Task<IEnumerable<IProductEvent>> GetFirstN(int n)
        {
            throw new NotImplementedException();
        }

        public IProductEvent New(ProductEventType type, int id, long oldVersion, long? newVersion = null, decimal unitPrice = 0)
        {
            throw new NotImplementedException();
        }
    }
}
