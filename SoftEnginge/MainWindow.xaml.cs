// <copyright file="MainWindow.xaml.cs" company="Urs Müller">
// Copyright (c) Urs Müller. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.
// </copyright>

namespace SoftEngine
{
    using System.Windows;
    using System.Windows.Media;
    using System.Windows.Media.Imaging;
    using SharpDX;

    /// <summary>
    /// Interaction logic for MainWindow.xaml.
    /// </summary>
    public partial class MainWindow : Window
    {
        private Device device;
        private Mesh[] meshes;
        private Camera camera = new ();

        public MainWindow()
        {
            InitializeComponent();

            LoadThings();
        }

        public void LoadThings()
        {
            // Choose the back buffer resolution here
            // NOTE: New constructor used
            WriteableBitmap bmp = new (
                640,
                480,
                96,
                96,
                PixelFormats.Bgr32,
                null);

            device = new Device(bmp);

            // Our Image XAML control
            Image1.Source = bmp;

            meshes = device.LoadJSONFileAsync("monkey.babylon");

            camera.Position = new Vector3(0, 0, 10.0f);
            camera.Target = Vector3.Zero;

            // Registering to the XAML rendering loop
            CompositionTarget.Rendering += CompositionTarget_Rendering;
        }

        // Rendering loop handler
        private void CompositionTarget_Rendering(object sender, object e)
        {
            device.Clear(0, 0, 0, 255);

            foreach (var mesh in meshes)
            {
                // rotating slightly the meshes during each frame rendered
                mesh.Rotation = new Vector3(mesh.Rotation.X + 0.00f, mesh.Rotation.Y + 0.01f, mesh.Rotation.Z);
            }

            // Doing the various matrix operations
            device.Render(camera, meshes);

            // Flushing the back buffer into the front buffer
            device.Present();
        }
    }
}
