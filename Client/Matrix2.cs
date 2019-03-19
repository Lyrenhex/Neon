using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client
{
    class Matrix2 : Matrix
    {
        public Matrix2(float[,] elements)
        {
            rows = 2;
            cols = rows;

            if (elements.Rank != (rows - 1) || elements.GetLength(1) != cols)
                throw new MatrixDimensionException($@"Dimensions of element array 
does not equal matrix dimensions ({rows}x{cols})");
            this.elements = elements;
        }

        public float Det()
        {
            return (elements[0, 0] * elements[1, 1]) - (elements[0, 1] * elements[1, 0]);
        }

        public Matrix2 Inverse()
        {
            float det = Det();
            if (det == 0)
                throw new MatrixSingularityException($"Matrix is singular, so no inverse: determinant is 0.");

            float[,] swapped = new float[2, 2] { { elements[1, 1], -elements[0, 1] },
                                                   { -elements[1, 0], elements[0, 0] }};
            return (Matrix2)Mult((1 / det), new Matrix2(swapped));
        }

        public Matrix2 Rotate(float angle)
        {
            var cos = (float)Math.Cos(angle);
            var sin = (float)Math.Sin(angle);
            var RotationMatrix = new Matrix2(new float[2, 2] { { cos, -sin },
                                                               { sin,  cos } });
            return (Matrix2)Mult(RotationMatrix, this);
        }
    }
}
