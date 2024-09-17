using DDD.ApplicationLayer;
using ORION.Domain.DTOs;

namespace ORION.Admin.Commands
{
    public class UpdateOrderCommand: ICommand
    {
        public UpdateOrderCommand(IOrderFullEditDto updates)
        {
            Updates = updates;
        }
        public IOrderFullEditDto Updates { get; private set; }
    }
}
