using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Matrix;
using Microsoft.CSharp.RuntimeBinder;

namespace MatrixExtension
{
    public static class MatrixAddition
    {
        public static void Add<T>(this AbstractMatrix<T> m1, AbstractMatrix<T> m2)
        {
            if (m1.Size != m2.Size)
                throw new ArgumentException();
            try
            {
                for (int i = 1; i <= m1.Size; ++i)
                    for (int j = 1; j <= m1.Size; ++j)
                    {
                        m1[i, j] = (dynamic)m1[i, j] + (dynamic)m2[i, j];
                    }
            }
            catch(RuntimeBinderException e)
            {
                throw new InvalidOperationException($" Cannot sum {typeof(T).Name} and {typeof(T).Name}");
            }
            
            
        }
    }
}
