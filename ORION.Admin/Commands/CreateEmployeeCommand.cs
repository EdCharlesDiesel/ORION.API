using DDD.ApplicationLayer;
using ORION.Domain.DTOs;

namespace ORION.Admin.Commands
{
    public class CreateEmployeeCommand: ICommand
    {
        public CreateEmployeeCommand(IEmployeeFullEditDto values)
        {
            Values = values;
        }
        public IEmployeeFullEditDto Values { get; private set; }
    }
}
