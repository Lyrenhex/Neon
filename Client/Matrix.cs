using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client
{
    public class Matrix
    {
        /*
         * Base class for matrices, implementing common functions between rectangular, 2x2, and 3x3 matrices.
         */

        // stores number of rows and columns (unnecessary for 2x2 and 3x3)
        protected int rows, cols;
        // a rows,columns dimensional array representing the matrices elements
        protected float[,] elements;

        public int Rows {
            get {
                return rows;
            }
        }
        public int Cols {
            get {
                return cols;
            }
        }
        public float[,] Elements {
            get {
                return elements;
            }
        }

        protected Matrix() { } // allow inheriting classes to not have to go through Matrix construction

        public Matrix(int rows, int cols, float[,] elements)
        {
            this.rows = rows;
            this.cols = cols;

            if (elements.Rank != (rows - 1) || elements.GetLength(1) != cols)
                throw new MatrixDimensionException($@"Dimensions of element array ({elements.Rank + 1}x{elements.GetLength(1)})
does not equal matrix dimensions ({rows}x{cols})");
            this.elements = elements;
        }

        public static Matrix Mult (float scalar, Matrix a)
        {
            float[,] resultElements = new float[a.Rows, a.Cols];
            for (int row = 0; row < a.Rows; row++)
            {
                for (int col = 0; col < a.Cols; col++)
                {
                    resultElements[row, col] = (scalar * a.Elements[row, col]);
                }
            }

            return new Matrix(a.Rows, a.Cols, resultElements);
        }

        public static Matrix Mult (Matrix a, Matrix b)
        {
            if (a.Cols != b.Rows)
                throw new MatrixDimensionException($@"Multiplying matrices are not dimensionally compatible:
a.Cols ({a.Cols}) != b.Rows ({b.Rows})");

            float[,] resultElements = new float[a.Rows, b.Cols];
            for (int colB = 0; colB < b.Cols; colB++)
            {
                for (int rowA = 0; rowA < a.Rows; rowA++)
                {
                    for (int colA = 0; colA < a.Cols; colA++)
                    {
                        resultElements[rowA, colB].ToString();
                        a.Elements[rowA, colA].ToString();
                        b.Elements[colA, colB].ToString();
                        resultElements[rowA, colB] += (a.Elements[rowA, colA] * b.Elements[colA, colB]);
                    }
                }
            }
            

            return new Matrix(a.Rows, b.Cols, resultElements);
        }

        public static Matrix Sum (Matrix a, Matrix b)
        {
            if (a.Rows != b.Rows || a.Cols != b.Cols)
                throw new MatrixDimensionException($@"Summing matrices are not dimensionally compatible:
({a.Rows}x{a.Cols}) != ({b.Rows}x{b.Cols})");

            float[,] resultElements = new float[a.Rows, a.Cols];
            for (int row = 0; row < a.Rows; row++)
            {
                for (int col = 0; col < a.Cols; col++)
                {
                    resultElements[row, col] = (a.Elements[row, col] + b.Elements[row, col]);
                }
            }

            return new Matrix(a.Rows, a.Cols, resultElements);
        }

        // float is less precise -- will lead to *very slight* inaccuracies in rotation.
        // but faster than decimal (up to 20x). Issue with IEEE Floating-Point Standard & trancendentalism of Pi.
        // NB. this will not really affect the final display -- projection will be rounded to nearest integer on screen,
        //     so very small errors will be rounded out (eg. 90deg rotations do not equate to 0, but will round to it)
        public void RotateX(float angle) 
        {
            // C# Trig functions require angle in radians, but working with degrees in code is nicer. convert to rads.
            angle = (float)(angle / 180 * Math.PI);
            var cos = (float)Math.Cos(angle);
            var sin = (float)Math.Sin(angle);
            var RotationMatrix = new Matrix(3, 3, new float[3, 3] { { 1, 0,    0   },
                                                                    { 0, cos, -sin },
                                                                    { 0, sin,  cos } });
            var result = Mult(RotationMatrix, this);
            rows = result.Rows;
            cols = result.Cols;
            elements = result.Elements;
        }
        public void RotateY(float angle)
        {
            // C# Trig functions require angle in radians, but working with degrees in code is nicer. convert to rads.
            angle = angle / 180.0f * (float)Math.PI;
            var cos = (float)Math.Cos(angle);
            var sin = (float)Math.Sin(angle);
            var RotationMatrix = new Matrix(3, 3, new float[3, 3] { {  cos, 0, sin },
                                                                    {  0,   1, 0   },
                                                                    { -sin, 0, cos } });
            var result = Mult(RotationMatrix, this);
            rows = result.Rows;
            cols = result.Cols;
            elements = result.Elements;
        }
        public void RotateZ(float angle)
        {
            // C# Trig functions require angle in radians, but working with degrees in code is nicer. convert to rads.
            angle = angle / 180.0f * (float)Math.PI;
            var cos = (float)Math.Cos(angle);
            var sin = (float)Math.Sin(angle);
            var RotationMatrix = new Matrix(3, 3, new float[3, 3] { { cos, -sin, 0 },
                                                                    { sin,  cos, 0 },
                                                                    { 0,    0,   1 } });
            var result = Mult(RotationMatrix, this);
            rows = result.Rows;
            cols = result.Cols;
            elements = result.Elements;
        }

        public override string ToString()
        {
            string ret = "";
            for (int col = 0; col < cols; col++)
            {
                ret += $"({elements[0, col]}, {elements[1, col]}, {elements[2, col]}),";
            }
            return ret;
        }
    }

    public class MatrixDimensionException : Exception
    {
        public MatrixDimensionException(string error) : base(error) { }
    }

    public class MatrixSingularityException : Exception
    {
        public MatrixSingularityException(string error) : base(error) { }
    }
}
