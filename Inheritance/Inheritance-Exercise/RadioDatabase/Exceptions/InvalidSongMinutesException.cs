using System;
using System.Collections.Generic;
using System.Text;

namespace RadioDatabase.Exceptions
{
    class InvalidSongMinutesException : InvalidSongLengthException
    {
        public InvalidSongMinutesException(string message = "Song minutes should be between 0 and 14.") 
            : base(message)
        {
        }
    }
}
