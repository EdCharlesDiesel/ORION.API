using System;
using System.ComponentModel.DataAnnotations;
using ORION.Domain.Aggregates;
using ORION.Domain.Enums;
using ORION.Domain.Tools;

namespace ORION.DataAccess.Models
{
    public class Feature : Entity<int>, IFeature
    {
        public void FullUpdate(IFeature o)
        {
           if (IsTransient())
            {
                Id = o.Id;
            }
            FeatureName = o.FeatureName;
            IsEnabled = o.IsEnabled;
            Username = o.Username;
            
        }

        [Display(Name = "Feature Name")]
        [Required]
        [DisplayFormat(ConvertEmptyStringToNull = false)]
        public string FeatureName { get; set; }

        [Display(Name = "Is Enabled")]
        public bool IsEnabled { get; set; }

        [Display(Name = "For Username")]
        [DisplayFormat(ConvertEmptyStringToNull = false)]
        public string Username { get; set; }


       private DateTime _createDate = DateTime.Now;
        
        public DateTime CreateDate { get => _createDate; set => _createDate = value; }

        public DateTime? UpdateDate { get; set; }

        public DateTime? DeleteDate { get; set; }

        private Status _status = Status.Active;
        
        public Status Status { get => _status; set => _status = value; }

       
    }
}
