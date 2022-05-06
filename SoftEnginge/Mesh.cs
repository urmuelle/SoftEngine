// <copyright file="Mesh.cs" company="Urs Müller">
// Copyright (c) Urs Müller. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.
// </copyright>

namespace SoftEngine
{
    using SharpDX;

    public class Mesh
    {
        public Mesh(string name, int verticesCount)
        {
            Vertices = new Vector3[verticesCount];
            Name = name;
        }

        public string Name { get; set; }

        public Vector3[] Vertices { get; private set; }

        public Vector3 Position { get; set; }

        public Vector3 Rotation { get; set; }
    }
}
