using MatrixRotatingWalk;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MatrixRotatingWalkTests
{
    [TestFixture]
    public class FillMatrixTests
    {
        [Test]
        public void ConstructorShouldCreateTheCorrectSizeMatrix_WhenValidValueIsPassed()
        {
            // Arrange and Act

            var matrixSize = 5;
            var sut = new FillMatrix(matrixSize);

            // Assert

            Assert.AreEqual(matrixSize, sut.Matrix.GetLength(0));
            Assert.AreEqual(matrixSize, sut.Matrix.GetLength(1));

        }

        [Test]
        public void ConstructorShouldThrow_WhenInvalidValueIsPassed()
        {
            // Arrange

            var invalidSize = 150;

            // Act and Assert

            Assert.Throws<ArgumentOutOfRangeException>(() => new FillMatrix(invalidSize));
        }

        [Test]
        public void ConstructorShouldCorrectlyInitializeAllMatrixParameters_WhenValidValueIsPassed()
        {
            // Arrange

            var matrixSize = 5;
            var expectedRow = 0;
            var expectedCol = 0;
            var expectedRowIncrement = 1;
            var expectedColIncrement = 1;
            var expectedNumber = 1;
            // Act

            var sut = new FillMatrix(matrixSize);

            // Assert

            Assert.AreEqual(expectedRow, sut.Row);
            Assert.AreEqual(expectedCol, sut.Column);
            Assert.AreEqual(expectedRowIncrement, sut.RowIncrement);
            Assert.AreEqual(expectedColIncrement, sut.ColumnIncrement);
            Assert.AreEqual(expectedNumber, sut.Number);
        }
    }
}
