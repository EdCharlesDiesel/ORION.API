using DDD.DomainLayer;
using ORION.Domain.Aggregates;
using ORION.Domain.IRepositories;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using ORION.DataAccess.Models;
using ORION.DataAccess.Contexts;
using ORION.Domain.Tools;


namespace ORION.DataAccess.Repositories
{
    public class ProductEventRepository : IProductEventRepository
    {
        private OrionDbContext context;
        public ProductEventRepository(OrionDbContext context)
        {
            this.context = context;
        }
        public IUnitOfWork UnitOfWork => context;

        public object GetAll()
        {
            throw new NotImplementedException();
        }

        public object GetById(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<IProductEvent>> GetFirstN(int n)
        {
            return await context.ProductEvents
                .OrderBy(m => m.Id)
                .Take(n)
                .ToListAsync();
        }

        public IProductEvent New(ProductEventType type, int id, long oldVersion, long? newVersion=null, decimal unitPrice=0)
        {
            var model = new ProductEvent
            {
                Type = type,
                ProductId = id,
                OldVersion = oldVersion,
                NewVersion = newVersion,
                NewUnitPrice = unitPrice
            };
            context.ProductEvents.Add(model);
            return model;
        }
    }
}
