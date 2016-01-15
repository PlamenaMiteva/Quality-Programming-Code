using System;
using System.Runtime.CompilerServices;

namespace Methods.Models
{
    public class Triangle
    {
        private double sideA;
        private double sideB;
        private double sideC;

        public Triangle(double sideA, double sideB, double sideC)
        {
            this.SideA = sideA;
            this.SideB = sideB;
            this.SideC = sideC;
        }

        public double SideA
        {
            get
            {
                return this.sideA;
            }

            set
            {
                if (value <= 0)
                {
                    throw new ArgumentOutOfRangeException("Triangle side length should be positive.");
                }

                this.sideA = value;
            }
        }

        public double SideB
        {
            get
            {
                return this.sideB;
            }

            set
            {
                if (value <= 0)
                {
                    throw new ArgumentOutOfRangeException("Triangle side length should be positive.");
                }

                this.sideB = value;
            }
        }

        public double SideC
        {
            get
            {
                return this.sideC;
            }

            set
            {
                if (value <= 0)
                {
                    throw new ArgumentOutOfRangeException("Triangle side length should be positive.");
                }

                this.sideC = value;
            }
        }

        public double CalcTriangleArea(IArea area)
        {
            var triangleArea = area.CalcTriangleArea(this.SideA, this.SideB, this.SideC);

            return triangleArea;
        }
    }
}
