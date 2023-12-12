namespace AdventOfCode2023
{
    public static class Day1
    {
        public static int GetSumOfNumbers(string input)
        {
            var sum = 0;
            using (var reader = new StringReader(input))
            {
                string? line;
                while ((line = reader.ReadLine()) != null)
                {
                    var number = GetNumber(line);
                    sum += number;
                }
            }

            return sum;
        }

        private static int GetNumber(string rawLine)
        {
            var line = rawLine.Trim();

            var firstDigit = GetFirstDigit(line);
            
            var lastDigit = GetLastDigit(line);

            var fullNumber = $"{firstDigit}{lastDigit}";

            return int.Parse(fullNumber);
        }

        private static char GetFirstDigit(string line)
        {
            foreach (var character in line)
            {
                if (char.IsNumber(character))
                {
                    return character;
                }
            }

            throw new Exception("No numeric character in the line provided.");
        }

        private static char GetLastDigit(string line) => GetFirstDigit(string.Concat(line.Reverse()));
    }
}