using Minesweeper.Extensions;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Minesweeper.Components
{
    [TestFixture]
    public class MineFieldViewModelTests
    {
        private static Mock<IMineSquare>[,] GenerateMockSquares(ushort rows, ushort columns, Action<Mock<IMineSquare>> mockSetup = null)
        {
            var result = new Mock<IMineSquare>[columns, rows];

            for (int x = 0; x < columns; x++)
            {
                for (int y = 0; y < rows; y++)
                {
                    var mock = new Mock<IMineSquare>();
                    mockSetup?.Invoke(mock);
                    result[x, y] = mock;
                }
            }

            return result;
        }

        private static Mock<IMineSquare>[,] GenerateStraightForwardTestField()
        {
            return GenerateMockSquares(2, 2, m =>
            {
                m.SetupAllProperties();
                m.Object.Enabled = true;
                m.Setup(x => x.RevealBomb()).Verifiable();
            });
        }

        [Test]
        public void DisablesExistingSquaresWhenCellExploded()
        {
            Mock<IMineSquare>[,] mocks = GenerateStraightForwardTestField();
            IMineSquare[,] field = mocks.SelectArray(x => x.Object);
            var vm = new MineFieldViewModel(new FieldConfiguration(), field);

            field[0, 0].State = MineCellState.Exploded;
            vm.MineCellStateChanged.Execute(field[0, 0]);

            Assert.IsTrue(field.OfType<IMineSquare>().All(x => !x.Enabled));
            foreach (var mock in mocks.OfType<Mock<IMineSquare>>())
            {
                mock.VerifyAll();
            }
        }

        [Test]
        public void EndsGameWhenCellExploded()
        {
            Mock<IMineSquare>[,] mocks = GenerateStraightForwardTestField();
            IMineSquare[,] field = mocks.SelectArray(x => x.Object);
            var vm = new MineFieldViewModel(new FieldConfiguration(), field);

            field[0, 0].State = MineCellState.Exploded;
            vm.MineCellStateChanged.Execute(field[0, 0]);

            Assert.AreEqual(MinesweeperGameState.GameLost, vm.GameState);
        }
    }
}
