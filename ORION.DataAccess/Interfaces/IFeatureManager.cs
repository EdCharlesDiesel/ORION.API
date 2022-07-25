namespace ORION.DataAccess.Interfaces
{
    public interface IFeatureManager
    {
        bool Search { get; }

        bool SearchByBirthBusinessProvince { get; }

        bool FeatureUsageLogging { get; }

        bool CustomerSatisfaction { get; }
    }
}
