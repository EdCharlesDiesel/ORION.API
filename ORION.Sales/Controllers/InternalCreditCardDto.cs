namespace ORION.Sales.Controllers
{
    public class InternalCreditCardDto
    {
        public object Id { get; internal set; }
        public object FirstName { get; internal set; }
        public object Salary { get; internal set; }
        public object LastName { get; internal set; }
        public object SuggestedBonus { get; internal set; }
        public object YearsInService { get; internal set; }
    }
}