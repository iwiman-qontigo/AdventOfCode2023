namespace AdventOfCode2023
{
    public static class Day1Part2
    {
        public static int Day1Part2Main(string input)
        {
            var sum = 0;
            using (var reader = new StringReader(input))
            {
                string? rawLine;
                while ((rawLine = reader.ReadLine()) != null)
                {
                    var line = rawLine.Trim();
                    var number = GetNumber(line);
                    sum += number;
                }
            }

            return sum;
        }

        private static int GetNumber(string line)
        {
            var firstDigit = GetFirstDigit(line);

            var lastDigit = GetLastDigit(line);

            var fullNumber = $"{firstDigit}{lastDigit}";

            return int.Parse(fullNumber);
        }

        private static char GetFirstDigit(string line)
        {
            var accumulatedCharacters = "";

            foreach (var character in line)
            {
                if (char.IsNumber(character))
                {
                    return character;
                }

                accumulatedCharacters += character;

                var (hasNumberAsText, associatedNumber) = HasNumberAsText(accumulatedCharacters);
                if (hasNumberAsText)
                {
                    return associatedNumber;
                }
            }

            throw new Exception("No numeric character in the line provided.");
        }

        private static char GetLastDigit(string line)
        {
            var reversedLine = string.Concat(line.Reverse());

            var accumulatedCharacters = "";

            foreach (var character in reversedLine)
            {
                if (char.IsNumber(character))
                {
                    return character;
                }

                accumulatedCharacters += character;

                var (hasNumberAsText, associatedNumber) = HasNumberAsText(string.Concat(accumulatedCharacters.Reverse()));
                if (hasNumberAsText)
                {
                    return associatedNumber;
                }
            }

            throw new Exception("No numeric character in the line provided.");
        }

        private static (bool, char) HasNumberAsText(string accumulatedCharacters)
        {
            var numbersAsText = GetNumbersAsTextDictionary();

            foreach (var (numberAsText, associatedNumber) in numbersAsText)
            {
                if (accumulatedCharacters.Contains(numberAsText))
                {
                    return (true, associatedNumber);
                }
            }

            return (false, ' ');
        }

        private static Dictionary<string, char> GetNumbersAsTextDictionary() => new Dictionary<string, char>
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
    }
}