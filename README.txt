This is an example of how one can use the VMware.Vim assembly in order to communicate with an ESX host.  The VMware.Vim assembly is installed as part of 
the VMware PowerCLI.

This project enumerates the virtual machines on an ESX host.

Below is the output of the 'Get-Esxhost' PowerShell Cmdlet.

PS C:\> Import-Module "C:\VmTools\VmTools\bin\Debug\VmTools.dll"
PS C:\> $esx = Get-Esxhost -EsxHost esxhost1 -UserName root -Password password123
PS C:\> $esx.VirtualMachines

Name
----
vm1
vm2

