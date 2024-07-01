namespace ORION.Core.GreadyAlgorithmns
{
    /// <summary>
    /// 
    /// </summary>
    public class ValidStartingCityClass
    {
        public int ValidStartingCity(int[] distances, int[] fuel, int mpg)
        {
            int numberOfCities= distances.Length;
            int milesRemaining = 0;

            int indexOfStartingCityCandidate = 0;
            int milesRemainingAtStartingCityCandidate = 0;

            for (int cityIndex  = 1;cityIndex< numberOfCities; cityIndex++)
            {
                int distanceFromPreviousCity = distances[cityIndex-1];
                int fuelFromPreviousCity= fuel[cityIndex -1];

                milesRemaining += fuelFromPreviousCity * mpg - distanceFromPreviousCity;

                if (milesRemaining< milesRemainingAtStartingCityCandidate)
                {
                    milesRemainingAtStartingCityCandidate = milesRemaining;
                    indexOfStartingCityCandidate = cityIndex;
                }
            }

            return indexOfStartingCityCandidate;
        }
    }
}