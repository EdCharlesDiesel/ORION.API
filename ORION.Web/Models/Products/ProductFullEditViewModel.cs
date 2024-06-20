using ORION.Domain.Aggregates;
using ORION.Domain.DTOs;
using System;
using System.ComponentModel.DataAnnotations;

namespace COG.WEB.Models.Products
{
    public class ProductFullEditViewModel: IProductFullEditDTO
    {
        public ProductFullEditViewModel() { }
        public ProductFullEditViewModel(IProduct o)
        {
            Id = o.Id;
            CategoryId = o.CategoryId;
            ProductName = o.ProductName;
            CoverImage = o.CoverImage;
            Description = o.Description;
            UnitPrice = o.UnitPrice;
            DurationInDays = o.DurationInDays;
            StartValidityDate = o.StartValidityDate;
            EndValidityDate = o.EndValidityDate;
            Image = Image;
        }
        public int Id { get; set; }

        public string Image { get; set; }
        
        public byte[] CoverImage {get;set;}
        
        [StringLength(128, MinimumLength = 5), Required]
        [Display(Name = "name")]
        public string ProductName { get; set; }
        
        [Display(Name = "package infos")]
        [StringLength(128, MinimumLength = 10), Required]
        public string Description { get; set; }
        
        [Display(Name = "price")]
        [Range(0, 100000)]
        public decimal UnitPrice { get; set; }
        
        [Display(Name = "duration in days")]
        [Range(1, 90)]
        public int DurationInDays { get; set; }
        
        [Display(Name = "available from"), Required]
        public DateTime? StartValidityDate { get; set; }
        
        [Display(Name = "available to"), Required]
        public DateTime? EndValidityDate { get; set; }
        
        [Display(Name = "destination")]
        public int CategoryId { get; set; }
    }
}
