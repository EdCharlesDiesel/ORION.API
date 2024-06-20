using DDD.ApplicationLayer;

namespace COG.WEB.Commands
{
    public class DeleteProductCommand: ICommand
    {
        public DeleteProductCommand(int id)
        {
            ProductId = id;
        }
        public int ProductId { get; private set; }
    }
}
