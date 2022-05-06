// <copyright file="Texture.cs" company="Urs Müller">
// Copyright (c) Urs Müller. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.
// </copyright>

namespace SoftEngine
{
    using System;
    using System.Drawing;
    using System.IO;
    using SharpDX;

    public class Texture
    {
        private byte[] internalBuffer;
        private int width;
        private int height;

        // Working with a fix sized texture (512x512, 1024x1024, etc.).
        public Texture(string filename, int width, int height)
        {
            this.width = width;
            this.height = height;
            Load(filename);
        }

        // Takes the U & V coordinates exported by Blender
        // and return the corresponding pixel color in the texture
        public Color4 Map(float tu, float tv)
        {
            // Image is not loaded yet
            if (internalBuffer == null)
            {
                return Color4.White;
            }

            // using a % operator to cycle/repeat the texture if needed
            int u = Math.Abs((int)(tu * width) % width);
            int v = Math.Abs((int)(tv * height) % height);

            int pos = (u + (v * width)) * 4;

            byte b = internalBuffer[pos];
            byte g = internalBuffer[pos + 1];
            byte r = internalBuffer[pos + 2];
            byte a = internalBuffer[pos + 3];

            return new Color4(r / 255.0f, g / 255.0f, b / 255.0f, a / 255.0f);
        }

        private async void Load(string filename)
        {
            /* Retrieve the bytes of a bitmap in C# - .NET
             * https://docs.microsoft.com/en-us/dotnet/api/system.drawing.bitmap.unlockbits?view=dotnet-plat-ext-6.0
             */
            Bitmap b2 = new Bitmap(System.Drawing.Image.FromFile(filename, true));

            // Lock the bitmap's bits.
            System.Drawing.Rectangle rect = new System.Drawing.Rectangle(0, 0, b2.Width, b2.Height);
            System.Drawing.Imaging.BitmapData bmpData =
                b2.LockBits(rect, System.Drawing.Imaging.ImageLockMode.ReadWrite, b2.PixelFormat);

            // Get the address of the first line.
            IntPtr ptr = bmpData.Scan0;

            // Declare an array to hold the bytes of the bitmap.
            int bytes = Math.Abs(bmpData.Stride) * b2.Height;
            internalBuffer = new byte[bytes];

            // Copy the RGB values into the array.
            System.Runtime.InteropServices.Marshal.Copy(ptr, internalBuffer, 0, bytes);
        }
    }
}
