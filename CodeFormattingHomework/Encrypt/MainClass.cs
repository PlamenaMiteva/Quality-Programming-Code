using System;

namespace encrypt
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            string input;
            char[] character;
            double sum = 0;

            try
            {input = args[0];}
            catch (Exception)
            {return;}

            character = input.ToCharArray();

            char[] encryption = {
				'A','B','C','D','E','F','G','H',
				'I','J','K','L','M','N','O','P',
				'Q','R','S','T','U','V','W','X',
				'Y','Z'};

            foreach (char chr in input){foreach (char item in encryption){if (chr == item){sum += (int)item;}
                }
            }
            Console.Write(sum);
        }
    }
}