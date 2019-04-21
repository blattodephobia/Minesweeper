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
        private static Mock<IMineSquare>[,] GenerateMockSquares(int rows, int columns, Action<Mock<IMineSquare>> mockSetup = null)
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

        private static Mock<IMineSquare>[,] AllocateTestFieldSetupBehavior(FieldConfiguration config = null)
        {
            return GenerateMockSquares(config?.Height ?? 2, config?.Width ?? 2, m =>
            {
                m.SetupAllProperties();
                m.Object.Enabled = true;
                m.Setup(x => x.RevealBomb()).Verifiable();
            });
        }

        [Test]
        public void DisablesExistingSquaresWhenCellExploded()
        {
            Mock<IMineSquare>[,] mocks = AllocateTestFieldSetupBehavior();
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
            var config = new FieldConfiguration() { MinesCount = 1, Width = 2, Height = 2 };
            Mock<IMineSquare>[,] mocks = AllocateTestFieldSetupBehavior(config);
            IMineSquare[,] field = mocks.SelectArray(x => x.Object);
            var vm = new MineFieldViewModel(config, field) { RemainingLives = 0 };

            field[0, 0].State = MineCellState.Exploded;
            vm.MineCellStateChanged.Execute(field[0, 0]);

            Assert.AreEqual(MinesweeperGameState.GameLost, vm.GameState);
        }

        [Test]
        public void DecrementsBombsAndSquaresOnExplosion()
        {
            var config = new FieldConfiguration() { MinesCount = 1, Width = 2, Height = 2 };
            Mock<IMineSquare>[,] mocks = AllocateTestFieldSetupBehavior(config);
            IMineSquare[,] field = mocks.SelectArray(x => x.Object);
            var vm = new MineFieldViewModel(config, field);

            field[0, 0].State = MineCellState.Exploded;
            vm.MineCellStateChanged.Execute(field[0, 0]);

            Assert.AreEqual(0, vm.RemainingBombs);
            Assert.AreEqual(3, vm.RemainingSquares);
        }

        [Test]
        public void ContinuesGameIfLivesRemaining()
        {
            Mock<IMineSquare>[,] mocks = AllocateTestFieldSetupBehavior();

            IMineSquare[,] field = mocks.SelectArray(x => x.Object);
            var vm = new MineFieldViewModel(new FieldConfiguration(), field) { RemainingLives = 1 };
            field[0, 0].State = MineCellState.Exploded;
            vm.MineCellStateChanged.Execute(field[0, 0]);

            Assert.AreEqual(0, vm.RemainingLives);
            Assert.IsTrue(field.OfType<IMineSquare>().All(x => x.Enabled));
        }

        [Test]
        public void SetsRemainingBombsAccordingToMinesCount()
        {
            Mock<IMineSquare>[,] mocks = AllocateTestFieldSetupBehavior();
            IMineSquare[,] field = mocks.SelectArray(x => x.Object);
            var vm = new MineFieldViewModel(new FieldConfiguration() { MinesCount = 1 }, field);

            Assert.AreEqual(1, vm.RemainingBombs);
        }
    }
}
