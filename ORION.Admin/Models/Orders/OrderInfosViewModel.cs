using ORION.Domain.Aggregates;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ORION.Admin.Models.Orders
{
    public class OrderInfosViewModel
    {
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public int? EmployeeId { get; set; }
        public DateTime? OrderDate { get; set; }
        public DateTime? RequiredDate { get; set; }
        public DateTime? ShippedDate { get; set; }
        public int? ShipVia { get; set; }
        public decimal? Freight { get; set; }
        public string ShipName { get; set; }
        public string ShipAddress { get; set; }
        public string ShipCity { get; set; }
        public string ShipRegion { get; set; }
        public string ShipPostalCode { get; set; }
        public string ShipCountry { get; set; }
        //TODO Fix ToString()
        // public int CategoryId { get; set; }
        // public override string ToString()
        // {
        //     return string.Format("{0}. {1} days in {2}, unit price: {3}",
        //         OrderName, DurationInDays, CategoryName, UnitPrice);
        // }
    }
}
