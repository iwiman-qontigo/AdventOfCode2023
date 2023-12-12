using AdventOfCode2023;
using NUnit.Framework;

namespace AdventOfCode2023Tests
{
    public class Day1Tests
    {
        [Test]
        public void OneLineTest()
        {
            var input = @"two934seven1";

            var actual = new Day1().GetSumOfNumbers(input);
            var expected = 91;

            Assert.That(actual, Is.EqualTo(expected));
        }

        [Test]
        public void SmallSampleTest()
        {
            var input = @"two934seven1
                8825eightknfv
                sevenoneqbfzntsix55";

            var actual = new Day1().GetSumOfNumbers(input);
            var expected = 231;

            Assert.That(actual, Is.EqualTo(expected));
        }
    }
}