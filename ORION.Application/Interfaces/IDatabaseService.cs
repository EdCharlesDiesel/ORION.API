using ORION.DataAccess.Models;
using ORION.Sales.DataAccess.Entities;

namespace ORION.Application.Interfaces
{
    public interface IDatabaseService
    {
        //IDbSet<Customer> Customers { get; set; }

        //IDbSet<Employee> Employees { get; set; }
        
        //IDbSet<Product> Products { get; set; }
        
        //IDbSet<Sale> Sales { get; set; }

        void Save();
    }
}