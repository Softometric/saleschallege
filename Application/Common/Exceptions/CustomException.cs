using System;
using System.Net;

namespace Application.Common.Exceptions
{
    public class CustomException : Exception
    {
        public CustomException()
            : base()
        {
        }

        public CustomException(string message)
            : base(message)
        {

        }

        public CustomException(string message, Exception innerException)
            : base(message, innerException)
        {
        }

        public CustomException(string name, object key)
            : base($"Entity \"{name}\" ({key}) resulted into an error.")
        {
        }
    }
}
