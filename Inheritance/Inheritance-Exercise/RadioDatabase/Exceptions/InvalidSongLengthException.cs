using System;
using System.Collections.Generic;
using System.Text;

namespace RadioDatabase.Exceptions
{
    public class InvalidSongLengthException : InvalidSongException
    {
        public InvalidSongLengthException(string message = "Invalid song length.") 
            : base(message)
        {
        }
    }
}
