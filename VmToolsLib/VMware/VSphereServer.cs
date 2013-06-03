using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using VMware.Vim;

namespace VmToolsLib.VMware
{
    public class VSphereServer : VSphereManagedObject
    {
        #region Constructor

        public VSphereServer(string server, string userName, string password)
            : base(server, userName, password)
        {
        }

        public VSphereServer(VSphereManagedObject managedObject)
            : base(managedObject)
        {
        }

        #endregion

        #region Properties

        public ReadOnlyCollection<EsxHostSystem> EsxHostSystems
        {
            get { return GetHostSystems().AsReadOnly(); }
        }

        #endregion

        private List<EsxHostSystem> GetHostSystems()
        {
            List<EntityViewBase> hostSystems = Client.FindEntityViews(typeof(HostSystem), null, null, null);

            if (hostSystems != null)
            {
                return hostSystems.Select(hostSystem => new EsxHostSystem(this, (HostSystem)hostSystem)).ToList();
            }

            return new List<EsxHostSystem>();
        }
    }
}
