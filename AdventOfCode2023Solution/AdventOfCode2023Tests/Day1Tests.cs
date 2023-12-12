using AdventOfCode2023;
using NUnit.Framework;

namespace AdventOfCode2023Tests
{
    public class Day1Tests
    {
        [Test]
        public void Day1Test()
        {
            var actual = new Day1().GetSumOfNumbers();
            Assert.That(actual == 230, $"Result = {actual}");
        }
    }
}