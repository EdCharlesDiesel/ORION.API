using System.Threading.Tasks;

namespace ORION.Admin.Controllers
{
    public interface ITestDataUtility
    {
        Task CreateBusinessOwnerTestData();
        Task VerifyDatabaseIsPopulated();
    }

}
