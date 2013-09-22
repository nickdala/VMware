using System.Management.Automation;
using VmToolsLib.VMware;

namespace VmTools
{
    [Cmdlet(VerbsCommon.Get, "EsxHost")]
    public class GetEsxHost : PSCmdlet
    {
        [Parameter(Mandatory = true)]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        [Parameter(Mandatory = true)]
        [ValidateNotNullOrEmpty]
        public VSphereServer Server { get; set; }
        
        protected override void ProcessRecord()
        {
            var esxHostSystem = new EsxHostSystem(Server, Name);

            WriteObject(esxHostSystem);
        }
    }
}
