using ORION.Core.FamousAlgorithms;

namespace ORION.Core.Tests
{
    public class KruskalsAlgorithmClassUnitTest
    {
        [Fact]
        public void Test1()
        {
            var input = new int[][][] {
              new int[][] { new int[] { 1, 1 } }, new int[][] { new int[] { 0, 1 } }
            };
            var expected = new int[][][] {
              new int[][] { new int[] { 1, 1 } }, new int[][] { new int[] { 0, 1 } }
            };
            var actual = new KruskalsAlgorithmClass().KruskalsAlgorithm(input);
            Assert.True(jaggedArrayDeepEqual(expected, actual));
        }

        public bool jaggedArrayDeepEqual(dynamic a, dynamic b)
        {
            if (ReferenceEquals(a, b))
            {
                return true;
            }

            if (ReferenceEquals(a, null) || ReferenceEquals(b, null))
            {
                return false;
            }

            if (!a.GetType().IsArray || !b.GetType().IsArray)
            {
                return Equals(a, b);
            }

            if (a.Length == b.Length)
            {
                for (int i = 0; i < a.Length; i++)
                {
                    if (!jaggedArrayDeepEqual(a[i], b[i]))
                    {
                        return false;
                    }
                }
                return true;
            }
            return false;
        }
    }
}