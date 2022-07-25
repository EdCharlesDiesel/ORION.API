using ORION.Domain.Aggregates;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ORION.Admin.Models.Products
{
    public class ProductInfosViewModel
    {
        public int Id { get; set; }
        public string Image { get; set; }
        public string ProductName { get; set; }
        public decimal UnitPrice { get; set; }
        public int DurationInDays { get; set; }
        public DateTime? StartValidityDate { get; set; }
        public DateTime? EndValidityDate { get; set; }
        public string CategoryName { get; set; }
        public int CategoryId { get; set; }
        public override string ToString()
        {
            return string.Format("{0}. {1} days in {2}, unit price: {3}",
                ProductName, DurationInDays, CategoryName, UnitPrice);
        }
    }
}
