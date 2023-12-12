namespace AdventOfCode2023
{
    public class Day1
    {
        public int GetSumOfNumbers(string input)
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

        private int GetNumber(string rawLine)
        {
            var line = rawLine.Trim();

            var firstDigit = GetFirstDigit(line);
            
            var lastDigit = GetLastDigit(line);

            var fullNumber = $"{firstDigit}{lastDigit}";

            return int.Parse(fullNumber);
        }

        private char GetFirstDigit(string line)
        {
            foreach (var character in line)
            {
                if (int.TryParse(character.ToString(), out _))
                {
                    return character;
                }
            }

            throw new Exception("No numeric character in the line provided.");
        }

        private char GetLastDigit(string line)
        {
            foreach (var character in line.Reverse())
            {
                if (int.TryParse(character.ToString(), out _))
                {
                    return character;
                }
            }

            throw new Exception("No numeric character in the line provided.");
        }
    }
}