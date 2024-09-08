using Microsoft.EntityFrameworkCore;
using ORION.DataAccess.SqlServer;

namespace ORION.Person.SqlServer
{
    public class SqlEntityFrameworkPersonRepository: SqlEntityFrameworkCrudRepositoryBase<Person, OrionDbContext>, IRepository<Person>
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

        public override IList<DataAccess.Entities.Person> GetAll()
        {
            return (
                from temp in EntityDbSet
                    .Include(x => x.Relationships)
                    .Include(p => p.Businesses)
                orderby temp.LastName, temp.FirstName
                select temp
                ).ToList();
        }

        public override DataAccess.Entities.Person GetById(int id)
        {
            throw new NotImplementedException();
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
