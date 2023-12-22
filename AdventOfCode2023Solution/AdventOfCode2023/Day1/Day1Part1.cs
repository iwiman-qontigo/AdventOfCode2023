namespace AdventOfCode2023
{
    public static class Day1Part1
    {
        /// <summary>
        /// Given a set of <see langword="string"/> lines with numeric digits, this method takes the first and the last 
        /// numerical digit of each line, forms a number concatenating those two digits, and then calculates the sum of all 
        /// those numbers.
        /// </summary>
        /// <param name="input">The lines.</param>
        /// <returns>
        /// The sum of the numbers formed by each line.
        /// </returns>
        public static int Day1Part1Main(string input)
        {
            var sum = 0;
            using (var reader = new StringReader(input))
            {
                string? rawLine;
                while ((rawLine = reader.ReadLine()) != null)
                {
                    var line = rawLine.Trim();
                    var number = GetNumberFromLine(line);
                    sum += number;
                }
            }

            return sum;
        }

        private static int GetNumberFromLine(string line)
        {
            var firstDigit = GetFirstDigit(line);

            var lastDigit = GetLastDigit(line);

            var fullNumber = $"{firstDigit}{lastDigit}";

            return int.Parse(fullNumber);
        }

        private static char GetFirstDigit(string line) => GetDigit(line, isFirstDigit: true);
        private static char GetLastDigit(string line) => GetDigit(line, isFirstDigit: false);

        private static char GetDigit(string line, bool isFirstDigit)
        {
            line = isFirstDigit ? line : string.Concat(line.Reverse());

            foreach (var character in line)
            {
                if (char.IsNumber(character))
                {
                    return character;
                }
            }

            throw new Exception("No numeric character in the line provided.");
        }
    }
}