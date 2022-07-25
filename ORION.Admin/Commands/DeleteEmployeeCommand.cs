using DDD.ApplicationLayer;

namespace ORION.Admin.Commands
{
    public class DeleteEmployeeCommand: ICommand
    {
        public DeleteEmployeeCommand(int id)
        {
            EmployeeId = id;
        }
        public int EmployeeId { get; private set; }
    }
}
