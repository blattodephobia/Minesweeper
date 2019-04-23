using Minesweeper.Extensions;
using System;
using System.Windows.Input;

namespace Minesweeper.Components
{
    public class MineFieldViewModel
    {
        private readonly IMineSquare[,] _mines;

        public ICommand MineCellStateChanged { get; private set; }

        private MinesweeperGameState _innerState;
        public virtual MinesweeperGameState GameState
        {
            get
            {
                return _innerState;
            }

            set
            {
                if (_innerState != value)
                {
                    _innerState = value;
                    if (value != MinesweeperGameState.GameInProgress && value != MinesweeperGameState.Unknown)
                    {
                        OnGameEnded();
                    }
                    else
                    {
                        OnNewGameStarted();
                    }
                }
            }
        }

        protected virtual void OnNewGameStarted()
        {
        }

        protected virtual void OnGameEnded()
        {
        }

        public int RemainingSquares { get; protected set; }
        
        public int RemainingBombs { get; protected set; }

        public uint RemainingLives { get; set; }

        protected virtual void HandleExplosion()
        {
            RemainingBombs--;
            RemainingSquares--;
            if (RemainingLives == 0)
            {
                GameState = MinesweeperGameState.GameLost;
                foreach (IMineSquare mine in _mines)
                {
                    mine.Enabled = false;
                    mine.RevealBomb();
                }
            }
            else
            {
                RemainingLives--;
            }
        }

        protected void OnMineCellStateChanged(object obj)
        {
            if (obj is IMineSquare cell)
            {
                switch (cell.State)
                {
                    case MineCellState.Exploded: HandleExplosion(); break;
                    case MineCellState.Opened: HandleSquareOpened(); break;
                    case MineCellState.Defused: HandleSquareDefused(); break;
                    case MineCellState.Closed: HandleSquareRestored(); break;
                }

                TryDeclareAutoVictory();
            }
        }

        protected virtual void HandleSquareDefused()
        {
            RemainingBombs--;
            RemainingSquares--;
        }

        protected virtual void HandleSquareRestored()
        {
            RemainingSquares++;
            RemainingBombs++;
        }

        protected virtual void HandleSquareOpened()
        {
            RemainingSquares--;
        }

        protected virtual void TryDeclareAutoVictory()
        {
            if (RemainingBombs == RemainingSquares)
            {
                foreach (IMineSquare mine in _mines)
                {
                    if (mine.State == MineCellState.Closed && mine.State != MineCellState.Defused)
                    {
                        mine.State = MineCellState.Defused;
                    }
                }
                GameState = MinesweeperGameState.GameWon;
            }
        }

        public MineFieldViewModel(FieldConfiguration config, IMineSquare[,] mines)
        {
            RemainingBombs = config.MinesCount;
            RemainingSquares = config.Height * config.Width;
            RemainingLives = config.ExtraLives;
            MineCellStateChanged = new DelegateCommand(OnMineCellStateChanged);
            _mines = mines;
        }
    }
}