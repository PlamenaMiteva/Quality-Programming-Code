namespace RotatingWalkMatrix
{
    using System;

    public class RotatingWalkMatrix
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter matrix size ");
            string input = Console.ReadLine();
            int matrixSize = 0;
            while (!int.TryParse(input, out matrixSize) || matrixSize < 0 || matrixSize > 100)
            {
                Console.WriteLine("Matrix size should be a positive number in range [0...100].");
                input = Console.ReadLine();
            }
            int[,] matrix = new int[matrixSize, matrixSize];
            MatrixRotatingWalk(matrix, matrixSize);
        }

        public static void MatrixRotatingWalk(int[,] matrix, int matrixSize)
        {
            int matrixValue = 1;
            int matrixRow = 0;
            int matrixCol = 0;
            int xDirection = 1;
            int yDirection = 1;
            while (true)
            {
                matrix[matrixRow, matrixCol] = matrixValue;

                if (!CheckIfOutsideMatrixBounderies(matrix, matrixRow, matrixCol))
                {
                    break;
                }

                if (matrixRow + xDirection >= matrixSize ||
                    matrixRow + xDirection < 0 ||
                    matrixCol + yDirection >= matrixSize ||
                    matrixCol + yDirection < 0 ||
                    matrix[matrixRow + xDirection, matrixCol + yDirection] != 0)
                {
                    while (matrixRow + xDirection >= matrixSize ||
                           matrixRow + xDirection < 0 ||
                           matrixCol + yDirection >= matrixSize ||
                           matrixCol + yDirection < 0 ||
                           matrix[matrixRow + xDirection, matrixCol + yDirection] != 0)
                    {
                        ChangeDirection(ref xDirection, ref yDirection);
                    }
                }

                matrixRow += xDirection;
                matrixCol += yDirection;
                matrixValue++;
            }

            PrintMatrix(matrixSize, matrix);
        }

        private static void ChangeDirection(ref int xDrirection, ref int yDirection)
        {
            int[] dirX = { 1, 1, 1, 0, -1, -1, -1, 0 };
            int[] dirY = { 1, 0, -1, -1, -1, 0, 1, 1 };
            int currentDirection = 0;
            for (int count = 0; count < 8; count++)
            {
                if (dirX[count] == xDrirection && dirY[count] == yDirection)
                {
                    currentDirection = count;
                    break;
                }
            }

            if (currentDirection == 7)
            {
                xDrirection = dirX[0];
                yDirection = dirY[0];
                return;
            }

            xDrirection = dirX[currentDirection + 1];
            yDirection = dirY[currentDirection + 1];
        }

        static bool CheckIfOutsideMatrixBounderies(int[,] arr, int row, int col)
        {
            int[] dirX = { 1, 1, 1, 0, -1, -1, -1, 0 };
            int[] dirY = { 1, 0, -1, -1, -1, 0, 1, 1 };
            for (int i = 0; i < 8; i++)
            {
                if (row + dirX[i] >= arr.GetLength(0) || row + dirX[i] < 0)
                {
                    dirX[i] = 0;
                }

                if (col + dirY[i] >= arr.GetLength(0) || col + dirY[i] < 0)
                {
                    dirY[i] = 0;
                }
            }

            for (int i = 0; i < 8; i++)
            {
                if (arr[row + dirX[i], col + dirY[i]] == 0)
                {
                    return true;
                }
            }

            return false;
        }

        private static void PrintMatrix(int matrixSize, int[,] matrix)
        {
            for (int row = 0; row < matrixSize; row++)
            {
                for (int col = 0; col < matrixSize; col++)
                {
                    Console.Write("{0,3}", matrix[row, col]);
                }

                Console.WriteLine();
            }
        }
    }
}
