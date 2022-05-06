namespace SoftEngineUnitTests
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using SoftEngine;

    [TestClass]
    public class MeshUnitTests
    {
        [TestMethod]
        public void TestNewMesh()
        {
            var mesh = new Mesh("test", 8, 12);
            Assert.IsNotNull(mesh);
            Assert.AreEqual("test", mesh.Name);
            Assert.AreEqual(8, mesh.Vertices.Length);
        }
    }
}