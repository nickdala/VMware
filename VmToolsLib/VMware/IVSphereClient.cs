using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using VMware.Vim;

namespace VmToolsLib.VMware
{
    public interface IVSphereClient
    {
        List<ViewBase> GetViews(IEnumerable<ManagedObjectReference> moRefs, params string[] properties);

        EntityViewBase FindEntityView(Type viewType, ManagedObjectReference beginEntity, NameValueCollection filter, string[] properties);

        List<EntityViewBase> FindEntityViews(Type viewType, ManagedObjectReference beginEntity, NameValueCollection filter, string[] properties);
    }
}
