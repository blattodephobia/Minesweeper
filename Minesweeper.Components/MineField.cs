using System.Drawing;
using System.Collections.Generic;
using System.Windows.Forms;
using Minesweeper.Extensions;
using System;

namespace Minesweeper.Components
{
	public class MineField : Panel, IMineField
	{
		private static readonly Point locationOffset = new Point(0, 0);
		private static readonly Size minSize = new Size(4, 4); // compensates for the Panel control's border pixels
		private MineCell[,] mines;
		private bool initializing;
		private HashSet<MineCell> minesHashSet;
		private MinesweeperGameState innerState;

		private void NormalizeSize()
		{
			Size = new Size(minSize.Width + (Columns << 4), minSize.Height + (Rows << 4));
		}

		protected bool AutoVictory()
		{
			return RemainingSquares == RemainingBombs;
		}

		protected void HandleExplosion()
		{
			SuspendLayout();
			GameState = MinesweeperGameState.GameLost;
			foreach (MineCell mine in mines)
			{
				mine.Enabled = false;
				mine.RevealBomb();
			}
			PerformLayout();
			ResumeLayout();
			OnRemainingBombsCountChanged();
		}

		protected void TryDeclareAutoVictory()
		{
			if (RemainingBombs == RemainingSquares)
			{
				SuspendLayout();
				foreach (MineCell mine in mines)
				{
					if (mine.State == MineCellState.Closed)
					{
						mine.State = MineCellState.Defused;
					}
				}
				PerformLayout();
				ResumeLayout();
				GameState = MinesweeperGameState.GameWon;
			}
		}

		protected void HandleSquareOpened()
		{
			RemainingSquares--;
		}

		protected void HandleSquareDefused()
		{
			RemainingBombs--;
			RemainingSquares--;
			OnRemainingBombsCountChanged();
		}

		protected void HandleSquareRestored()
		{
			RemainingSquares++;
			RemainingBombs++;
			OnRemainingBombsCountChanged();
		}

		protected void OnMineCellStateChanged(MineCell obj)
		{
			switch (obj.State)
			{
				case MineCellState.Exploded: HandleExplosion(); break;
				case MineCellState.Opened: HandleSquareOpened(); break;
				case MineCellState.Defused: HandleSquareDefused(); break;
				case MineCellState.Closed: HandleSquareRestored(); break;
			}

			TryDeclareAutoVictory();
		}

		protected virtual void OnRemainingBombsCountChanged(EventArgs e = null)
		{
			if (RemainingBombsCountChanged != null)
			{
				RemainingBombsCountChanged(this, e);
			}
		}

		protected virtual void OnNewGameStarted(EventArgs e = null)
		{
			if (NewGameStarted != null)
			{
				NewGameStarted(this, e);
			}
		}

		protected virtual void OnMineCellsDrawn(EventArgs e)
		{
			if (CellsDrawn != null)
			{
				CellsDrawn(this, e);
			}
		}

		protected virtual void OnGameEnded(EventArgs e = null)
		{
			if (GameEnded != null)
			{
				GameEnded(this, e);
			}
		}

		public event EventHandler NewGameStarted;

		public event EventHandler GameEnded;

		public event EventHandler RemainingBombsCountChanged;

		public event EventHandler CellsDrawn;

		public int RemainingSquares { get; protected set; }

		public FieldConfiguration CurrentConfiguration { get; protected set; }

		public int RemainingBombs { get; protected set; }

		public bool GameStarted
		{
			get
			{
				return innerState == MinesweeperGameState.GameInProgress;
			}
		}

		public bool GameOver
		{
			get
			{
				return innerState != MinesweeperGameState.GameInProgress && innerState != MinesweeperGameState.Unknown;
			}
		}

		public bool GameWon
		{
			get
			{
				return innerState == MinesweeperGameState.GameWon;
			}
		}

