using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Matrix
{
    public class DiagonalMatrix<T> : AbstractMatrix<T>
    {
        T[] elements;
        
        public DiagonalMatrix(int size) : base(size)
        {
            elements = new T[Size];
        }

        public DiagonalMatrix(IEnumerable<T> items, int size) : base(size)
        {
            if (items == null)
                throw new ArgumentException(nameof(items));
            if (items.Count() < size)
                throw new ArgumentException(nameof(size));
            elements = new T[Size];
            using (IEnumerator<T> iterator = items.GetEnumerator())
            {
                for (int i = 0; i < Size; ++i)
                {
                    iterator.MoveNext();
                    elements[i] = iterator.Current;
                }
            }
        }

        protected override void SetElement(int i, int j, T value)
        {            
            if (i != j)
                throw new InvalidOperationException();
            elements[i - 1] = value;
        }

        protected override T GetElement(int i, int j)
        {
            if (i == j)
                return elements[i - 1];
            return default(T);
        }

    }
}
