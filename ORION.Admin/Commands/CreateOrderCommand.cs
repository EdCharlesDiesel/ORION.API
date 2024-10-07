using DDD.ApplicationLayer;
using ORION.Domain.DTOs;

namespace ORION.Admin.Commands
{
    public class CreateOrderCommand: ICommand
    {
        public CreateOrderCommand(IOrderFullEditDto values)
        {
            Values = values;
        }
        public IOrderFullEditDto Values { get; private set; }
    }
}
