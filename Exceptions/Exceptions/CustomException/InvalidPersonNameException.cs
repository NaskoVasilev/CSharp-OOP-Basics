using System;

namespace CustomException
{
    public class InvalidPersonNameException : ApplicationException
    {
        public InvalidPersonNameException(string message) : base(message)
        {
        }
    }
}
