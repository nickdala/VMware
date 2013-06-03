using VMware.Vim;

namespace VmToolsLib.VMware
{
    public class VSphereVirtualMachine : VSphereManagedObject
    {
        # region Properties

        private readonly VirtualMachine _vm;

        public string Name
        {
            get
            {
                return _vm.Summary.Config.Name;
            }
        }

        #endregion

        #region Constructor

        internal VSphereVirtualMachine(VSphereManagedObject vSphereManagedObject, VirtualMachine vm)
            : base(vSphereManagedObject)
        {
            _vm = vm;
        }

        #endregion
    }
}
