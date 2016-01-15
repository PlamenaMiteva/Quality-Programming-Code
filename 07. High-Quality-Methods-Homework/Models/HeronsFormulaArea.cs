namespace Methods.Models
{
    using System;

    public class HeronsFormulaArea: IArea
    {
        public double CalcTriangleArea(double sideA, double sideB, double sideC)
        {
            if (sideA <= 0 || sideB <= 0 || sideC <= 0)
            {
                throw new ArgumentOutOfRangeException("Triangle side should be positive number.");
            }

            double semiperimeter = (sideA + sideB + sideC) / 2;
            double area = Math.Sqrt(semiperimeter *
                (semiperimeter - sideA) *
                (semiperimeter - sideB) *
                (semiperimeter - sideC));

            return area;
        }
    }
}
