using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Matrix
{
    public class SquareMatrix<T> : AbstractMatrix<T>
    {
        T[,] elements;

        public SquareMatrix(int size) :base(size)
        {
            elements = new T[Size, Size];
        }

        public SquareMatrix(IEnumerable<T> items, int size) : base(size)
        {
            if (items == null)
                throw new ArgumentException(nameof(items));
            if (items.Count() < size * size)
                throw new ArgumentException(nameof(size));
            elements = new T[Size, Size];
            using (IEnumerator<T> iterator = items.GetEnumerator())
            {
                for (int i = 0; i < Size; ++i)
                {
                    for (int j = 0; j < Size; ++j)
                    {
                        iterator.MoveNext();
                        elements[i, j] = iterator.Current;
                    }
                }
            }
        }

        protected override void SetElement(int i, int j, T value)
        {
            if (i > 0 && j > 0 && i <= Size && j <= Size)
                elements[i - 1, j - 1] = value;
            throw new ArgumentOutOfRangeException();
        }

        protected override T GetElement(int i, int j)
        {
            if (i > 0 && j > 0 && i <= Size && j <= Size)
                return elements[i - 1, j - 1];
            throw new ArgumentOutOfRangeException();
        }
    }
}
