
using ORION.Core.Arrays;


namespace TournamentWinner.Tests
{
    public class Tests
    {
        [Fact]
        public void Test1()
        {
            List<List<string>> competitions = new List<List<string>>();
            List<string> competition1 = new List<string> {
            "HTML", "C#"
             };

            List<string> competition2 = new List<string> {
            "C#", "Python"
            };

            List<string> competition3 = new List<string> {
            "Python", "HTML"
        };
            competitions.Add(competition1);
            competitions.Add(competition2);
            competitions.Add(competition3);
            List<int> results = new List<int> {
            0, 0, 1
        };
            string expected = "Python";
            var actual = new TournamentWinnerClass().TournamentWinner(competitions, results);
            Assert.True(expected == actual);
        }
    }
}