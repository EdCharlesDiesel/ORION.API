using DDD.ApplicationLayer;
using ORION.Domain.DTOs;

namespace ORION.Admin.Commands
{
    public class UpdateEmployeeCommand: ICommand
    {
        public UpdateEmployeeCommand(IEmployeeFullEditDto updates)
        {
            Updates = updates;
        }
        public IEmployeeFullEditDto Updates { get; private set; }
    }
}
