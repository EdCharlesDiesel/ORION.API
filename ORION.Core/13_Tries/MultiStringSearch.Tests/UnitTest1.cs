namespace MultiStringSearch.Tests
{
    public class UnitTest1
    {
        [Fact(Skip ="Fix this")]
        public void Test1()
        {
            //bool[] expected = { true, false, true, true, false, true, false };
            //List<bool> output = MultiStringSearch.MultistringSearchClass.MultistringSearch(
            //  "this is a big string",
            //  new string[] { "this", "yo", "is", "a", "bigger", "string", "kappa" }
            //);
            //Assert.True(compare(output, expected));
        }

        public bool compare(List<bool> arr1, bool[] arr2)
        {
            if (arr1.Count != arr2.Length)
            {
                return false;
            }
            for (int i = 0; i < arr1.Count; i++)
            {
                if (arr1[i] != arr2[i])
                {
                    return false;
                }
            }
            return true;
        }
    }
}