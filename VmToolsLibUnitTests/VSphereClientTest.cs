using VmToolsLib.VMware;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using VMware.Vim;
using System.Collections.Specialized;
using System.Collections.Generic;
using VMware.Vim.Moles;

namespace VmToolsLibUnitTests
{
    
    
    /// <summary>
    ///This is a test class for VSphereClientTest and is intended
    ///to contain all VSphereClientTest Unit Tests
    ///</summary>
    [TestClass()]
    public class VSphereClientTest
    {
        /// <summary>
        /// A test for the constructor.
        /// </summary>
        [TestMethod()]
        [HostType("Moles")]
        public void VSphereClientConstructorResultsInNonNullVSphereClient()
        {
            const string serviceUrl = "foo url";
            const string someUsername = "some user name";
            const string somePassword = "some password";

            bool vimClientConstructorCalled = false;
            bool vimClientConnectCalled = false;
            bool vimClientLoginCalled = false;


            MVimClient.Constructor = vimClient =>
            {
                new MVimClient(vimClient)
                {
                    ConnectString = url =>
                    {
                        Assert.AreEqual(serviceUrl, url);
                        vimClientConnectCalled = true;
                        return new MServiceContent();
                    },
                    LoginStringString = (username, password) =>
                    {
                        Assert.AreEqual(someUsername, username);
                        Assert.AreEqual(somePassword, password);
                        vimClientLoginCalled = true;
                        return new MUserSession();
                    }
                };

                vimClientConstructorCalled = true;
            };

            var client = new VSphereClient(serviceUrl, someUsername, somePassword);

            Assert.IsNotNull(client);
            Assert.IsTrue(vimClientConstructorCalled);
            Assert.IsTrue(vimClientConnectCalled);
            Assert.IsTrue(vimClientLoginCalled);
        }

        /// <summary>
        ///A test for FindEntityView
        ///</summary>
        [TestMethod()]
        [HostType("Moles")]
        public void FindEntityViewCallsVimClientFindEntityView()
        {
            const string serviceUrl = "foo url";
            const string someUsername = "some user name";
            const string somePassword = "some password";

            bool vimClientFindEntityViewCalled = false;

            var expectedEntityViewBase = new MEntityViewBase();
            Type hostSystemViewType = typeof(HostSystem);
            ManagedObjectReference beginEntityForFindEntityView = new MManagedObjectReference();
            NameValueCollection filterForFindEntityView = new NameValueCollection();
            string[] propertiesForFindEntityView = new string[2];

            MVimClient.Constructor = vimClient =>
            {
                new MVimClient(vimClient)
                {
                    ConnectString = url => new MServiceContent(),

                    LoginStringString = (username, password) => new MUserSession(),

                    FindEntityViewTypeManagedObjectReferenceNameValueCollectionStringArray
                        = (viewType, beginEntity, filter, properties) =>
                        {
                            Assert.AreEqual(typeof(HostSystem), hostSystemViewType);
                            Assert.AreSame(beginEntityForFindEntityView, beginEntity);
                            Assert.AreSame(filterForFindEntityView, filter);
                            Assert.AreSame(propertiesForFindEntityView, properties);
                            vimClientFindEntityViewCalled = true;
                            return expectedEntityViewBase;
                        }
                };
            };

            var client = new VSphereClient(serviceUrl, someUsername, somePassword);
            Assert.IsNotNull(client);

            var actualEntityViewBase = client.FindEntityView(hostSystemViewType, beginEntityForFindEntityView, filterForFindEntityView, propertiesForFindEntityView);
            Assert.IsTrue(vimClientFindEntityViewCalled);
            Assert.AreSame(expectedEntityViewBase.Instance, actualEntityViewBase);
        }

        /// <summary>
        ///A test for FindEntityViews
        ///</summary>
        [TestMethod()]
        [HostType("Moles")]
        public void FindEntityViewsCallsVimClientFindEntityViews()
        {
            const string serviceUrl = "foo url";
            const string someUsername = "some user name";
            const string somePassword = "some password";

            bool vimClientFindEntityViewsCalled = false;

            var expectedEntityViewBase = new List<EntityViewBase>();

            Type hostSystemViewType = typeof(HostSystem);
            ManagedObjectReference beginEntityForFindEntityView = new MManagedObjectReference();
            NameValueCollection filterForFindEntityView = new NameValueCollection();
            string[] propertiesForFindEntityView = new string[2];

            MVimClient.Constructor = vimClient =>
            {
                new MVimClient(vimClient)
                {
                    ConnectString = url => new MServiceContent(),

                    LoginStringString = (username, password) => new MUserSession(),

                    FindEntityViewsTypeManagedObjectReferenceNameValueCollectionStringArray
                        = (viewType, beginEntity, filter, properties) =>
                        {
                            Assert.AreEqual(typeof(HostSystem),
                                            hostSystemViewType);
                            Assert.AreSame(beginEntityForFindEntityView,
                                           beginEntity);
                            Assert.AreSame(filterForFindEntityView, filter);
                            Assert.AreSame(propertiesForFindEntityView,
                                           properties);
                            vimClientFindEntityViewsCalled = true;
                            return expectedEntityViewBase;
                        }
                };
            };

            var client = new VSphereClient(serviceUrl, someUsername, somePassword);
            Assert.IsNotNull(client);

            var actualEntityViewBase = client.FindEntityViews(hostSystemViewType, beginEntityForFindEntityView, filterForFindEntityView, propertiesForFindEntityView);
            Assert.IsTrue(vimClientFindEntityViewsCalled);
            Assert.AreSame(expectedEntityViewBase, actualEntityViewBase);
        }

        /// <summary>
        ///A test for GetViews
        ///</summary>
        [TestMethod()]
        [HostType("Moles")]
        public void GetViewsCallsVimClientGetViews()
        {
            const string serviceUrl = "foo url";
            const string someUsername = "some user name";
            const string somePassword = "some password";

            bool vimClientGetViewsCalled = false;

            var moRefForGetViews = new List<ManagedObjectReference>();
            string[] propertiesForFindEntityView = new string[2];
            var expectedViewBase = new List<ViewBase>();

            MVimClient.Constructor = vimClient =>
            {
                new MVimClient(vimClient)
                {
                    ConnectString = url => new MServiceContent(),

                    LoginStringString = (username, password) => new MUserSession(),

                    GetViewsIEnumerableOfManagedObjectReferenceStringArray
                        = (moRefs, properties) =>
                        {
                            Assert.AreSame(moRefForGetViews, moRefs);
                            Assert.AreSame(propertiesForFindEntityView, properties);
                            vimClientGetViewsCalled = true;
                            return expectedViewBase;
                        }
                };
            };

            var client = new VSphereClient(serviceUrl, someUsername, somePassword);
            Assert.IsNotNull(client);

            var actualViewBase = client.GetViews(moRefForGetViews, propertiesForFindEntityView);
            Assert.IsTrue(vimClientGetViewsCalled);
            Assert.AreSame(expectedViewBase, actualViewBase);
        }
    }
}
