using System;
using System.Collections.Generic;
using System.Text;

namespace Mankind
{
    public class Human
    {
        private string firstName;
        private string lastName;

        public Human(string firstName, string lastName)
        {
            FirstName = firstName;
            LastName = lastName;
        }

        public string FirstName
        {
            get { return firstName; }
            set
            {
                if (string.IsNullOrEmpty(value)||!char.IsLetter(value[0]) || char.IsLower(value[0]))
                {
                    throw new ArgumentException($"Expected upper case letter! Argument: firstName");
                }
                else if (value.Length < 4)
                {
                    throw new ArgumentException($"Expected length at least 4 symbols! Argument: firstName");
                }
                firstName = value;
            }
        }

        public string LastName
        {
            get { return lastName; }
            set
            {
                if (string.IsNullOrEmpty(value) || !char.IsLetter(value[0]) || char.IsLower(value[0]))
                {
                    throw new ArgumentException($"Expected upper case letter! Argument: lastName");
                }
                else if (value.Length < 3)
                {
                    throw new ArgumentException("Expected length at least 3 symbols! Argument: lastName");
                }
                lastName = value;
            }
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append($"First Name: {this.FirstName}\n");
            sb.Append($"Last Name: {this.LastName}\n");

            return sb.ToString();
        }
    }
}
