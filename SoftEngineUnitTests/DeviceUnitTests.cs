using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftEngineUnitTests
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using SoftEngine;
    using System.Windows.Media;
    using System.Windows.Media.Imaging;

    [TestClass]
    public class DeviceUnitTests
    {
        [TestMethod]
        public void InitializeDevice()
        {
            // Choose the back buffer resolution here
            // NOTE: New constructor used
            WriteableBitmap bmp = new(
                640,
                480,
                96,
                96,
                PixelFormats.Bgr32,
                null);

            var device = new Device(bmp);

            Assert.IsNotNull(device);
        }
    }
}
