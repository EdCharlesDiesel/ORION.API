using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using DDD.DomainLayer;
using ORION.Domain.Aggregates;
using ORION.Domain.Constants;
using ORION.Domain.DTOs;
using ORION.Domain.Enums;
// FIXME this class needsWork
namespace ORION.DataAccess.Models
{
    public class Person : Entity<int>, IPerson
    {
        private static readonly DateTime DEFAULT_DATE_VALUE = DateTime.MinValue;

        public Person()
        {
            FirstName = String.Empty;
            LastName = String.Empty;
        }

        public void FullUpdate(IPersonFullEditDTO o)
        {
            if (IsTransient())
            {
                Id = o.Id;
                // PersonBusinessId = o.PersonBusinessId;
                // PersonBusinessId = o.RelationshipId;

            }
            FirstName = o.FirstName;
            LastName = o.LastName;

        }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        [NotMapped]
        public virtual List<PersonBusiness> Businesses { get; set; }
        [NotMapped]
        public virtual List<Relationship> Relationships { get; set; }

        public void AddRelationship(string relationshipType, Person person)
        {
            if (string.IsNullOrEmpty(relationshipType))
                throw new ArgumentException("relationshipType is null or empty.", "relationshipType");
            if (person == null)
                throw new ArgumentNullException("person", "person is null.");

            var relationship = new Relationship();

            relationship.ToPerson = person;
            relationship.FromPerson = this;
            relationship.RelationshipType = relationshipType;

            Relationships.Add(relationship);
        }

        public void AddBusiness(string businessOwnerType, string businessOwnerValue)
        {
            AddBusiness(0, businessOwnerType, businessOwnerValue, DEFAULT_DATE_VALUE, DEFAULT_DATE_VALUE);
        }

        public void AddBusiness(string businessOwnerType, DateTime businessOwnerDate)
        {
            AddBusiness(businessOwnerType, businessOwnerDate, businessOwnerDate);
        }

        public void AddBusiness(int id, string businessOwnerType, DateTime businessOwnerStartDate, DateTime businessOwnerEndDate)
        {
            AddBusiness(id, businessOwnerType, businessOwnerType, businessOwnerStartDate, businessOwnerEndDate);
        }

        public void AddBusiness(string businessOwnerType, DateTime businessOwnerStartDate, DateTime businessOwnerEndDate)
        {
            AddBusiness(0, businessOwnerType, businessOwnerType, businessOwnerStartDate, businessOwnerEndDate);
        }

        private bool AllowDuplicateBusinessType(string businessOwnerType)
        {
            if (businessOwnerType == BusinessOwnerConstants.BusinessOwner)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public void RemoveBusiness(int id)
        {
            if (id == 0)
            {
                return;
            }
            else
            {
                 var match = Businesses.Where(businessOwner => businessOwner.Id == id).FirstOrDefault();

                if (match != null)
                {
                    Businesses.Remove(match);
               }
           }
        }

        private void UpdateExistingBusinessById(int id, string businessOwnerType, string businessOwnerValue, DateTime businessOwnerStartDate, DateTime businessOwnerEndDate)
        {
            PersonBusiness businessOwner = null;

            bool foundIt = false;

            if (id != 0)
            {
                // locate existing businessOwner 
                businessOwner = (from temp in Businesses
                        where temp.Id == id
                        select temp).FirstOrDefault();
            }

            if (businessOwner == null)
            {
                businessOwner = new PersonBusiness();

                businessOwner.Person = this;
                businessOwner.Id = id;
            }
            else
            {
                foundIt = true;
            }

            businessOwner.BusinessType = businessOwnerType;
            businessOwner.BusinessValue = businessOwnerValue;
            businessOwner.StartDate = businessOwnerStartDate;
            businessOwner.EndDate = businessOwnerEndDate;

            if (foundIt == false)
            {
                Businesses.Add(businessOwner);
            }
        }

        private void UpdateExistingBusinessByBusinessType(int id, string businessOwnerType, string businessOwnerValue, DateTime businessOwnerStartDate, DateTime businessOwnerEndDate)
        {
            bool foundIt = false;

            // locate existing businessOwner 
            PersonBusiness businessOwner = (from temp in Businesses
                               where temp.BusinessType == businessOwnerType
                               select temp).FirstOrDefault();

            if (businessOwner == null)
            {
                businessOwner = new PersonBusiness();

                businessOwner.Person = this;
                businessOwner.Id = id;
            }
            else
            {
                foundIt = true;
            }

            businessOwner.BusinessType = businessOwnerType;
            businessOwner.BusinessValue = businessOwnerValue;
            businessOwner.StartDate = businessOwnerStartDate;
            businessOwner.EndDate = businessOwnerEndDate;

            if (foundIt == false)
            {
                Businesses.Add(businessOwner);
            }
        }

        public void AddNewBusiness(int id, string businessOwnerType, string businessOwnerValue, DateTime businessOwnerStartDate, DateTime businessOwnerEndDate)
        {
            var businessOwner = new PersonBusiness();

            businessOwner.Person = this;
            businessOwner.Id = id;

            businessOwner.BusinessType = businessOwnerType;
            businessOwner.BusinessValue = businessOwnerValue;
            businessOwner.StartDate = businessOwnerStartDate;
            businessOwner.EndDate = businessOwnerEndDate;

            Businesses.Add(businessOwner);
        }

        public void AddBusiness(string businessOwnerType, string businessOwnerValue, DateTime businessOwnerStartDate, DateTime businessOwnerEndDate)
        {
            AddBusiness(0, businessOwnerType, businessOwnerValue, businessOwnerStartDate, businessOwnerEndDate);
        }

        public void AddBusiness(int id, string businessOwnerType, string businessOwnerValue, DateTime businessOwnerStartDate, DateTime businessOwnerEndDate)
        {
            if (string.IsNullOrEmpty(businessOwnerType))
                throw new ArgumentException("businessOwnerType is null or empty.", "businessOwnerType");

            if (businessOwnerValue == null)
            {
                throw new ArgumentNullException("businessOwnerValue", "Argument cannot be null.");
            }

            if (id != 0)
            {
                UpdateExistingBusinessById(id, businessOwnerType, businessOwnerValue, businessOwnerStartDate, businessOwnerEndDate);
            }
            else if (AllowDuplicateBusinessType(businessOwnerType) == false)
            {
                UpdateExistingBusinessByBusinessType(id, businessOwnerType, businessOwnerValue, businessOwnerStartDate, businessOwnerEndDate);
            }
            else
            {
                AddNewBusiness(id, businessOwnerType, businessOwnerValue, businessOwnerStartDate, businessOwnerEndDate);
            }
        }

        private DateTime _createDate = DateTime.Now;
        
        public DateTime CreateDate { get => _createDate; set => _createDate = value; }

        public DateTime? UpdateDate { get; set; }

        public DateTime? DeleteDate { get; set; }

        private Status _status = Status.Active;
        
        public Status Status { get => _status; set => _status = value; }
    }
}
