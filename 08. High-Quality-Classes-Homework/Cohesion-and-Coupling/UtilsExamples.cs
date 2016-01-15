using System;

namespace CohesionAndCoupling
{
    class UtilsExamples
    {
        static void Main()
        {
            Console.WriteLine(FileUtils.GetFileExtension("example"));
            Console.WriteLine(FileUtils.GetFileExtension("example.pdf"));
            Console.WriteLine(FileUtils.GetFileExtension("example.new.pdf"));

            Console.WriteLine(FileUtils.GetFileNameWithoutExtension("example"));
            Console.WriteLine(FileUtils.GetFileNameWithoutExtension("example.pdf"));
            Console.WriteLine(FileUtils.GetFileNameWithoutExtension("example.new.pdf"));

            Console.WriteLine("Distance in the 2D space = {0:f2}",
                PointsUtils.CalcDistance2D(1, -2, 3, 4));
            Console.WriteLine("Distance in the 3D space = {0:f2}",
                PointsUtils.CalcDistance3D(5, 2, -1, 3, -6, 4));

            var box = new Box(3, 4, 5);
            Console.WriteLine("Volume = {0:f2}", box.CalcVolume());
            Console.WriteLine("Diagonal XYZ = {0:f2}", box.CalcDiagonalXYZ());
            Console.WriteLine("Diagonal XY = {0:f2}", box.CalcDiagonalXY());
            Console.WriteLine("Diagonal XZ = {0:f2}", box.CalcDiagonalXZ());
            Console.WriteLine("Diagonal YZ = {0:f2}", box.CalcDiagonalYZ());
        }
    }
}
