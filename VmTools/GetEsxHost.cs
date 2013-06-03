using System.Management.Automation;
using VmToolsLib.VMware;

namespace VmTools
{
    [Cmdlet(VerbsCommon.Get, "EsxHost")]
    public class GetEsxHost : PSCmdlet
    {
        [Parameter(Mandatory = true)]
        [ValidateNotNullOrEmpty]
        public string EsxHostName { get; set; }

        [Parameter(Mandatory = true)]
        [ValidateNotNullOrEmpty]
        public string UserName { get; set; }

        [Parameter(Mandatory = true)]
        [ValidateNotNullOrEmpty]
        public string Password { get; set; }

        protected override void ProcessRecord()
        {
            var vSphereServer = new VSphereServer(EsxHostName, UserName, Password);

            var esxHostSystem = new EsxHostSystem(vSphereServer, EsxHostName);

            WriteObject(esxHostSystem);
        }
    }
}
