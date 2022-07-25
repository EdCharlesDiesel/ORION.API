using DDD.ApplicationLayer;
using ORION.Domain.DTOs;

namespace ORION.Admin.Commands
{
    public class UpdateOrderCommand: ICommand
    {
        public UpdateOrderCommand(IOrderFullEditDTO updates)
        {
            Updates = updates;
        }
        public IOrderFullEditDTO Updates { get; private set; }
    }
}
