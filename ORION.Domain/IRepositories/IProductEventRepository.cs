using DDD.DomainLayer;
using ORION.Domain.Aggregates;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using ORION.Domain.Tools;

namespace ORION.Domain.IRepositories
{
    public interface IProductEventRepository:IRepository<IProductEvent>
    {
        Task<IEnumerable<IProductEvent>> GetFirstN(int n);
        IProductEvent New(ProductEventType type, int id, long oldVersion, long? newVersion= null, decimal unitPrice = 0);
    }
}
