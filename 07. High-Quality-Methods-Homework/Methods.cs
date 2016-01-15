using System;
using System.Globalization;
using Methods.Models;

namespace Methods
{
    class Methods
    {
        static void Main()
        {
            var trianlgle = new Triangle(3, 4, 5);
            Console.WriteLine(trianlgle.CalcTriangleArea(new HeronsFormulaArea()));

            Console.WriteLine(ConvertNumberToString(5));

            Console.WriteLine(FindMaxNumber(5, -1, 3, 2, 14, 2, 3));

            PrintInNumericFormat(1.3, "fixed-point");
            PrintInNumericFormat(0.75, "percentage");
            PrintInNumericFormat(2.30, "leftIndented");

            bool horizontal, vertical;
            Console.WriteLine(CalcPointDistance(3, -1, 3, 2.5));
            Console.WriteLine("Horizontal? " + CheckIfHorizontal(3, -1, 3, 2.5, out horizontal));
            Console.WriteLine("Vertical? " + CheckIfVertical(3, -1, 3, 2.5, out vertical));

            Student peter = new Student("Peter", "Ivanov", "From Sofia, born at 17.03.1992");
            
            Student stella = new Student("Stella", "Markova", "From Vidin, gamer, high results, born at 03.11.1993");
            
            Console.WriteLine("{0} older than {1} -> {2}",
                peter.FirstName, stella.FirstName, peter.IsOlderThan(stella));
        }

        static string ConvertNumberToString(int number)
        {
            if (number < 0 || number > 9)
            {
                throw new ArgumentOutOfRangeException("number", "The input number should be in range [0...9]");
            }

            switch (number)
            {
                case 0:
                    return "zero";

                case 1:
                    return "one";

                case 2:
                    return "two";

                case 3:
                    return "three";

                case 4:
                    return "four";

                case 5:
                    return "five";

                case 6:
                    return "six";

                case 7:
                    return "seven";

                case 8:
                    return "eight";

                case 9:
                    return "nine";

                default:
                    return "Invalid number";
            }
        }

        static int FindMaxNumber(params int[] elements)
        {
            if (elements == null || elements.Length == 0)
            {
                throw new ArgumentNullException("elements", "Array cannot be null or empty.");
            }

            for (int currentIndex = 1; currentIndex < elements.Length; currentIndex++)
            {
                if (elements[currentIndex] > elements[0])
                {
                    elements[0] = elements[currentIndex];
                }
            }
            return elements[0];
        }

        static void PrintInNumericFormat(object number, string format)
        {
            if (!IsNumeric(number))
            {
                throw new InvalidOperationException("The input value is not a number.");
            }

            if (format == "fixed-point")
            {
                PrintInFixedPointFormat(number);
            }

            else if (format == "percentage")
            {
                PrintInPercentageFormat(number);
            }

            else if (format == "leftIndented")
            {
                PrintInLeftIndentedFormat(number);
            }

            else
            {
                throw new Exception("The input format is not supported.");
            }
        }

        static double CalcPointDistance(double x1, double y1, double x2, double y2)
        {
            double distanceX = x2 - x1;
            double distanceY = y2 - y1;
            double distance = Math.Sqrt(distanceX * distanceX + distanceY * distanceY);

            return distance;
        }

        static bool CheckIfVertical(double x1, double y1, double x2, double y2, out bool isVertical)
        {
            isVertical = (x1 == x2);

            return isVertical;
        }

        static bool CheckIfHorizontal(double x1, double y1, double x2, double y2, out bool isHorizontal)
        {
            isHorizontal = (y1 == y2);

            return isHorizontal;
        }

        private static bool IsNumeric(object obj)
        {
            if (obj == null)
            {
                return false;
            }

            double number;
            bool isNumber = Double.TryParse(Convert.ToString(obj, CultureInfo.InvariantCulture), 
                NumberStyles.Any, 
                NumberFormatInfo.InvariantInfo, 
                out number);

            return isNumber;
        }

        private static void PrintInFixedPointFormat(object number)
        {
            Console.WriteLine("{0:f2}", number);
        }

        private static void PrintInPercentageFormat(object number)
        {
            Console.WriteLine("{0:p0}", number);
        }

        private static void PrintInLeftIndentedFormat(object number)
        {
            Console.WriteLine("{0,8}", number);
        }
    }
}
