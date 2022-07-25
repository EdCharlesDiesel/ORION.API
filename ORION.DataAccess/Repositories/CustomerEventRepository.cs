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
    public class CustomerEventRepository : ICustomerEventRepository
    {
        private OrionDbContext context;
        public CustomerEventRepository(OrionDbContext context)
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

        public async Task<IEnumerable<ICustomerEvent>> GetFirstN(int n)
        {
            return await context.CustomerEvents
                .OrderBy(m => m.Id)
                .Take(n)
                .ToListAsync();
        }

        public ICustomerEvent New(CustomerEventType type, int id, long oldVersion, long? newVersion=null)
        {
            var model = new CustomerEvent
            {
                Type = type,
                CustomerId = id,
                OldVersion = oldVersion,
                NewVersion = newVersion
            };
            context.CustomerEvents.Add(model);
            return model;
        }
    }
}
