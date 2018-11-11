using System;
using System.Collections.Generic;
using System.Text;

namespace ValidPerson
{
    public class Person
    {
        private string firstName;
        private string lastName;
        private int age;

        public Person(string firstName, string lastName, int age)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
            this.Age = age;
        }

        public string FirstName
        {
            get { return firstName; }
            private set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException(nameof(firstName), "FirstName cannot be null or empty string!");
                }

                firstName = value;
            }
        }

        public string LastName
        {
            get { return lastName; }
            private set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException(nameof(lastName), "LastName cannot be null or empty string!");
                }

                lastName = value;
            }
        }

        public int Age
        {
            get { return age; }
            private set
            {
                if (value < 0 || value > 120)
                {
                    throw new ArgumentOutOfRangeException(nameof(age), "Age must be between 0 and 120!");
                }

                age = value;
            }
        }

    }
}
