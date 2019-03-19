using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client
{
    class Matrix3 : Matrix
    {
        public Matrix3 minors
        {
            get
            {
                var m = new float[rows, cols];
                for (var i = 0; i < rows; i++)
                {
                    for (var j = 0; j < cols; j++)
                    {
                        m[i, j] = Minor(i, j);
                    }
                }
                return new Matrix3(m);
            }
        }
        
        public Matrix3 cofactors
        {
            get
            {
                var c = new float[rows, cols];
                for (var i = 0; i < rows; i++)
                {
                    for (var j = 0; j < cols; j++)
                    {
                        c[i, j] = Cofactor(i, j);
                    }
                }
                return new Matrix3(c);
            }
        }

        public Matrix3(float[,] elements)
        {
            rows = 3;
            cols = rows;

            if (elements.Rank != (rows - 1) || elements.GetLength(1) != cols)
                throw new MatrixDimensionException($@"Dimensions of element array 
does not equal matrix dimensions ({rows}x{cols})");
            this.elements = elements;
        }

        public float Minor(int row, int col)
        {
            if (row < 0 || row >= rows || col < 0 || col >= cols)
                throw new MatrixDimensionException($"({row}, {col}) is not within the dimensions of the matrix ({rows}x{cols})");
            var minorElements = new float[2, 2];
            var rowIndices = new List<int>{ 0, 1, 2 };
            var colIndices = new List<int>{ 0, 1, 2 };
            rowIndices.RemoveAt(row);
            colIndices.RemoveAt(col);
            for (int iRow = 0; iRow < 2; iRow++)
            {
                for (int iCol = 0; iCol < 2; iCol++)
                {
                    minorElements[iRow, iCol] = elements[rowIndices[iRow], colIndices[iCol]];
                }
            }
            var minor = new Matrix2(minorElements);
            return minor.Det();
        }

        public float Cofactor (int row, int col)
        {
            // c_i,j = ((-1)^(i+j))M_i,j
            return (float)Math.Pow(-1, row + col) * elements[row, col];
        }

        public Matrix3 Transpose ()
        {
            var elem = new float[cols, rows];
            for (int row = 0; row < rows; row++)
            {
                for (int col = 0; col < cols; col++)
                {
                    elem[col, row] = elements[row, col];
                }
            }
            return new Matrix3(elem);
        }
    }
}
