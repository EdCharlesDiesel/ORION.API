using ORION.DataAccess.Models;
using ORION.HumanResources.DataAccess.Entities;
using ORION.Sales.DataAccess.Entities;

namespace ORION.Application.Sales.Commands.CreateSale.Factory
{
    public interface ISaleFactory
    {
        Sale Create(DateTime date, Customer customer, Employee employee, Product product, int quantity);
    }
}