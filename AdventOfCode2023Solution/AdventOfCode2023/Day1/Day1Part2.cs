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
            var firstDigit = GetDigit(line, isFirstDigit: true);

            var lastDigit = GetDigit(line, isFirstDigit: false);

            var fullNumber = $"{firstDigit}{lastDigit}";

            return int.Parse(fullNumber);
        }

        private static char GetDigit(string line, bool isFirstDigit)
        {
            line = isFirstDigit ? line : string.Concat(line.Reverse());

            var accumulatedCharacters = "";
            foreach (var character in line)
            {
                if (char.IsNumber(character))
                {
                    return character;
                }

                var index = isFirstDigit ? accumulatedCharacters.Length : 0;
                accumulatedCharacters = accumulatedCharacters.Insert(index, character.ToString());

                var (hasNumberAsText, associatedNumber) = HasNumberAsText(accumulatedCharacters);
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