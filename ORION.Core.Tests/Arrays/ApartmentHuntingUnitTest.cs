namespace ApartmentHunting.Tests
{
    public class ApartmentHuntingUnitTest
    {
        [Fact]
        public void Test1()
        {
            List<Dictionary<string, bool>> blocks =
                 new List<Dictionary<string, bool>>();

            blocks.Insert(0, new Dictionary<string, bool>());
            blocks[0]["gym"] = false;
            blocks[0]["school"] = true;
            blocks[0]["store"] = false;

            blocks.Insert(1, new Dictionary<string, bool>());
            blocks[1]["gym"] = true;
            blocks[1]["school"] = false;
            blocks[1]["store"] = false;

            blocks.Insert(2, new Dictionary<string, bool>());
            blocks[2]["gym"] = true;
            blocks[2]["school"] = true;
            blocks[2]["store"] = false;

            blocks.Insert(3, new Dictionary<string, bool>());
            blocks[3]["gym"] = false;
            blocks[3]["school"] = true;
            blocks[3]["store"] = false;

            blocks.Insert(4, new Dictionary<string, bool>());
            blocks[4]["gym"] = false;
            blocks[4]["school"] = true;
            blocks[4]["store"] = true;

            string[] reqs = new string[] { "gym", "school", "store" };
            Assert.True(ApartmentHuntingClass.ApartmentHunting(blocks, reqs) == 3);
            Assert.True(ApartmentHuntingClass2.ApartmentHunting(blocks, reqs) == 3);
        }
    }
}