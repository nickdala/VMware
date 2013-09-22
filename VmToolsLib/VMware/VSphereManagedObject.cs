using System;
using System.Globalization;
using VmToolsLib.Resources;

namespace VmToolsLib.VMware
{
    public abstract class VSphereManagedObject
    {
        internal VSphereClient Client;

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
    }
}
