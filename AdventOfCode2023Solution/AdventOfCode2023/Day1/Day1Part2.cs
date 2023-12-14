namespace AdventOfCode2023
{
    public static class Day1Part2
    {
        public static int Day1Part2Main(string input)
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
            var numbersAsText = new Dictionary<string, char> 
            {
                ["one"] = '1',
                ["two"] = '2',
                ["three"] = '3',
                ["four"] = '4',
                ["five"] = '5',
                ["six"] = '6',
                ["seven"] = '7',
                ["eight"] = '8',
                ["nine"] = '9'
            };

            var accumulatedCharacters = "";

            foreach (var character in line)
            {
                if (char.IsNumber(character))
                {
                    return character;
                }

                accumulatedCharacters += character;

                foreach (var (numberAsText, associatedNumber) in numbersAsText)
                {
                    if (accumulatedCharacters.Contains(numberAsText))
                    {
                        return associatedNumber;
                    }
                }
            }

            throw new Exception("No numeric character in the line provided.");
        }

        private static char GetLastDigit(string line) => GetFirstDigit(string.Concat(line.Reverse()));
    }
}