using System;
using System.Drawing;
using Minesweeper.Extensions;
using NUnit.Framework;

namespace Minesweeper.Tests
{
    public class PointExtensionsTests
    {
        [TestFixture]
        public class IsInRangeOfTests
        {
            [Test]
            public void ReturnsFalseIfOutOfXRange()
            {
                int[,] array = new int[1, 2];

                Point point = new Point(array.GetLength(0), 0);

                Assert.IsFalse(point.IsInRangeOf(array));
            }

            [Test]
            public void ReturnsFalseIfOutOfYRange()
            {
                int[,] array = new int[1, 2];

                Point point = new Point(0, array.GetLength(1));

                Assert.IsFalse(point.IsInRangeOf(array));
            }

            [Test]
            public void ReturnsFalseIfOutOfXYRange()
            {
                int[,] array = new int[1, 2];

                Point point = new Point(array.GetLength(0), array.GetLength(1));

                Assert.IsFalse(point.IsInRangeOf(array));
            }

            [Test]
            public void ReturnsTrueIfInXYRange()
            {
                int[,] array = new int[1, 2];

                Point point = new Point(0, 0);

                Assert.IsTrue(point.IsInRangeOf(array));
            }

            [Test]
            public void ReturnsFalseOnEmptyArray()
            {
                int[,] array = new int[0, 0];

                Point point = new Point(0, 0);

                Assert.IsFalse(point.IsInRangeOf(array));
            }
        }
    }
}
