using System.Collections.Generic;
using System.Linq;
using DDD.DomainLayer;
using Microsoft.EntityFrameworkCore;
using ORION.DataAccess.Contexts;
using ORION.DataAccess.Models;

namespace ORION.DataAccess.SqlServer
{
    public class SqlEntityFrameworkPersonRepository : 
        SqlEntityFrameworkCrudRepositoryBase<Person, OrionDbContext>, IRepository<Person>
    {
        public SqlEntityFrameworkPersonRepository(
            OrionDbContext context) : base(context)
        {

        }

        protected override DbSet<Person> EntityDbSet
        {
            get
            {
                return Context.Persons;
            }
        }

        public override IList<Person> GetAll()
        {
            return (
                from temp in EntityDbSet
                    .Include(x => x.Relationships)
                    .Include(p => p.Businesses)
                orderby temp.LastName, temp.FirstName
                select temp
                ).ToList();
        }

        public override Person GetById(int id)
        {
            return (
                from temp in EntityDbSet
                    .Include(x => x.Relationships)
                        .ThenInclude(r1 => r1.ToPerson)
                    .Include(x => x.Relationships)
                        .ThenInclude(r => r.FromPerson)
                    .Include(p => p.Businesses)
                where temp.Id == id
                select temp
                ).FirstOrDefault();
        }
    }
}
