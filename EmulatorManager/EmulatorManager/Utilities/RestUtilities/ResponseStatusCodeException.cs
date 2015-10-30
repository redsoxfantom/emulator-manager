using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace EmulatorManager.Utilities.RestUtilities
{
    /// <summary>
    /// Exception thrown when the server returns a non-success code
    /// </summary>
    public class ResponseStatusCodeException : Exception
    {
        public ResponseStatusCodeException()
        {
        }

        public ResponseStatusCodeException(string message) : base(message)
        {
        }

        public ResponseStatusCodeException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected ResponseStatusCodeException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
