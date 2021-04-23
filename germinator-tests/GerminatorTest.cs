using NUnit.Framework;
using germinator_lib;

namespace germinator_tests
{
    public class Tests
    {
        [Test]
        public void SingleLoopPerimiterOfFourByFourGrid_Cleans12Tiles()
        {
            var germinator = new Germinator();
            germinator.Move('N', 3);
            germinator.Move('E', 3);
            germinator.Move('S', 3);
            germinator.Move('W', 3);

            Assert.AreEqual(germinator.NumberOfTilesCleaned, 12);
        }

        [Test]
        public void DoubleLoopPerimiterOfFourByFourGrid_Cleans12Tiles()
        {
            var germinator = new Germinator();
            germinator.Move('N', 3);
            germinator.Move('E', 3);
            germinator.Move('S', 3);
            germinator.Move('W', 3);

            germinator.Move('N', 3);
            germinator.Move('E', 3);
            germinator.Move('S', 3);
            germinator.Move('W', 3);

            Assert.AreEqual(germinator.NumberOfTilesCleaned, 12);
        }

        [TestCase('N', 'S', 5, ExpectedResult = 6)]
        [TestCase('N', 'N', 5, ExpectedResult = 11)]
        [TestCase('N', 'E', 5, ExpectedResult = 11)]
        [TestCase('N', 'W', 5, ExpectedResult = 11)]
        [TestCase('E', 'W', 5, ExpectedResult = 6)]
        [TestCase('E', 'E', 5, ExpectedResult = 11)]
        [TestCase('E', 'N', 5, ExpectedResult = 11)]
        [TestCase('E', 'S', 5, ExpectedResult = 11)]
        public int PerformsTwoActions_CleansAsExpected(char firstDirection, char secondDirection, int numberOfSteps)
        {
            var germinator = new Germinator();
            germinator.Move(firstDirection, numberOfSteps);
            germinator.Move(secondDirection, numberOfSteps);

            return germinator.NumberOfTilesCleaned;
        }

        [Test]
        public void NoCommandsGiven_CleansInitialTile()
        {
            var germinator = new Germinator();
            var tilesCleaned = germinator.NumberOfTilesCleaned;
            Assert.AreEqual(tilesCleaned, 1);
        }
    }
}
