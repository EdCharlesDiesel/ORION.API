namespace ORION.Application.Sales.Commands.CreateSale
{
    public interface ICreateSaleCommand
    {
        void Execute(CreateSaleModel model);
    }
}