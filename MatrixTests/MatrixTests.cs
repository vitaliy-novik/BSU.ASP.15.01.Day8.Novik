using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using Matrix;
using MatrixExtension;

namespace MatrixTests
{
    [TestFixture]
    public class MatrixTests
    {
        [Test]
        public void AddTest()
        {
            DiagonalMatrix<int> m1 = new DiagonalMatrix<int>(new int[] { 1, 5, 7 }, 3);
            DiagonalMatrix<int> m2 = new DiagonalMatrix<int>(new int[] { 9, 5, 3 }, 3);

            DiagonalMatrix<int> m3 = new DiagonalMatrix<int>(new int[] { 10, 10, 10 }, 3);

            m2.Add(m1);

            for (int i = 1; i <= m1.Size; i++)
            {
                for (int j = 1; j <= m1.Size; j++)
                {
                    Assert.AreEqual(m2[i, j], m3[i, j]);
                }
            }
        }
    }
}
