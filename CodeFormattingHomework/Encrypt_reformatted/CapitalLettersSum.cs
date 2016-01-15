namespace Encrypt_reformatted
{
    using System;

    class CapitalLettersSum
    {
        public static void Main()
        {
            string input;
            double charNumericValue = 0;

            char[] encryption = {
				'A',
				'B',
				'C',
				'D',
				'E',
				'F',
				'G',
				'H',
				'I',
				'J',
				'K',
				'L',
				'M',
				'N',
				'O',
				'P',
				'Q',
				'R',
				'S',
				'T',
				'U',
				'V',
				'W',
				'X',
				'Y',
				'Z'
			};

            try
            {
                input = Console.ReadLine();
            }
            catch (Exception)
            {
                return;
            }

            int capitalCharactersSum = FindCapitalLettersUnicodeSum(input, encryption);

            Console.WriteLine(capitalCharactersSum);
        }

        private static int FindCapitalLettersUnicodeSum(string input, char[] encryption)
        {
            int charactersSum = 0;

            foreach (char characher in input)
            {
                foreach (char item in encryption)
                {
                    if (characher == item)
                    {
                        charactersSum += (int) item;
                    }
                }
            }

            return charactersSum;
        }
    }
}
