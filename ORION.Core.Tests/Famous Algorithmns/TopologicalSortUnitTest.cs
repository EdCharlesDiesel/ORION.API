using ORION.Core.FamousAlgorithms;

namespace ORION.Core.Tests
{
    public class TopologicalSortUnitTest
    {
        [Fact]
        public void Test1()
        {
            List<int> jobs = new List<int>() { 1, 2, 3, 4 };
            int[,] depsArray =
              new int[,] { { 1, 2 }, { 1, 3 }, { 3, 2 }, { 4, 2 }, { 4, 3 } };
            List<int[]> deps = new List<int[]>();
            fillDeps(depsArray, deps);
            List<int> order = TopologicalSortClass.TopologicalSort(jobs, deps);
            Assert.True(isValidTopologicalOrder(order, jobs, deps) == true);
        }

        void fillDeps(int[,] depsArray, List<int[]> deps)
        {
            for (int x = 0; x < depsArray.GetLength(0); x++)
            {
                var arr = new int[depsArray.GetLength(1)];
                for (int y = 0; y < depsArray.GetLength(1); y++)
                {
                    arr[y] = depsArray[x, y];
                }
                deps.Add(arr);
            }
        }

        bool isValidTopologicalOrder(
   List<int> order, List<int> jobs, List<int[]> deps
 )
        {
            Dictionary<int, bool> visited = new Dictionary<int, bool>();
            foreach (int candidate in order)
            {
                foreach (int[] dep in deps)
                {
                    if (candidate == dep[0] && visited.ContainsKey(dep[1])) return false;
                }
                visited.Add(candidate, true);
            }
            foreach (int job in jobs)
            {
                if (!visited.ContainsKey(job)) return false;
            }
            return order.Count == jobs.Count;
        }
    }
}