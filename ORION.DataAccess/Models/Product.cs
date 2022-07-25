using DDD.DomainLayer;
using ORION.Domain.Aggregates;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System;
using ORION.Domain.Extensions;
using ORION.Domain.Enums;
using ORION.Domain.DTOs;
using Microsoft.AspNetCore.Http;
using ORION.Domain.Events;

namespace ORION.DataAccess.Models
{
    public class Product: Entity<int>, IProduct
    {
        public void FullUpdate(IProductFullEditDTO o)
        {
            if (IsTransient())
            {
                Id = o.Id;
                CategoryId = o.CategoryId;
            }
            else
            {
                if (o.UnitPrice != this.UnitPrice)
                    this.AddDomainEvent(new ProductUnitPriceChangedEvent(
                            Id, o.UnitPrice, EntityVersion, EntityVersion + 1));
            }
            ProductName = o.ProductName;
            Description = o.Description;
            UnitPrice = o.UnitPrice;
            DurationInDays = o.DurationInDays;
            StartValidityDate = o.StartValidityDate;
            EndValidityDate = o.EndValidityDate;
            Image = o.Image;
        }

        [Required, MinLength(2, ErrorMessage = "Minimum length is 2"),MaxLength(128, ErrorMessage  = "Maximum length is 128")]
        [Display(Name="Product Name")]
        public string ProductName { get; set; }

        [Required, MinLength(2, ErrorMessage = "Minimum length is 2")]
        public string Description { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal UnitPrice { get; set; }

        // FIXME Fix the upload feature
        //public string Image { get; set; } 

        private string _image = "Default_Image.jpeg";
        public string Image { get => _image; set => _image = value; }

        [NotMapped]
        [FileExtension]
        public IFormFile ImageUpload { get; set; }

        public int DurationInDays { get; set; }

        public byte[] CoverImage {get;set;}

        public DateTime? StartValidityDate { get; set; }

        public DateTime? EndValidityDate { get; set; }

        [Display(Name = "Category")]
        [Range(1, int.MaxValue, ErrorMessage = "You must to choose a category")]
        public int CategoryId { get; set; }
        
        [ForeignKey("CategoryId")]
        public virtual Category Category { get; set; }

        [ConcurrencyCheck]
        public long EntityVersion{ get; set; }

        private DateTime _createDate = DateTime.Now;
        public DateTime CreateDate { get => _createDate; set => _createDate = value; }

        public DateTime? UpdateDate { get; set; }

        public DateTime? DeleteDate { get; set; }

        private Status _status = Status.Active;
        public Status Status { get => _status; set => _status = value; }
    }

    // [Serializable]
    // public class UploadedFile : IUploadedFile
    // {
        
    // }

    // public IUploadedFile DeepCopy()
    // {
    //     if (!this.GetType().IsSerializable)
    //     throw new Exception("The object is not serializable!");
    //     BinaryFormatter formatter = new BinaryFormatter();
    //     MemoryStream ms = new MemoryStream();
    //     formatter.Serialize(ms, this);
    //     ms.Seek(0, SeekOrigin.Begin);
    //     IUploadedFile deepcopy = (IUploadedFile)formatter.Deserialize(ms);
    //     ms.Close();
    //     return deepcopy;
    // }
}

        

        

       

        

        