		public MinesweeperGameState GameState
		{
			get
			{
				return innerState;
			}

			set
			{
				if (innerState != value)
				{
					innerState = value;
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

		public int Rows { get; protected set; }

		public int Columns { get; protected set; }

		public void DrawCells()
		{
			if (!initializing)
			{
				SuspendLayout();
				NormalizeSize();
				mines = new MineCell[Columns, Rows];
				minesHashSet = new HashSet<MineCell>();
				for (int y = 0; y < Rows; y++)
				{
					for (int x = 0; x < Columns; x++)
					{
						MineCell newMine = new MineCell();
						newMine.ControlLocation = new Point(locationOffset.X + (x << 4), locationOffset.Y + (y << 4));
						newMine.FieldLocation = new Point(x, y);
						newMine.NeighbouringBombsEnumerator = GetNeighbouringBombsCount;
						newMine.ParentBoard = this;
						newMine.StateChanged += new System.Action<MineCell>(OnMineCellStateChanged);
						mines[x, y] = newMine;
						minesHashSet.Add(newMine);
						Controls.Add(newMine);
					}
				}
				PerformLayout();
				ResumeLayout();
			}
		}

		public IEnumerable<IMineSquare> GetNeighbours(Point squareCoordinates)
		{
			return mines.EnumerateNeighbours(squareCoordinates).ConvertTo<MineCell, IMineSquare>();
		}

		public void TryExpandNonZeroSquare(Point squareCoordinates)
		{
			int defusedNeighboursCount = 0;
			HashSet<MineCell> neighboursToExpand = new HashSet<MineCell>();
			foreach (MineCell neighbour in mines.EnumerateNeighbours(squareCoordinates))
			{
				if (neighbour.Defused)
				{
					defusedNeighboursCount++;
				}
				else
				{
					neighboursToExpand.Add(neighbour);
				}
			}

			bool canExpand = mines.ElementAt(squareCoordinates).NeighbouringBombsCount == defusedNeighboursCount;
			if (canExpand)
			{
				foreach (MineCell neighbour in neighboursToExpand)
				{
					neighbour.State = MineCellState.Opened;
					if (neighbour.NeighbouringBombsCount == 0)
					{
						TryExpandZeroSquares(neighbour.FieldLocation);
					}
				}
			}
		}

		public void TryExpandZeroSquares(Point squareCoordinates)
		{
			MineCell startingSquare = mines.ElementAt(squareCoordinates);
			if (startingSquare.NeighbouringBombsCount == 0)
			{
				Queue<MineCell> zeroBombNeighboursSquares = new Queue<MineCell>(mines.Length >> 1);
				zeroBombNeighboursSquares.Enqueue(startingSquare);
				while (zeroBombNeighboursSquares.Count != 0 && !GameOver)
				{
					MineCell currentSquare = zeroBombNeighboursSquares.Dequeue();
					currentSquare.State = MineCellState.Opened;
					foreach (MineCell neighbour in mines.EnumerateNeighbours(currentSquare.FieldLocation))
					{
						if (!neighbour.Opened)
						{
							neighbour.State = MineCellState.Opened;
							if (neighbour.NeighbouringBombsCount == 0)
							{
								zeroBombNeighboursSquares.Enqueue(neighbour);
							}
						}
					}
				}
			}
		}

		public int GetNeighbouringBombsCount(IMineSquare sender)
		{
			int bombsCount = 0;
			if (!GameStarted && !GameOver)
			{
				HashSet<IMineSquare> excludedSquares = new HashSet<IMineSquare>(mines.EnumerateNeighbours(sender.FieldLocation).ConvertTo<MineCell, IMineSquare>());
				excludedSquares.Add(sender);
				mines.DistributeMines(excludedSquares, RemainingBombs);
				GameState = MinesweeperGameState.GameInProgress;
				OnRemainingBombsCountChanged();
			}
			else
			{
				foreach (IMineSquare mineSquare in mines.EnumerateNeighbours(sender.FieldLocation))
				{
					if (mineSquare.ContainsBomb)
					{
						bombsCount++;
					}
				}
			}

			return bombsCount;
		}

		public void CheatSolve()
		{
			foreach (MineCell cell in mines)
			{
				if (!cell.ContainsBomb && !cell.Opened && !cell.Defused)
				{
					cell.State = MineCellState.Opened;
				}
			}
		}

		public void RegisterMouseEnterEventHandler(EventHandler e)
		{
			foreach (MineCell cell in mines)
			{
				cell.MouseEnter += e;
			}
		}

		public void RegisterMouseDownEventHandler(MouseEventHandler e)
		{
			foreach (MineCell cell in mines)
			{
				cell.MouseDown += new MouseEventHandler(e);
			}
		}

		public void RegisterMouseUpEventHandler(MouseEventHandler e)
		{
			foreach (MineCell cell in mines)
			{
				cell.MouseUp += new MouseEventHandler(e);
			}
		}

		public MineField() :
			this(ConfigurationManager.MostRecentFieldConfiguration)
		{

		}

		public MineField(FieldConfiguration config)
		{
			CurrentConfiguration = config;
			initializing = true;
			BorderStyle = BorderStyle.Fixed3D;
			Rows = CurrentConfiguration.Height;
			Columns = CurrentConfiguration.Width;
			GameState = MinesweeperGameState.Unknown;
			RemainingSquares = Rows * Columns;
			RemainingBombs = CurrentConfiguration.MinesCount;
			initializing = false;
		}

		public MineField(int rows, int columns, int bombs) :
			this(new FieldConfiguration(columns, rows, bombs))
		{
		}
	}

	public interface IMineField
	{
		int GetNeighbouringBombsCount(IMineSquare sender);
		IEnumerable<IMineSquare> GetNeighbours(Point squareCoordinates);
		void TryExpandZeroSquares(Point squareCoordinates);
		void TryExpandNonZeroSquare(Point squareCoordinates);
		void RegisterMouseEnterEventHandler(EventHandler e);
		void RegisterMouseUpEventHandler(MouseEventHandler e);
		void RegisterMouseDownEventHandler(MouseEventHandler e);
		MinesweeperGameState GameState { get; set; }
		event EventHandler NewGameStarted;
		event EventHandler GameEnded;
		event EventHandler CellsDrawn;
	}

	public enum MinesweeperGameState
	{
		Unknown,
		GameInProgress,
		GameLost,
		GameWon
	}
}