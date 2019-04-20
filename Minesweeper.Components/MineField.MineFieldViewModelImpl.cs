using Minesweeper.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Minesweeper.Components
{
    public partial class MineField
    {
        private class MineFieldViewModelImpl : MineFieldViewModel, IDisposable
        {
            private readonly MineField _fieldForm;

            public MineFieldViewModelImpl(MineField fieldForm, FieldConfiguration config, IMineSquare[,] mines) :
                base(config, mines)
            {
                _fieldForm = fieldForm;
            }

            void IDisposable.Dispose()
            {
                _fieldForm.Dispose();
            }

            protected override void HandleExplosion()
            {
                _fieldForm.SuspendLayout();

                base.HandleExplosion();

                _fieldForm.PerformLayout();
                _fieldForm.ResumeLayout();
                _fieldForm.OnRemainingBombsCountChanged();
            }

            protected override void HandleSquareDefused()
            {
                base.HandleSquareDefused();
                _fieldForm.OnRemainingBombsCountChanged();
            }

            protected override void HandleSquareRestored()
            {
                base.HandleSquareRestored();
                _fieldForm.OnRemainingBombsCountChanged();
            }

            protected override void TryDeclareAutoVictory()
            {
                if (RemainingBombs == RemainingSquares)
                {
                    _fieldForm.SuspendLayout();
                    base.TryDeclareAutoVictory();

                    _fieldForm.PerformLayout();
                    _fieldForm.ResumeLayout();
                }
            }

            protected override void OnGameEnded()
            {
                base.OnGameEnded();
                _fieldForm.OnGameEnded();
            }

            protected override void OnNewGameStarted()
            {
                base.OnNewGameStarted();
                _fieldForm.OnNewGameStarted();
            }
        }
    }
}
