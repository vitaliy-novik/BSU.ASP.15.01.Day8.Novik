using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Matrix
{
    public class SymmetricMatrix<T> : AbstractMatrix<T>
    {
        T[][] elements;

        public SymmetricMatrix(int size) : base(size)
        {
            elements = new T[Size][];
            for (int i = 0; i < Size; ++i)
                elements[i] = new T[i + 1];
        }

        public SymmetricMatrix(IEnumerable<T> items, int size) : base(size)
        {
            if (items == null)
                throw new ArgumentException(nameof(items));
            if (items.Count() < (size * (size + 1)) / 2)
                throw new ArgumentException(nameof(size));
            elements = new T[Size][];
            for (int i = 0; i < Size; ++i)
                elements[i] = new T[i + 1];
            using (IEnumerator<T> iterator = items.GetEnumerator())
            {
                for (int i = 0; i < Size; ++i)
                {
                    for (int j = 0; j <= i; j++)
                    {
                        iterator.MoveNext();
                        elements[i][j] = iterator.Current;
                    }                    
                }
            }
        }

        protected override void SetElement(int i, int j, T value)
        {
            if (i <= 0 || j <= 0 || i > Size || j > Size)
                throw new ArgumentOutOfRangeException();
            if (i >= j)
                elements[i - 1][j - 1] = value;
            elements[j - 1][i - 1] = value;
        }

        protected override T GetElement(int i, int j)
        {
            if (i <= 0 || j <= 0 || i > Size || j > Size)
                throw new ArgumentOutOfRangeException();
            if (i >= j)
                return elements[i - 1][j - 1];
            return elements[j - 1][i - 1];
        }

    }
}
