using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using DDD.DomainLayer;
using ORION.Domain.Aggregates;
using ORION.Domain.Enums;
using ORION.Domain.Tools;
using ORION.Domain.Utility;

namespace ORION.DataAccess.Models
{
    // FIXME BusinessOwner
    public class BusinessOwner: Entity<int>,  IBusinessOwner,IValidatableObject
    {
      
        public void FullUpdate(IBusinessOwner o)
        {
            if (IsTransient())
            {
                Id = o.Id;
            }
            FirstName = o.FirstName;
            LastName = o.LastName;
            ImageFilename = o.ImageFilename;
            BirthDate = o.BirthDate;
            BusinessDate = o.BusinessDate;
            BirthCity = o.BirthCity;
            BirthProvince = o.BirthProvince;
            DaysInOffice = o.DaysInOffice;
            CreateDate = o.CreateDate;
            UpdateDate = o.UpdateDate;
            DeleteDate = o.DeleteDate;
            Status = o.Status;
        }
        public string FirstName { get; set; }

        [Display(Name = "Last Name")]
        [Required]
        [DisplayFormat(ConvertEmptyStringToNull = false)]
        
        public string LastName { get; set; }

        [DisplayFormat(ConvertEmptyStringToNull = false)]
        public string ImageFilename { get; set; }
        

        [Display(Name = "Date of Birth")]
        [DateTimePropertyCompareValidatorAttribute(
            DateTimeCompareTypeEnum.LessThan, nameof(BusinessDate))]
        [DisplayFormat(DataFormatString = "{0:d}")]
        
        public DateTime BirthDate { get; set; }

        [Display(Name = "Date of Business")]
        [DateTimePropertyCompareValidatorAttribute(
            DateTimeCompareTypeEnum.GreaterThan, nameof(BirthDate))]
        [DisplayFormat(DataFormatString = "{0:d}")]
        
        public DateTime BusinessDate { get; set; }

        [Display(Name = "Birth City")]
        [DisplayFormat(ConvertEmptyStringToNull = false)]
        
        public string BirthCity { get; set; }

        [Display(Name = "Birth Province")]
        [DisplayFormat(ConvertEmptyStringToNull = false)]
        
        public string BirthProvince { get; set; }

        [Display(Name = "Business City")]
        [DisplayFormat(ConvertEmptyStringToNull = false)]
        public string BusinessCity { get; set; }

        
        [Display(Name = "Business Province")]
        [DisplayFormat(ConvertEmptyStringToNull = false)]
        public string BusinessProvince { get; set; }

        
        [Display(Name = "Days In Office")]
        public int DaysInOffice { get; set; }
        
        private DateTime _createDate = DateTime.Now;
        
        public DateTime CreateDate { get => _createDate; set => _createDate = value; }

        public DateTime? UpdateDate { get; set; }

        public DateTime? DeleteDate { get; set; }

        private Status _status = Status.Active;
        
        public Status Status { get => _status; set => _status = value; }

        public List<Term> Terms { get; private set; }

        public void AddTerm(string role, DateTime startDate, DateTime endDate, int number)
        {
            Terms.Add(new Term()
            {
                Role = role,
                StartOfTerm = startDate,
                EndOfTerm = endDate,
                NumberOfTerms = number
            });
        }

        public IEnumerable<ValidationResult> Validate(
            ValidationContext validationContext)
        {
            if (Terms.Count == 0)
            {
                yield return
                    new ValidationResult("BusinessOwner has no terms.");
            }

            if (Terms.Count > 2)
            {
                yield return
                    new ValidationResult("BusinessOwner cannot have more than 2 terms.");
            }
        }
    }
}
