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
    public class MineCellTests
    {
        private class MineCellProxy : MineCell
        {
            public void ExecuteCommandProxy(MineCellCommand command) => ExecuteCommand(command);

            protected override void AutoExpand()
            {
            }
        }

        [Test]
        public void SetsStateOnlyOnceOnChange()
        {
            var cell = new MineCellProxy() { NeighbouringBombsEnumerator = (IMineSquare sq) => 0 };
            int stateChangedEventCalled = 0;
            cell.StateChanged += (x) => stateChangedEventCalled++;

            cell.ExecuteCommandProxy(MineCellCommand.Open);

            Assert.AreEqual(1, stateChangedEventCalled);
        }

        [Test]
        public void SetsStateOnOpen()
        {
            var cell = new MineCellProxy() { NeighbouringBombsEnumerator = (IMineSquare sq) => 0 };

            cell.ExecuteCommandProxy(MineCellCommand.Open);

            Assert.AreEqual(MineCellState.Opened, cell.State);
        }

        [Test]
        public void SetsStateOnlyOnceOnBombCellChange()
        {
            var cell = new MineCellProxy() { ContainsBomb = true };
            int stateChangedEventCalled = 0;
            cell.StateChanged += (x) => stateChangedEventCalled++;

            cell.ExecuteCommandProxy(MineCellCommand.Open);

            Assert.AreEqual(1, stateChangedEventCalled);
        }
    }
}
