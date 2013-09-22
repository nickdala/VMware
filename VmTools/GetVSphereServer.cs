using System;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;
using System.Text;
using VmToolsLib.VMware;

namespace VmTools
{
    [Cmdlet(VerbsCommon.Get, "VSphereServer")]
    public class GetVSphereServer : PSCmdlet
    {
        [Parameter(Mandatory = true)]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        [Parameter(Mandatory = true)]
        [ValidateNotNullOrEmpty]
        public string UserName { get; set; }

        [Parameter(Mandatory = true)]
        [ValidateNotNullOrEmpty]
        public string Password { get; set; }


        protected override void ProcessRecord()
        {
            var vSphereServer = new VSphereServer(Name, UserName, Password);

            WriteObject(vSphereServer);
        }
    }
}
