namespace GroupAnagrams.Tests
{
    public class UnitTest1
    {
        [Fact]
        public void Test1()
        {
            List<string> words = new List<string>(
    ) { "yo", "act", "flop", "tac", "foo", "cat", "oy", "olfp" };
            List<List<string>> expected = new List<List<string>>();
            expected.Add(new List<string>() { "yo", "oy" });
            expected.Add(new List<string>() { "flop", "olfp" });
            expected.Add(new List<string>() { "act", "tac", "cat" });
            expected.Add(new List<string>() { "foo" });
            List<List<string>> output = GroupAnagramsClass.groupAnagrams(words);
            foreach (List<string> innerList in output)
            {
                innerList.Sort();
            }
            Assert.True(compare(expected, output));
        }

        public bool compare(
    List<List<string>> expected, List<List<string>> output
  )
        {
            if (expected.Count != output.Count) return false;
            foreach (List<string> e in expected)
            {
                e.Sort();
                var found = false;
                foreach (List<string> o in output)
                {
                    if (e.SequenceEqual(o))
                    {
                        found = true;
                    }
                }

                if (!found) return false;
            }

            return true;
        }
    }
}

