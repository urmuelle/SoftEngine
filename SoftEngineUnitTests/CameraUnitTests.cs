namespace SoftEngineUnitTests
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using SoftEngine;

    [TestClass]
    public class CameraUnitTests
    {
        [TestMethod]
        public void TestCameraInitialization()
        {
            var camera = new Camera();

            Assert.IsNotNull(camera);
        }
    }
}
