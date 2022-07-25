using ORION.Domain.Aggregates;
using ORION.Domain.DTOs;
using System.ComponentModel.DataAnnotations;

namespace ORION.Admin.Models.Products
{
    public class ProductFullEditViewModel: IProductFullEditDTO
    {
        public ProductFullEditViewModel()
        {
        }

        public ProductFullEditViewModel(IProduct o)
        {
            Id = o.Id;
            CategoryId = o.CategoryId;
            ProductName = o.ProductName;
            Description = o.Description;
            CoverImage = o.CoverImage;
            UnitPrice = o.UnitPrice;
            DurationInDays = o.DurationInDays;
            StartValidityDate = o.StartValidityDate;
            EndValidityDate = o.EndValidityDate;
            Image = o.Image;
           // Status = o.Status;
        }

        // public ProductFullEditViewModel(int id, string productName, string description, decimal unitPrice, int durationInDays, string image, int categoryId) 
        // {
        //     this.Id = id;
        //     this.ProductName = productName;
        //     this.Description = description;
        //     this.UnitPrice = unitPrice;
        //     this.DurationInDays = durationInDays;
        //     this.Image = image;
        //     this.CategoryId = categoryId;               
        // }
                public int Id { get; set; }
        
        [StringLength(128, MinimumLength = 5), Required]
        [Display(Name = "Product Name")]
        public string ProductName { get; set; }
        
        [Display(Name = "Description")]
        [StringLength(128, MinimumLength = 10), Required]
        public string Description { get; set; }
        
        [Display(Name = "Unit price")]
        [Range(0, 100000)]
        public decimal UnitPrice { get; set; }
        
        [Display(Name = "Duration in days")]
        [Range(1, 90)]
        public int DurationInDays { get; set; }

        [Display(Name = "Image")]
        public string Image { get; set; }
        public byte[] CoverImage {get;set;}
        
        [Display(Name = "Available from"), Required]
        public DateTime? StartValidityDate { get; set; }
        
        [Display(Name = "Available to"), Required]
        public DateTime? EndValidityDate { get; set; }
        
        [Display(Name = "Category")]
        public int CategoryId { get; set; }

       // public string Status { get; set; }
        
    }
}
