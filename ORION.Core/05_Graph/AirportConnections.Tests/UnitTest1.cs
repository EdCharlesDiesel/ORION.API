namespace AirportConnections.Tests
{
    public class UnitTest1
    {
        List<string> AIRPORTS = new List<string>() {
                    "BGI","CDG","DEL","DOH",
                    "DSM","EWR","EYW","HND",
                    "ICN","JFK","LGA","LHR",
                    "ORD","SAN","SFO","SIN",
                    "TLV","BUD"
                  };

        string STARTING_AIRPORT = "LGA";

        [Fact]
        public void TestCase1()
        {
            List<List<string>> routes = new List<List<string>>();
            routes.Add(new List<string>() { "DSM", "ORD" });
            routes.Add(new List<string>() { "ORD", "BGI" });
            routes.Add(new List<string>() { "BGI", "LGA" });
            routes.Add(new List<string>() { "SIN", "CDG" });
            routes.Add(new List<string>() { "CDG", "SIN" });
            routes.Add(new List<string>() { "CDG", "BUD" });
            routes.Add(new List<string>() { "DEL", "DOH" });
            routes.Add(new List<string>() { "DEL", "CDG" });
            routes.Add(new List<string>() { "TLV", "DEL" });
            routes.Add(new List<string>() { "EWR", "HND" });
            routes.Add(new List<string>() { "HND", "ICN" });
            routes.Add(new List<string>() { "HND", "JFK" });
            routes.Add(new List<string>() { "ICN", "JFK" });
            routes.Add(new List<string>() { "JFK", "LGA" });
            routes.Add(new List<string>() { "EYW", "LHR" });
            routes.Add(new List<string>() { "LHR", "SFO" });
            routes.Add(new List<string>() { "SFO", "SAN" });
            routes.Add(new List<string>() { "SFO", "DSM" });
            routes.Add(new List<string>() { "SAN", "EYW" });
            Assert.True(AirportConnectionsClass.AirportConnections(AIRPORTS, routes, STARTING_AIRPORT) == 3);
        }
    }
}
