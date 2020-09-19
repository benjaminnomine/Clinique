using System;
using System.Runtime.Serialization;

namespace Clinique.Domain.Services
{
    [Serializable]
    internal class InvalidPasswordException : Exception
    {
        private string username;
        private string password;

        public InvalidPasswordException()
        {
        }

        public InvalidPasswordException(string message) : base(message)
        {
        }

        public InvalidPasswordException(string username, string password)
        {
            this.username = username;
            this.password = password;
        }

        public InvalidPasswordException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected InvalidPasswordException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}