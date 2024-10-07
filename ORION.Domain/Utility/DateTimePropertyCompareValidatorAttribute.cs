using System;
using System.ComponentModel.DataAnnotations;
using System.Reflection;
using ORION.Domain.Enums;

namespace ORION.Domain.Utility
{
    public class DateTimePropertyCompareValidatorAttribute
        : ValidationAttribute
    {
        private readonly DateTimeCompareTypeEnum _compareType;
        private readonly string _otherPropertyName;

        public DateTimePropertyCompareValidatorAttribute(
            DateTimeCompareTypeEnum compareType,
            string otherPropertyName)
        {
            _compareType = compareType;
            _otherPropertyName = otherPropertyName;
        }
        protected override ValidationResult IsValid(
            object value,
            ValidationContext validationContext)
        {
            if (value == null)
            {
                return new ValidationResult("Value cannot be null.");
            }


            DateTime valueAsDateTime;

            if (value is DateTime)
            {
                valueAsDateTime = (DateTime)value;
            }
            else
            {
                var valueAsString = value.ToString();

                if (String.IsNullOrWhiteSpace(valueAsString) == true)
                {
                    return new ValidationResult("Value cannot be blank.");
                }

                if (DateTime.TryParse(valueAsString, out valueAsDateTime) == false)
                {
                    return new ValidationResult("Value is not a DateTime.");
                }
            }

            object otherValue = null;

            PropertyInfo otherPropertyInfo =
                validationContext.ObjectType.GetProperty(_otherPropertyName);

            if (otherPropertyInfo == null)
            {

                return new ValidationResult("Invalid property name for other property.");
            }
            else
            {
                otherValue = otherPropertyInfo.GetValue(validationContext.ObjectInstance);
            }

            if (otherValue == null)
            {
                return new ValidationResult("Other property value not specified.");
            }

            DateTime otherValueAsDateTime;

            if (otherValue is DateTime)
            {
                otherValueAsDateTime = (DateTime)otherValue;
            }
            else
            {
                if (DateTime.TryParse(otherValue.ToString(), out otherValueAsDateTime) == false)
                {
                    return new ValidationResult("Other value is not a DateTime.");
                }
            }

            if (_compareType == DateTimeCompareTypeEnum.GreaterThan)
            {
                if (valueAsDateTime == default(DateTime) ||
                    valueAsDateTime > otherValueAsDateTime)
                {
                    return ValidationResult.Success;
                }
                else
                {
                    return new ValidationResult(
                        String.Format(
                            "{0} should be greater than {1}.",
                            validationContext.DisplayName,
                            _otherPropertyName));
                }
            }
            else
            {
                if (otherValueAsDateTime == default(DateTime) ||
                    valueAsDateTime < otherValueAsDateTime)
                {
                    return ValidationResult.Success;
                }
                else
                {
                    return new ValidationResult(
                        String.Format(
                            "{0} should be less than {1}.",
                            validationContext.DisplayName,
                            _otherPropertyName));
                }
            }
        }

    }
}