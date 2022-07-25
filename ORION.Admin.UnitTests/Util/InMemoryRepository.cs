using System;
using System.Collections.Generic;
using System.Linq;
using DDD.DomainLayer;

namespace ORION.Admin.UnitTests.Util
{
    // TODO Investigate
   // public class InMemoryRepository<T> : IRepository<T> where T : IInt32Identity
   public class InMemoryRepository<T> : IRepository<T> where T : Entity<int>
    {
        private int _CurrentIdentityValue = 0;

        public InMemoryRepository()
        {
            Items = new List<T>();
        }

        public List<T> Items
        {
            get;
            set;
        }

        public IUnitOfWork UnitOfWork => throw new NotImplementedException();

        public IList<T> GetAll()
        {
            return Items;
        }

        public T GetById(int id)
        {
            return (from temp in Items where temp.Id == id select temp).FirstOrDefault();
        }

        public void Save(T saveThis)
        {
            if (saveThis == null)
            {
                throw new ArgumentNullException("saveThis", "Argument cannot be null.");
            }

            if (saveThis.Id == 0)
            {
                // assign new identity value
                saveThis.Id = GetNextIdValue();
            }

            if (Items.Contains(saveThis) == false)
            {
                Items.Add(saveThis);
            }
        }

        public void Delete(T deleteThis)
        {
            if (deleteThis == null)
            {
                throw new ArgumentNullException("deleteThis", "Argument cannot be null.");
            }

            if (Items.Contains(deleteThis) == true)
            {
                Items.Remove(deleteThis);
            }
        }

        protected int GetNextIdValue()
        {
            return ++_CurrentIdentityValue;
        }
    }
}
