using System;
using System.Runtime.Serialization;

namespace Clinique.Domain.Services
{
    [Serializable]
    internal class InvalidPasswordException : Exception
    {
        private readonly string Username;
        private readonly string Password;

        public InvalidPasswordException()
        {
        }

        public InvalidPasswordException(string message) : base(message)
        {
        }

        public InvalidPasswordException(string username, string password)
        {
            Username = username;
            Password = password;
        }

        public InvalidPasswordException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected InvalidPasswordException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}