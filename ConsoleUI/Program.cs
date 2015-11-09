using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Matrix;
using MatrixExtension;
using static System.Console;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            DiagonalMatrix<int> m1 = new DiagonalMatrix<int>(new int[]{ 1, 4, 7, 9}, 4);
            m1.ElementModified += PrintEventDetails;
            m1[1, 1] = 5;
            m1[3, 3] = 9;
            DiagonalMatrix<int> m2 = new DiagonalMatrix<int>(new int[] { 5, 6, 1, 1 }, 4);
            SymmetricMatrix<object> m3 = new SymmetricMatrix<object>(3);
            SymmetricMatrix<object> m4 = new SymmetricMatrix<object>(3);
            m3.ElementModified += PrintEventDetails;
            m3.Add(m4);
            m2.ElementModified += PrintEventDetails;
            m2.Add(m1);
            WriteLine();
            
            Read();
        }

        public static void PrintEventDetails<T>(object sender, ElementModifiedEventArgs<T> args)
        {
            WriteLine($" M({args.FirstIndex}, {args.SecondIndex}): {args.OldValue} => {args.NewValue}");
        }

    }
}
