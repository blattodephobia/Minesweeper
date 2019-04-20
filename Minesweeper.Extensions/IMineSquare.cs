using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Minesweeper.Extensions
{
    public interface IMineSquare
    {
        MineCellState State { get; set; }
        bool Enabled { get; set; }
        void RevealBomb();
        bool ContainsBomb { get; set; }
        Point ControlLocation { get; set; }
        Point FieldLocation { get; set; }
        EnumerateNeighbouringBombsDelegate NeighbouringBombsEnumerator { get; set; }
    }
}
