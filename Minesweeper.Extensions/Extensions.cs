using System;
using System.Collections.Generic;
using System.Drawing;

namespace Minesweeper.Extensions
{
	public delegate int EnumerateNeighbouringBombsDelegate(IMineSquare sender);

	public enum Direction
	{
		NORTH,
		NORTHEAST,
		EAST,
		SOUTHEAST,
		SOUTH,
		SOUTHWEST,
		WEST,
		NORTHWEST
	}

	public static class IEnumerableExtensions
	{
		public static void ForEach<T>(this IEnumerable<T> collection, Action<T> action)
		{
			foreach (T element in collection)
			{
				action(element);
			}
		}

		public static HashSet<TResult> ConvertTo<TSource, TResult>(this HashSet<TSource> collection)
			where TResult : class
		{
			HashSet<TResult> result = new HashSet<TResult>();
			foreach (TSource item in collection)
			{
				result.Add(item as TResult);
			}
			return result;
		}

		public static IEnumerable<TResult> ConvertTo<TSource, TResult>(this IEnumerable<TSource> collection)
			where TResult : class
		{
			foreach (TSource item in collection)
			{
				yield return item as TResult;
			}
		}

		public static object[] ObjectRange(int from, int to)
		{
			int delta = Math.Sign(to - from);

			object[] result = new object[Math.Abs(to - from) + 1];
			for (int i = from, index = 0; index < result.Length; i += delta, index++)
			{
				result[index] = i;
			}

			return result;
		}
	}

	public static class PointExtensions
	{
		public static bool IsInRangeOf<T>(this Point location, T[,] collection)
		{
			bool isInRange = location.X >= 0 && location.Y >= 0 &&
				location.X < collection.GetLength(0) && location.Y < collection.GetLength(1);
			return isInRange;
		}

		private static Dictionary<Direction, Point> directionOffsets = new Dictionary<Direction, Point>()
		{
			{ Direction.NORTH,		new Point(0, -1) },
			{ Direction.NORTHEAST,	new Point(1, -1) },
			{ Direction.EAST,		new Point(1, 0) },
			{ Direction.SOUTHEAST,	new Point(1, 1) },
			{ Direction.SOUTH,		new Point(0, 1) },
			{ Direction.SOUTHWEST,	new Point(-1, 1) },
			{ Direction.WEST,		new Point(-1, 0) },
			{ Direction.NORTHWEST,	new Point(-1, -1) }
		};

		public static Point GetNeighbour(this Point p, Direction neighbourDirection)
		{
			return new Point(p.X + directionOffsets[neighbourDirection].X, p.Y + directionOffsets[neighbourDirection].Y);
		}

		public static IEnumerable<T> EnumerateNeighbours<T>(this T[,] collection, Point location)
		{
			HashSet<T> neighbours = new HashSet<T>();
			foreach (Direction neighbourDirection in directionOffsets.Keys)
			{
				Point neighbourCoordinates = location.GetNeighbour(neighbourDirection);
				if (neighbourCoordinates.IsInRangeOf(collection))
				{
					neighbours.Add(collection.ElementAt(neighbourCoordinates));
				}
			}
			return neighbours;
		}

		public static void Translate(this Point p, Direction targetDirection)
		{
			p.X += directionOffsets[targetDirection].X;
			p.Y += directionOffsets[targetDirection].Y;
		}

		public static T ElementAt<T>(this T[,] collection, Point coordinates)
		{
			return collection[coordinates.X, coordinates.Y];
		}
	}

	public interface IMineSquare
	{
		bool ContainsBomb { get; set; }
		Point ControlLocation { get; set; }
		Point FieldLocation { get; set; }
		EnumerateNeighbouringBombsDelegate NeighbouringBombsEnumerator { get; set; }
	}

	public static class MineDistributionLogic
	{
		private static Random rand;

		private static bool CanPlaceMine(IMineSquare[,] collection, Point location, HashSet<IMineSquare> forbiddenSquares)
		{
			bool canPlaceMine;
			if (forbiddenSquares != null)
			{
				canPlaceMine = location.IsInRangeOf(collection) &&
				!forbiddenSquares.Contains(collection.ElementAt(location)) &&
				!collection.ElementAt(location).ContainsBomb;
			}
			else
			{
				canPlaceMine = location.IsInRangeOf(collection) &&
					!collection.ElementAt(location).ContainsBomb;
			}

			return canPlaceMine;
		}

		public static Random Rand
		{
			get
			{
				if (rand == null)
				{
					rand = new Random();
				}

				return rand;
			}
		}

		public static Point GetRandomPointIndex(int upperExclusiveBoundX, int upperExclusiveBoundY)
		{
			if (upperExclusiveBoundX < 1 || upperExclusiveBoundY < 1)
			{
				throw new System.ArgumentException("One or more of the arguments are below the minimum range [1; +inf)");
			}

			return new Point(Rand.Next(0, upperExclusiveBoundX), Rand.Next(0, upperExclusiveBoundY));
		}

		public static void DistributeMines(this IMineSquare[,] collection, HashSet<IMineSquare> forbiddenSquares, double entropy)
		{
			if (entropy > 0.75)
			{
				throw new System.ArgumentException("The count of mines cannot exceed 75% of the available squares on the field");
			}

			if (Math.Sign(entropy) == -1)
			{
				throw new System.ArgumentException("The argument representing percentage of mines cannot be negative");
			}

			int minesToPlace = (int)(entropy * collection.Length);
			for (int i = 0; i < minesToPlace; i++)
			{
				Point nextMineLocation = GetRandomPointIndex(collection.GetLength(0), collection.GetLength(1));
				while (!CanPlaceMine(collection, nextMineLocation, forbiddenSquares))
				{
					nextMineLocation = GetRandomPointIndex(collection.GetLength(0), collection.GetLength(1));
				}
				collection[nextMineLocation.X, nextMineLocation.Y].ContainsBomb = true;
			}
		}

		public static void DistributeMines(this IMineSquare[,] collection, HashSet<IMineSquare> forbiddenSquares, int minesCount)
		{
			if (minesCount / (double)collection.Length > 0.75)
			{
				throw new System.ArgumentException("The count of mines cannot exceed 75% of the available squares on the field");
			}

			if (minesCount < 0)
			{
				throw new System.ArgumentException("The count of mines cannot be negative");
			}

			for (int i = 0; i < minesCount; i++)
			{
				Point nextMineLocation = GetRandomPointIndex(collection.GetLength(0), collection.GetLength(1));
				while (!CanPlaceMine(collection, nextMineLocation, forbiddenSquares))
				{
					nextMineLocation = GetRandomPointIndex(collection.GetLength(0), collection.GetLength(1));
				}
				collection[nextMineLocation.X, nextMineLocation.Y].ContainsBomb = true;
			}
		}
	}

	public static class ParsingExtensions
	{
		public static int ToInt32(this string s, int defaultValue = 0)
		{
			int result;
			if (!int.TryParse(s, out result))
			{
				result = defaultValue;
			}

			return result;
		}
	}
}
