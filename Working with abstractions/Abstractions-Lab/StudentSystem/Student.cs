using System;
using System.Collections.Generic;
using System.Text;

namespace StudentSystem
{
    public class Student
    {
        private string name;
        private int age;
        private double grade;

        public double Grade
        {
            get { return grade; }
            set { grade = value; }
        }

        public int Age
        {
            get { return age; }
            set { age = value; }
        }

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public Student(string name, int age, double grade)
        {
            this.Name = name;
            this.Age = age;
            this.grade = grade;
        }

        public override string ToString()
        {
            string studentInfo = $"{this.Name} is {this.Age} years old.";

            if (this.Grade >= 5.00)
            {
                studentInfo += " Excellent student.";
            }
            else if (this.Grade < 5.00 && this.Grade >= 3.50)
            {
                studentInfo += " Average student.";
            }
            else
            {
                studentInfo += " Very nice person.";
            }

            return studentInfo;
        }
    }

}
