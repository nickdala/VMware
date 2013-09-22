This is an example of how one can use the VMware.Vim assembly in order to communicate with an ESX host.  The VMware.Vim assembly is installed as part of 
the VMware PowerCLI.

This project enumerates the virtual machines on an ESX host.

Below is the output of the 'Get-Esxhost' PowerShell Cmdlet.

PS C:\> Import-Module "C:\VmTools\VmTools\bin\Debug\VmTools.dll"
PS C:\> $server = Get-VSphereServer -UserName root -Password Ipswitch! -Name 172.16.0.103
PS C:\> $server.EsxHostSystems

Name                                                        VirtualMachines
----                                                        ---------------
esh-host1                                                   {vm1,vm2}


PS C:\> $esx = Get-EsxHost -Name localhost.hsd1.ma.comcast.net. -Server $server
PS C:\> $esx.VirtualMachines

Name
----
vm1
vm2


