using System.Linq;

namespace CustomException
{
    public class Student
    {
        private string name;
        private string email;

        public Student(string name, string email)
        {
            Name = name;
            Email = email;
        }

        public string Name
        {
            get { return name; }
            set
            {
                if (!value.All(x => char.IsLetter(x)))
                {
                    throw new InvalidPersonNameException("Name cannot conatains numeric or special chracters!");
                }
                name = value;
            }
        }

        public string Email
        {
            get { return email; }
            set { email = value; }
        }
    }
}
