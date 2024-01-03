namespace AdventOfCode2023
{
    public static class Day3Part1
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="input">The lines.</param>
        /// <returns>
        /// 
        /// </returns>
        public static int Day3Part1Main(string input)
        {
            // This part saves all the symbols of the input in a list of lists variable, in which every sublist contains
            // the symbol indices per line
            var symbolIndices = new List<List<int>>();

            using (var reader = new StringReader(input))
            {
                string? rawLine;
                while ((rawLine = reader.ReadLine()) != null)
                {
                    var line = rawLine.Trim();

                    var symbolIndicesPerLine = new List<int>();

                    var index = 0;

                    foreach (var character in line)
                    {
                        if (!char.IsNumber(character) && !(character == '.'))
                        {
                            symbolIndicesPerLine.Add(index);
                        }

                        index++;
                    }

                    symbolIndices.Add(symbolIndicesPerLine);
                }
            }
            // End of the symbol index saving part

            using (var reader = new StringReader(input))
            {
                var sum = 0;
                var currentLineNumber = 0;

                string? rawLine;
                while ((rawLine = reader.ReadLine()) != null)
                {
                    var line = rawLine.Trim();

                    var numberIndices = GetNumberIndices(line);  // Lista de sublistas donde cada sublista tiene los indices de un numero

                    foreach (var number in numberIndices)  // number = list of the indices of the same number
                    {
                        if (HasAdjacentSymbol(number, currentLineNumber, symbolIndices))
                        {
                            var value = ToValue(number, line);
                            sum += value;
                        }
                    }

                    currentLineNumber++;
                }

                return sum;
            }
        }

        private static List<List<int>> GetNumberIndices(string line)
        {
            var numberIndices = new List<List<int>>();
            var currentNumberIndices = new List<int>();
            var emptyList = new List<int>();

            foreach (var character in line)
            {
                if (char.IsNumber(character))
                {
                    currentNumberIndices.Add(int.Parse(character.ToString()));
                }
                else
                {
                    numberIndices.Add(currentNumberIndices);
                    currentNumberIndices = emptyList;
                }
            }

            return numberIndices;
        }

        private static bool HasAdjacentSymbol(List<int> number, int currentLineNumber, List<List<int>> symbolIndices)
        {
            if (currentLineNumber != 0 && currentLineNumber.IsNotTheLastOne(symbolIndices))
            {
                if (CheckPreviousLine(number, currentLineNumber, symbolIndices) ||
                    CheckSameLine(number, currentLineNumber, symbolIndices) ||
                    CheckNextLine(number, currentLineNumber, symbolIndices))
                {
                    return true;
                }
            }
            else if (currentLineNumber == 0)
            {
                if (CheckSameLine(number, currentLineNumber, symbolIndices) ||
                    CheckNextLine(number, currentLineNumber, symbolIndices))
                {
                    return true;
                }
            }
            else
            {
                if (CheckPreviousLine(number, currentLineNumber, symbolIndices) ||
                    CheckSameLine(number, currentLineNumber, symbolIndices))
                {
                    return true;
                }
            }

            return false;

        }

        private static bool CheckPreviousLine(List<int> number, int currentLineNumber, List<List<int>> symbolIndices)
        {
            foreach (var digitIndex in number)
            {
                if (symbolIndices[currentLineNumber - 1].Contains(digitIndex - 1) ||
                    symbolIndices[currentLineNumber - 1].Contains(digitIndex) ||
                    symbolIndices[currentLineNumber - 1].Contains(digitIndex + 1))
                {
                    return true;
                }
            }

            return false;
        }

        private static bool CheckSameLine(List<int> number, int currentLineNumber, List<List<int>> symbolIndices)
        {
            foreach (var digitIndex in number)
            {
                if (symbolIndices[currentLineNumber].Contains(digitIndex - 1) ||
                    symbolIndices[currentLineNumber].Contains(digitIndex + 1))
                {
                    return true;
                }
            }

            return false;
        }

        private static bool CheckNextLine(List<int> number, int currentLineNumber, List<List<int>> symbolIndices)
        {
            foreach (var digitIndex in number)
            {
                if (symbolIndices[currentLineNumber + 1].Contains(digitIndex - 1) ||
                    symbolIndices[currentLineNumber + 1].Contains(digitIndex) ||
                    symbolIndices[currentLineNumber + 1].Contains(digitIndex + 1))
                {
                    return true;
                }
            }

            return false;
        }

        private static bool IsNotTheLastOne(this int lineNumber, List<List<int>> symbolIndices)
        {
            return lineNumber != symbolIndices.Count;
        }

        private static int ToValue(List<int> listOfIndices, string line)
        {
            var number = "";

            foreach (var index in listOfIndices)
            {
                number += line[index];
            }

            return int.Parse(number);
        }
    }
}
