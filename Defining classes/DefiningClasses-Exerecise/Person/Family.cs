using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DefiningClasses
{
    public class Family
    {
        private List<Person> members;

        public List<Person> Members
        {
            get { return this.members; }
            set { this.members = value; }
        }

        public Family()
        {
            this.members = new List<Person>();
        }

        public void AddMember(Person member)
        {
            this.members.Add(member);
        }

        public Person GetOldestMember()
        {
            return this.members.OrderByDescending(x => x.Age).FirstOrDefault();
        }

    }
}
