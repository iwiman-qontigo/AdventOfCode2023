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

                string? rawLine;
                while ((rawLine = reader.ReadLine()) != null)
                {
                    var line = rawLine.Trim();

                    var numberIndices = GetNumberIndices(line);  // Lista de sublistas donde cada sublista tiene los indices de un numero

                    foreach (var number in numberIndices)  // number = list of the indices of the same number
                    {
                        foreach (var digitIndex in number)  // digitIndex = list of the indices of the digits of the same number
                        {
                            if (digitIndex.HasAdjacentSymbol)
                            {
                                break;
                            }
                        }
                        sum += numberComoInt;
                    }
                }
            }
        }
    }
}
