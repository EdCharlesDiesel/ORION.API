using ORION.DataAccess.Models;
using ORION.Sales.DataAccess.Entities;

namespace ORION.Application.Sales.Commands.CreateSale.Factory
{
    public class SaleFactory : ISaleFactory
    {
        public SalesPerson Create(DateTime date, Customer customer, Employee employee, Product product, int quantity)
        {
            var sale = new SalesPerson();

            //sale.Date = date;

            //sale.Customer = customer;

            //sale.Employee = employee;

            //sale.Product = product;

            //sale.UnitPrice = sale.Product.Price;

            //sale.Quantity = quantity;

            // Note: Total price is calculated in domain logic

            return sale;
        }
    }

    public class Product
    {
    }
}
