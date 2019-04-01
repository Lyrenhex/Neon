using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client
{
    public class Shape
    {
        public static int NumShape = 1;
        private string name;

        private const float FOV = (float)Math.PI / 2.0f; // alpha = 90deg FOV
        private float PROJECTION_PROPORTIONALITY_COMMON_DENOMINATOR = (float)Math.Tan(FOV / 2.0f); // tan(alpha / 2)

        public static float AspectRatio = 16.0f / 9.0f; // default to 16:9 -- we should set this to match monitor on formload
        public static int xMult = 960;
        public static int yMult = 540;

        private int numVertices;
        // a matrix storing the vertices making up the shape -- cols == number of vertices, rows = 3 (3D space)
        private Matrix vertices;
        private Graph vertexConnections;

        public string Name
        {
            get
            {
                return name;
            }
        }

        public int NumberOfVertices {
            get {
                return vertices.Cols;
            }
        }
        public Matrix Vertices {
            get {
                return vertices;
            }
        }
        public Graph VertexGraph
        {
            get
            {
                return vertexConnections;
            }
        }

        private string[] ParseLine(string line)
        {
            string[] splitWhitespace = line.Split();
            List<string> data = new List<string>();
            
            for (int i = 0; i < splitWhitespace.Length; i++)
            {
                if (splitWhitespace[i] != "")
                {
                    string section = splitWhitespace[i];
                    if (section.Contains("/"))
                    {
                        section = section.Split('/')[0];
                    }
                    data.Add(section);
                }
            }

            return data.ToArray<string>();
        }

        public Shape(string file) // pass in a string pointing to an object file, which we read for points & connections
        {
            name = file;

            string line;
            int lineNum = 1;

            var coordinates = new List<float[]>();
            float[,] lockedCoordinates = new float[0,0];
            bool[,] connectionGraph = new bool[0,0];
            var objFile = new System.IO.StreamReader(file);

            while ((line = objFile.ReadLine()) != null) // for each line that exists (not null)
            {
                string[] parsed = ParseLine(line); // parse line data
                
                if (parsed.Length > 0)
                {
                    if (parsed[0] == "v") // for each vertex
                    {
                        if (parsed.Length == 4)
                        {
                            try
                            {
                                coordinates.Add(new float[3] { float.Parse(parsed[parsed.Length - 3]), float.Parse(parsed[parsed.Length - 2]), float.Parse(parsed[parsed.Length - 1]) });
                            }
                            catch (Exception)
                            {
                                throw new ObjectFormatException($"Could not parse floating-point vertex coordinate on line {lineNum}.");
                            }
                        }
                    }
                    else if (parsed[0] == "f")
                    {
                        string[] parsedIndices = new string[parsed.Length - 1];
                        for (int i = 1; i < parsed.Length; i++)
                        {
                            parsedIndices[i - 1] = parsed[i];
                        }
                        if (lockedCoordinates.GetLength(0) == 0 && lockedCoordinates.GetLength(1) == 0)
                        {
                            lockedCoordinates = new float[coordinates.Count, 3];
                            connectionGraph = new bool[coordinates.Count, coordinates.Count];
                            int i = 0;
                            foreach (var coord in coordinates)
                            {
                                lockedCoordinates[i, 0] = coord[0];
                                lockedCoordinates[i, 1] = coord[1];
                                lockedCoordinates[i, 2] = coord[2];
                                i++;
                            }
                        }

                        for (int i = 1; i < parsedIndices.Length; i++)
                        {
                            connectionGraph[int.Parse(parsedIndices[0]) - 1, int.Parse(parsedIndices[i]) - 1] = true;
                        }
                    }
                }
                lineNum++;
            }

            numVertices = lockedCoordinates.GetLength(0);
            var workingShape = new Shape(lockedCoordinates, connectionGraph);
            vertices = workingShape.Vertices;
            vertexConnections = workingShape.VertexGraph;
        }
        public Shape(float[,] vertices, bool[,] adjacency) // pass in an array of floats - [number of vertices, number of dimensions per vertex]
        {
            name = (NumShape++).ToString();

            if (vertices.GetLength(1) != 3)
                throw new MatrixDimensionException($"Shapes must be 3-dimensional; is {vertices.GetLength(1)}-dimensional.");

            numVertices = vertices.GetLength(0); // also known as columns

            if (adjacency.GetLength(0) != numVertices)
                throw new GraphAdjacencyException($"Adjacency graph should have same number of vertices as the shape; should be {numVertices}, is {adjacency.GetLength(0)}");

            float[,] transposed = new float[3, numVertices];
            for (int vertex = 0; vertex < numVertices; vertex++)
            {
                for (int dim = 0; dim < 3; dim++)
                {
                    transposed[dim, vertex] = vertices[vertex, dim];
                }
            }

            this.vertices = new Matrix(3, numVertices, transposed);
            vertexConnections = new Graph(adjacency);
        }
        public Shape(int numVertices, Matrix vertices, bool[,] adjacency)
        {
            if (vertices.Rows != 3 || vertices.Cols != numVertices)
                throw new MatrixDimensionException($@"originMatrix should be a 3D matrix of numVertices columns (3x{numVertices}),
is ({vertices.Rows}x{vertices.Cols})");
            if (adjacency.GetLength(0) != numVertices)
                throw new GraphAdjacencyException($"Adjacency graph should have same number of vertices as the shape; should be {numVertices}, is {adjacency.GetLength(0)}");
            this.numVertices = numVertices;
            this.vertices = vertices;
            vertexConnections = new Graph(adjacency);
        }

        public void Rotate(float? angle_x = null, float? angle_y = null, float? angle_z = null)
        {
            if (angle_x != null)
                vertices.RotateX((float)angle_x);
            if (angle_y != null)
                vertices.RotateY((float)angle_y);
            if (angle_z != null)
                vertices.RotateZ((float)angle_z);
        }

        public void Translate(float displacement_x = 0, float displacement_y = 0, float displacement_z = 0)
        {
            var translationArray = new float[3, numVertices];
            for (int vertex = 0; vertex < numVertices; vertex++)
            {
                translationArray[0, vertex] = displacement_x;
                translationArray[1, vertex] = displacement_y;
                translationArray[2, vertex] = displacement_z;
            }
            var translationMatrix = new Matrix(3, numVertices, translationArray);
            vertices = Matrix.Sum(translationMatrix, vertices);
        }

        // Perform a perspective 3D to 2D projection
        public Shape Project()
        {
            var projectedVertices = new float[numVertices, 3]; // Shapes must be 3D, but we can just 0 the z-values.
            for (int vertex = 0; vertex < numVertices; vertex++)
            {
                if (vertices.Elements[2, vertex] >= 0) // skip computation if we're going to cull the point
                {
                    float x_divisor = AspectRatio * (vertices.Elements[2, vertex]) * PROJECTION_PROPORTIONALITY_COMMON_DENOMINATOR; // ar * z * tan(alpha / 2)
                    float y_divisor = (vertices.Elements[2, vertex]) * PROJECTION_PROPORTIONALITY_COMMON_DENOMINATOR; // z * tan(alpha / 2)
                    projectedVertices[vertex, 0] = xMult * vertices.Elements[0, vertex] / x_divisor;
                    projectedVertices[vertex, 1] = yMult * vertices.Elements[1, vertex] / y_divisor;
                    projectedVertices[vertex, 2] = vertices.Elements[2, vertex]; // expose the initial z-value for culling
                } else
                {
                    projectedVertices[vertex, 2] = vertices.Elements[2, vertex];
                }
            }

            return new Shape(projectedVertices, vertexConnections.Adjacency);
        }

        public override string ToString()
        {
            return name;
        }
    }

    public class ObjectFormatException : Exception
    {
        public ObjectFormatException(string error) : base(error) { }
    }
}
