namespace ORION.DataAccess.Services.Services
{
    public interface ILogger
    {
        void LogFeatureUsage(string featureName);
        void LogCustomerSatisfaction(string feedback);
    }
}
