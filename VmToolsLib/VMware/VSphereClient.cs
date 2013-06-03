using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using VMware.Vim;

namespace VmToolsLib.VMware
{
    internal sealed class VSphereClient : IVSphereClient
    {
        private readonly VimClient _client;

        public VSphereClient(string serviceUrl, string userName, string password)
        {
            _client = new VimClient();
            _client.Connect(serviceUrl);
            _client.Login(userName, password);
        }

        public List<ViewBase> GetViews(IEnumerable<ManagedObjectReference> moRefs, params string[] properties)
        {
            return _client.GetViews(moRefs, properties);
        }

        public EntityViewBase FindEntityView(Type viewType, ManagedObjectReference beginEntity, NameValueCollection filter, string[] properties)
        {
            return _client.FindEntityView(viewType, beginEntity, filter, properties);
        }

        public List<EntityViewBase> FindEntityViews(Type viewType, ManagedObjectReference beginEntity, NameValueCollection filter, string[] properties)
        {
            return _client.FindEntityViews(viewType, beginEntity, filter, properties);
        }
    }
}
