namespace RotatingWalkMatrix.Tests
{
    using System;
    using System.IO;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class RotatingWalkTests
    {
        [TestMethod]
        public void MatrixRotatingWalk_ValidInput_ShouldReturnMatrix()
        {
            var fakeInput = new FakeUserInput();
            int matrixSize = int.Parse(fakeInput.GetInput());
            int[,] matrix = new int[matrixSize, matrixSize];
            RotatingWalkMatrix.MatrixRotatingWalk(matrix, matrixSize);
            using (StringWriter stringWriter = new StringWriter())
            {
                Console.SetOut(stringWriter);

                RotatingWalkMatrix.MatrixRotatingWalk(matrix, matrixSize);

                string expectedOutput = string.Format("  1  7  8{0}  6  2  9{0}  5  4  3{0}", Environment.NewLine);
                Assert.AreEqual<string>(expectedOutput, stringWriter.ToString());
            }

        }

        private class FakeUserInput : IUserInput
        {
            public string GetInput()
            {
                return "3";
            }
        }
    }
}
