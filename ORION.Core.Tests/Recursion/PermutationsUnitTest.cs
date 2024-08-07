using System.Collections.Generic;
using System.Linq;

namespace Permutations.Tests
{
    public class PermutationsUnitTests
    {
    

        [Fact]
        public void Test1()
        {
            List<int> input = new List<int>()
            {
                1, 2, 3, 4
            };

            //List<List<int>> permutations = Permutations.GetPermutations(input);

            //Assert.IsTrue(Contains(permutations, new List<int>()
            //{
            //    1,2,3,4
            //}));


        }

        public bool Contains(List<List<int>> arrayOne,List<int> arrayTwo)
        {
            foreach (List<int> sunArray in arrayOne)
            {
                if (sunArray.SequenceEqual(arrayTwo))
                {
                    return true;
                }
            }
            return false;
        }
    }
}