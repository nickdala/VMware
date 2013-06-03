using System;
using System.Globalization;
using VmToolsLib.Resources;

namespace VmToolsLib.VMware
{
    public abstract class VSphereManagedObject
    {
        protected IVSphereClient Client;

        protected VSphereManagedObject(string server, string userName, string password)
        {
            string serviceUrl = @"https://" + server + @"/sdk";

            Client = new VSphereClient(serviceUrl, userName, password);
        }

        protected VSphereManagedObject(VSphereManagedObject vSphereManagedObject)
        {
            if (vSphereManagedObject == null)
            {
                throw new ArgumentNullException("vSphereManagedObject", string.Format(CultureInfo.CurrentUICulture, Strings.ErrorParameterNull, "vSphereManagedObject"));
            }

            Client = vSphereManagedObject.Client;
        }

        protected VSphereManagedObject(IVSphereClient vSphereClient)
        {
            if (vSphereClient == null)
            {
                throw new ArgumentNullException("vSphereClient", string.Format(CultureInfo.CurrentUICulture, Strings.ErrorParameterNull, "vSphereClient"));
            }

            Client = vSphereClient;
        }
    }
}
