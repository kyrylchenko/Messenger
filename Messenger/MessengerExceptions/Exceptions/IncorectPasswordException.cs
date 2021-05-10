using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace MessengerExceptions.Exceptions
{
   public class IncorectPasswordException : Exception
    {
        public IncorectPasswordException():base("Incorect password")
        {

        }


        public IncorectPasswordException(string message) : base(message)
        {
        }

        public IncorectPasswordException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected IncorectPasswordException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
    public class IncorectLoginException : Exception
    {
        public IncorectLoginException():base("Incorect Login")
        {
        }

        public IncorectLoginException(string message) : base(message)
        {
        }

        public IncorectLoginException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected IncorectLoginException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
    public class ThisEmailAlredyRegistered : Exception
    {
        public ThisEmailAlredyRegistered() : base("This email alredy registered")
        {
        }

        public ThisEmailAlredyRegistered(string message) : base(message)
        {
        }

        public ThisEmailAlredyRegistered(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected ThisEmailAlredyRegistered(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
