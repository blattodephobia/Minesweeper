using System.Drawing;

namespace Minesweeper.Resources
{
	public class CellImagesProvider
	{
		private static Bitmap blankSquare;
		private static Bitmap bombSquare;
		private static Bitmap defaultSquare;
		private static Bitmap defusedSquare;
		private static Bitmap epxlodedSquare;
		private static Bitmap falseMineSquare;
		private static Bitmap numberedSquare1;
		private static Bitmap numberedSquare2;
		private static Bitmap numberedSquare3;
		private static Bitmap numberedSquare4;
		private static Bitmap numberedSquare5;
		private static Bitmap numberedSquare6;
		private static Bitmap numberedSquare7;
		private static Bitmap numberedSquare8;
		private static Bitmap pressedSquare;

		public static bool IsInitialized { get; private set; }

		public static Bitmap Blank
		{
			get
			{
				if (blankSquare == null)
				{
					blankSquare = DefaultSquares.sq_blank;
				}

				return blankSquare;
			}
		}

		public static Bitmap Bomb
		{
			get
			{
				if (bombSquare == null)
				{
					bombSquare = DefaultSquares.sq_bomb;
				}

				return bombSquare;
			}
		}

		public static Bitmap Default
		{
			get
			{
				if (defaultSquare == null)
				{
					defaultSquare = DefaultSquares.sq_default;
				}

				return defaultSquare;
			}
		}

		public static Bitmap Defused
		{
			get
			{
				if (defusedSquare == null)
				{
					defusedSquare = DefaultSquares.sq_defused;
				}

				return defusedSquare;
			}
		}

		public static Bitmap Exploded
		{
			get
			{
				if (epxlodedSquare == null)
				{
					epxlodedSquare = DefaultSquares.sq_exploded;
				}

				return epxlodedSquare;
			}
		}

		public static Bitmap False
		{
			get
			{
				if (falseMineSquare == null)
				{
					falseMineSquare = DefaultSquares.sq_false;
				}

				return falseMineSquare;
			}
		}

		public static Bitmap NumberedSquare1
		{
			get
			{
				if (numberedSquare1 == null)
				{
					numberedSquare1 = DefaultSquares.sq_neighbours1;
				}

				return numberedSquare1;
			}
		}

		public static Bitmap NumberedSquare2
		{
			get
			{
				if (numberedSquare2 == null)
				{
					numberedSquare2 = DefaultSquares.sq_neighbours2;
				}

				return numberedSquare2;
			}
		}

		public static Bitmap NumberedSquare3
		{
			get
			{
				if (numberedSquare3 == null)
				{
					numberedSquare3 = DefaultSquares.sq_neighbours3;
				}

				return numberedSquare3;
			}
		}

		public static Bitmap NumberedSquare4
		{
			get
			{
				if (numberedSquare4 == null)
				{
					numberedSquare4 = DefaultSquares.sq_neighbours4;
				}

				return numberedSquare4;
			}
		}

		public static Bitmap NumberedSquare5
		{
			get
			{
				if (numberedSquare5 == null)
				{
					numberedSquare5 = DefaultSquares.sq_neighbours5;
				}

				return numberedSquare5;
			}
		}

		public static Bitmap NumberedSquare6
		{
			get
			{
				if (numberedSquare6 == null)
				{
					numberedSquare6 = DefaultSquares.sq_neighbours6;
				}

				return numberedSquare6;
			}
		}

		public static Bitmap NumberedSquare7
		{
			get
			{
				if (numberedSquare7 == null)
				{
					numberedSquare7 = DefaultSquares.sq_neighbours7;
				}

				return numberedSquare7;
			}
		}

		public static Bitmap NumberedSquare8
		{
			get
			{
				if (numberedSquare8 == null)
				{
					numberedSquare8 = DefaultSquares.sq_neighbours8;
				}

				return numberedSquare8;
			}
		}

		public static Bitmap Pressed
		{
			get
			{
				if (pressedSquare == null)
				{
					pressedSquare = DefaultSquares.sq_pressed;
				}

				return pressedSquare;
			}
		}

		public static void SetTheme()
		{

		}
	}
}
