using System.Threading.Tasks;
using DDD.DomainLayer;
using ORION.Domain.Tools;

namespace DDD.ApplicationLayer
{
    public interface IEventHandler
    {
    }
    public interface IEventHandler<T>: IEventHandler
    where T : IEventNotification
    {
        Task HandleAsync(T ev);
    }
}
