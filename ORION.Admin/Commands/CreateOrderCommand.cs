using DDD.ApplicationLayer;
using ORION.Domain.DTOs;

namespace ORION.Admin.Commands
{
    public class CreateOrderCommand: ICommand
    {
        public CreateOrderCommand(IOrderFullEditDTO values)
        {
            Values = values;
        }
        public IOrderFullEditDTO Values { get; private set; }
    }
}
