using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace EmulatorManager.Utilities.RestUtilities
{
    public class RestServerManagerException : Exception
    {
        public RestServerManagerException()
        {
        }

        public RestServerManagerException(string message) : base(message)
        {
        }

        public RestServerManagerException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected RestServerManagerException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
