using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Globalization;
using System.Linq;
using VMware.Vim;
using VmToolsLib.Resources;

namespace VmToolsLib.VMware
{
    public class EsxHostSystem : VSphereManagedObject
    {
        #region Properties

        private readonly HostSystem _hostSystem;

        public string Name
        {
            get
            {
                return _hostSystem.Name;
            }
        }

        public ReadOnlyCollection<VSphereVirtualMachine> VirtualMachines
        {
            get
            {
                return GetVirtualMachines().AsReadOnly();
            }
        }

        #endregion

        #region Constructor

        public EsxHostSystem(VSphereManagedObject vSphereManagedObject, string hostName)
            : base(vSphereManagedObject)
        {
            _hostSystem = GetHostSystem(hostName);
        }

        internal EsxHostSystem(VSphereManagedObject vSphereManagedObject, HostSystem hostSystem)
            : base(vSphereManagedObject)
        {
            _hostSystem = hostSystem;
        }

        #endregion


        #region Private Methods

        private HostSystem GetHostSystem(string hostName)
        {
            var hostFilter = new NameValueCollection { { "name", "^" + hostName + "$" } };

            EntityViewBase hostSystem = Client.FindEntityView(typeof(HostSystem), null, hostFilter, null);

            if (hostSystem == null)
            {
                throw new VmToolsException(string.Format(CultureInfo.CurrentUICulture, Strings.ErrorExsHostNotFound, hostName));
            }

            return (HostSystem)hostSystem;
        }

        private List<VSphereVirtualMachine> GetVirtualMachines()
        {
            if (_hostSystem.Vm != null && _hostSystem.Vm.Length > 0)
            {
                List<ViewBase> vms = Client.GetViews(_hostSystem.Vm, null);

                if (vms != null)
                {
                    return vms.Select(vm => new VSphereVirtualMachine(this, (VirtualMachine) vm)).ToList();
                }
            }

            return new List<VSphereVirtualMachine>();
        }

        #endregion
    }
}
