using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace System.Linq
{
    public static class ArrayExtensions
    {
        public static TTarget[,] SelectArray<TSource, TTarget>(this TSource[,] sourceArray, Func<TSource, TTarget> projection)
        {
            int columns = sourceArray.GetLength(0);
            int rows = sourceArray.GetLength(1);
            var result = new TTarget[columns, rows];

            for (int x = 0; x < columns; x++)
            {
                for (int y = 0; y < rows; y++)
                {
                    result[x, y] = projection.Invoke(sourceArray[x, y]);
                }
            }

            return result;
        }
    }
}
