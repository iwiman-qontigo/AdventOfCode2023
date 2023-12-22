namespace AdventOfCode2023
{
    public static class Day2Part2
    {
        /// <summary>
        /// Given a set of <see langword="string"/> lines each referencing a game, this method gives the sum of powers of 
        /// every game, where the power of a game is the multiplication of the amount of cubes of each color.
        /// </summary>
        /// <param name="input">The lines.</param>
        /// <returns>
        /// The sum of the powers of every game.
        /// </returns>
        public static int Day2Part2Main(string input)
        {
            var gamePowers = new List<int>();
            
            using (var reader = new StringReader(input))
            {
                string? rawLine;
                while ((rawLine = reader.ReadLine()) != null)
                {
                    var line = rawLine.Trim();

                    var minimumQuantities = GetMinimumQuantities(line);

                    gamePowers.Add(minimumQuantities["red"] * minimumQuantities["green"] * minimumQuantities["blue"]);
                }
            }

            var sumOfGamePowers = gamePowers.Sum();
            return sumOfGamePowers;
        }

        private static Dictionary<string, int> GetMinimumQuantities(string line)
        {
            var minimumQuantities = new Dictionary<string, int>
            {
                ["red"] = 0,
                ["green"] = 0,
                ["blue"] = 0,
            };

            var gameSegment = line.Split(":")[1];

            var samples = gameSegment.Split(";");

            foreach (var sample in samples)
            {
                var colorSamples = sample.Split(",");
                foreach (var colorSample in colorSamples)
                {
                    var colorSampleTrimmed = colorSample.Trim();

                    var color = colorSampleTrimmed.Split(" ")[1];
                    var quantity = int.Parse(colorSampleTrimmed.Split(" ")[0]);

                    if (quantity > minimumQuantities[color])
                    {
                        minimumQuantities[color] = quantity;
                    }
                }
            }

            return minimumQuantities;
        }
    }
}
