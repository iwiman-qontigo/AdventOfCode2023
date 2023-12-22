namespace AdventOfCode2023
{
    public static class Day2Part1
    {
        public static int Day2Part1Main(string input)
        {
            var gameIds = new List<int>();
            
            using (var reader = new StringReader(input))
            {
                string? rawLine;
                while ((rawLine = reader.ReadLine()) != null)
                {
                    var line = rawLine.Trim();
                    
                    var isPossible = IsGamePossible(line);

                    if (isPossible)
                    {
                        gameIds.Add(GetGameId(line));
                    }
                }
            }

            var sumOfGameIds = gameIds.Sum();
            return sumOfGameIds;
        }

        private static int GetGameId(string line)
        {
            var idSegment = line.Split(':')[0];
            var gameId = idSegment.Split(" ")[1];

            return int.Parse(gameId);
        }

        private static bool IsGamePossible(string line)
        {
            var maxCubes = new Dictionary<string, int>
            {
                ["red"] = 12,
                ["green"] = 13,
                ["blue"] = 14,
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

                    if (quantity > maxCubes[color])
                    {
                        return false;
                    }
                }
            }

            return true;
        }
    }
}
