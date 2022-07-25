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


namespace ORION.DataAccess.Repositories
{
    public class OrderEventRepository : IOrderEventRepository
    {
        private OrionDbContext context;
        public OrderEventRepository(OrionDbContext context)
        {
            this.context = context;
        }
        public IUnitOfWork UnitOfWork => context;

        public Task<IOrderEvent> Get(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<IOrderEvent>> GetFirstN(int n)
        {
            return await context.OrderEvents
                .OrderBy(m => m.Id)
                .Take(n)
                .ToListAsync();
        }

        public IOrderEvent New(OrderEventType type, int id, long oldVersion, long? newVersion=null)
        {
            var model = new OrderEvent
            {
                Type = type,
                OrderId = id,
                OldVersion = oldVersion,
                NewVersion = newVersion
            };
            context.OrderEvents.Add(model);
            return model;
        }

        public IOrderEvent New()
        {
            throw new NotImplementedException();
        }

        public IOrderEvent New(OrderEventType deleted)
        {
            throw new NotImplementedException();
        }
    }
}
