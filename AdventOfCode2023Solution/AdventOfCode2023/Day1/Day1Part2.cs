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

            var accumulatedCharacters = "";
            foreach (var character in line)
            {
                if (char.IsNumber(character))
                {
                    return character;
                }

                // If the character is not a number, we have to check if we have a number as word.
                var index = isFirstDigit ? accumulatedCharacters.Length : 0;
                accumulatedCharacters = accumulatedCharacters.Insert(index, character.ToString());

                var (hasNumberAsWord, associatedNumberAsChar) = HasNumberAsWord(accumulatedCharacters);
                if (hasNumberAsWord)
                {
                    return associatedNumberAsChar;
                }
            }

            throw new Exception("No numeric character in the line provided.");
        }

        private static (bool, char) HasNumberAsWord(string accumulatedCharacters)
        {
            var numbersAsWord = GetNumbersAsWordsDictionary();

            foreach (var (numberAsWord, associatedNumberAsChar) in numbersAsWord)
            {
                if (accumulatedCharacters.Contains(numberAsWord))
                {
                    return (true, associatedNumberAsChar);
                }
            }

            return (false, ' ');
        }

        private static Dictionary<string, char> GetNumbersAsWordsDictionary() => new Dictionary<string, char>
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