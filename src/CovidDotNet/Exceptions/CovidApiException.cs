using System;
using System.Runtime.Serialization;
using System.Security.Permissions;

namespace CovidDotNet.Exceptions
{
    [Serializable]
    public class CovidApiException : Exception
    {
        public CovidApiException(string message)
            : base(message)
        {
        }

        public CovidApiException(string message, Exception innerException)
            : base(message, innerException)
        {
        }

        [SecurityPermission(SecurityAction.Demand, SerializationFormatter = true)]
        protected CovidApiException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }
    }
}
