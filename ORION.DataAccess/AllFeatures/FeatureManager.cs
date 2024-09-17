namespace ORION.DataAccess.AllFeatures
{
    public class FeatureManager : IFeatureManager
    {
        //private IUsernameProvider _UsernameProvider;

        //public FeatureManager(IFeatureRepository repository, IUsernameProvider usernameProvider)
        //{
        //    if (usernameProvider == null)
        //        throw new ArgumentNullException(nameof(usernameProvider), $"{nameof(usernameProvider)} is null.");
        //    if (repository == null)
        //    {
        //        throw new ArgumentNullException("repository", "Argument cannot be null.");
        //    }

        //    _UsernameProvider = usernameProvider;

        //    Initialize(repository);
        //}
        
        //private FeatureManager(IList<Feature> features)
        //{ 
        //    if (features == null)
        //        throw new ArgumentNullException("features", "features is null.");

        //    Initialize(features);
        //}

        //private Dictionary<string, bool> _FeatureConfigurations;

        //public Dictionary<string, bool> FeatureConfigurations
        //{
        //    get
        //    {
        //        if (_FeatureConfigurations == null)
        //        {
        //            _FeatureConfigurations = new Dictionary<string, bool>();
        //        }

        //        return _FeatureConfigurations;
        //    }
        //}

        //private void Initialize(IList<Feature> features)
        //{
        //    foreach (var feature in features)
        //    {
        //        if (FeatureConfigurations.ContainsKey(feature.FeatureName) == true)
        //        {
        //            FeatureConfigurations.Remove(feature.FeatureName);
        //        }

        //        FeatureConfigurations.Add(feature.FeatureName, feature.IsEnabled);
        //    }
        //}

        //private bool IsEnabled(string featureName, bool defaultValue)
        //{
        //    if (FeatureConfigurations.ContainsKey(featureName) == true)
        //    {
        //        return FeatureConfigurations[featureName];
        //    }
        //    else
        //    {
        //        return defaultValue;
        //    }
        //}

        //public bool CustomerSatisfaction
        //{
        //    get
        //    {
        //        return IsEnabled("CustomerSatisfaction", false);
        //    }
        //}

        //public bool FeatureUsageLogging
        //{
        //    get
        //    {
        //        return IsEnabled("FeatureUsageLogging", false);
        //    }
        //}

        //public bool PerformanceCounters
        //{
        //    get
        //    {
        //        return IsEnabled("PerformanceCounters", false);
        //    }
        //}

        //public bool Search
        //{
        //    get
        //    {
        //        return IsEnabled("Search", true);
        //    }
        //}

        //public bool SearchByBirthBusinessProvince
        //{
        //    get
        //    {
        //        return IsEnabled("SearchByBirthBusinessProvince", false);
        //    }
        //}

  

        //private void Initialize(IFeatureRepository repository)
        //{
        //    string username = _UsernameProvider.GetUsername();

        //    Initialize(repository, username);
        //}

        //private void Initialize(IFeatureRepository repository, string username)
        //{
        //    try
        //    {
        //        var features = repository.GetByUsername(username);
                
        //     // FIXME Needs fixing will attend later
        //    //     if (String.IsNullOrWhiteSpace(username) == false)
        //    //     {
        //    //         var featuresForThisUser =
        //    //             (
        //    //             from temp in features
        //    //             where String.IsNullOrWhiteSpace(temp.Username) == false
        //    //             select temp
        //    //             ).ToList();

        //    //         foreach (var userSpecificFeature in featuresForThisUser)
        //    //         {
        //    //             // if there's a user-specific feature config, remove the non-user-specific feature
        //    //             RemoveGenericUserFeatureConfiguration(features, userSpecificFeature);
        //    //         }
        //    //     }
        //    //    Initialize(features);
        //    }
        //    catch (SqlException)
        //    {
        //        Console.WriteLine("FeatureManager got a SqlException.");
        //    }
        //}

        //private void RemoveGenericUserFeatureConfiguration(IList<Feature> features, Feature userSpecificFeature)
        //{
        //    var match = (from temp in features
        //                 where temp.FeatureName == userSpecificFeature.FeatureName && temp.Username == String.Empty
        //                 select temp).FirstOrDefault();

        //    if (match != null)
        //    {
        //        features.Remove(match);
        //    }
        //}
    }

    public interface IFeatureManager
    {
    }
}
