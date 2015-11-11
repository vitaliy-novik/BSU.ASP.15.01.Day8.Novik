using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Matrix
{
    public abstract class AbstractMatrix<T>
    {
        public int Size { get; }

        public event EventHandler<ElementModifiedEventArgs<T>> ElementModified;

        public AbstractMatrix(int size)
        {
            Size = size;
        }

        public T this[int i, int j]
        {
            get
            {
                if (i <= 0 || j <= 0 || i > Size || j > Size)
                    throw new ArgumentOutOfRangeException();
                return GetElement(i, j);
            }
            set
            {
                if (i <= 0 || j <= 0 || i > Size || j > Size)
                    throw new ArgumentOutOfRangeException();
                T temp = GetElement(i, j);
                SetElement(i, j, value);
                OnElementModified(new ElementModifiedEventArgs<T>(i, j, temp, value));
            }
        }

        private void OnElementModified(ElementModifiedEventArgs<T> e)
            => ElementModified?.Invoke(this, e);

        protected abstract void SetElement(int i, int j, T value);

        protected abstract T GetElement(int i, int j);

                
    }
}
