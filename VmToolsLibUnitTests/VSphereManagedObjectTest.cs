using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using VmToolsLib.VMware;
using VmToolsLib.VMware.Moles;

namespace VmToolsLibUnitTests
{
    [TestClass]
    public class VSphereManagedObjectTest
    {
        private class MockVSphereManagedObject : VSphereManagedObject
        {
            public MockVSphereManagedObject(string server, string userName, string password)
                : base(server, userName, password)
            {
            }

            public MockVSphereManagedObject(VSphereManagedObject vSphereManagedObject)
                : base(vSphereManagedObject)
            {
            }

            public MockVSphereManagedObject(IVSphereClient vSphereClient)
                : base(vSphereClient)
            {
            }

            public IVSphereClient GetClient()
            {
                return Client;
            }
        }

        [TestMethod]
        public void ConstructorCalledWithNullIVSphereClientResultsInArgumentNullException()
        {
            try
            {
                SIVSphereClient client = null;

                var mockVSphereManagedObject = new MockVSphereManagedObject(client);
            }
            catch (ArgumentNullException ex)
            {
                Assert.AreEqual("vSphereClient", ex.ParamName);
                return;
            }

            Assert.Fail("ArgumentNullException was not thrown when VSphereManagedObject constructor called with a null IVSphereClient");
        }

        [TestMethod]
        public void ConstructorCalledWithValidIVSphereClientResultsInValidClientProperty()
        {
            var client = new SIVSphereClient();

            var mockVSphereManagedObject = new MockVSphereManagedObject(client);

            Assert.IsNotNull(mockVSphereManagedObject);

            var actualClient = mockVSphereManagedObject.GetClient();

            Assert.AreSame(client, actualClient);
        }

        [TestMethod]
        public void ConstructorCalledWithNullVSphereManagedObjectResultsInArgumentNullException()
        {
            try
            {
                MVSphereManagedObject vSphereManagedObject = null;

                var mockVSphereManagedObject = new MockVSphereManagedObject(vSphereManagedObject);
            }
            catch (ArgumentNullException ex)
            {
                Assert.AreEqual("vSphereManagedObject", ex.ParamName);
                return;
            }

            Assert.Fail("ArgumentNullException was not thrown when VSphereManagedObject constructor called with a null VSphereManagedObject");
        }

        [TestMethod]
        public void ConstructorCalledWithValidVSphereManagedObjectClientResultsInValidClient()
        {
            var client = new SIVSphereClient();

            var vSphereManagedObject = new MockVSphereManagedObject(client);

            Assert.IsNotNull(vSphereManagedObject);

            var mockVSphereManagedObject = new MockVSphereManagedObject(vSphereManagedObject);

            Assert.IsNotNull(mockVSphereManagedObject);

            var actualClient = mockVSphereManagedObject.GetClient();

            Assert.AreSame(client, actualClient);
        }
    }
}
