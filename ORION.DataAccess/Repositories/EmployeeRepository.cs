using DDD.DomainLayer;
using ORION.Domain.Aggregates;
using ORION.Domain.IRepositories;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using ORION.DataAccess.Models;
using ORION.Domain.Events;
using ORION.DataAccess.Contexts;
using ORION.Admin.Handlers;
using System;

namespace ORION.DataAccess.Repositories
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private OrionDbContext context;
        public EmployeeRepository(OrionDbContext context)
        {
            this.context = context;
        }
        public IUnitOfWork UnitOfWork => context;

        public async Task<IEmployee> Get(int id)
        {
            throw new NotImplementedException();
            //return await context.Employees.Where(m => m.Id == id)
            //    .FirstOrDefaultAsync();
        }

        public async Task<IEmployee> Delete(int id)
        {
            var model = await Get(id);
            if (model == null) return null;
            context.Employees.Remove(model as Employee);
            //model.AddDomainEvent(
            //    new EmployeeDeleteEvent(
            //        model.Id, (model as Employee).EntityVersion));
            return model;
        }

        public IEmployee New()
        {
            throw new NotImplementedException();            
            //var model = new Employee() { EntityVersion = 1 };
            //context.Employees.Add(model);
            //return model;
        }
    }
}
