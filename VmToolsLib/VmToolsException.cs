using System;

namespace VmToolsLib
{
    public class VmToolsException : ApplicationException
    {
        public VmToolsException()
        {
        }

        public VmToolsException(string message)
            : base(message)
        {
        }

        public VmToolsException(string message, Exception innerException)
            : base(message, innerException)
        {
        }
    }
}
