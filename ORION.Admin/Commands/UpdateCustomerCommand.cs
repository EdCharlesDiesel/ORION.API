using DDD.ApplicationLayer;
using ORION.Domain.DTOs;


namespace ORION.Admin.Commands
{
    public class UpdateCustomerCommand: ICommand
    {
        public UpdateCustomerCommand(ICustomerFullEditDto updates)
        {
            Updates = updates;
        }
        public ICustomerFullEditDto Updates { get; private set; }
    }
}
