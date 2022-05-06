// <copyright file="Mesh.cs" company="Urs Müller">
// Copyright (c) Urs Müller. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.
// </copyright>

namespace SoftEngine
{
    using SharpDX;

    public struct Face
    {
        public int A;
        public int B;
        public int C;
    }

    public struct Vertex
    {
        public Vector3 Normal;
        public Vector3 Coordinates;
        public Vector3 WorldCoordinates;
    }

    public class Mesh
    {
        public Mesh(string name, int verticesCount, int facesCount)
        {
            Vertices = new Vertex[verticesCount];
            Faces = new Face[facesCount];
            Name = name;
        }

        public string Name { get; set; }

        public Vertex[] Vertices { get; private set; }

        public Face[] Faces { get; set; }

        public Vector3 Position { get; set; }

        public Vector3 Rotation { get; set; }
    }
}
