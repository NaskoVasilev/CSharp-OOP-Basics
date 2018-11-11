using MilitaryElite.Contracts;

namespace MilitaryElite.Models
{
    public abstract class Soldier : ISoldier
    {
        public string Id { get; private set; }

        public string FirstName { get; private set; }

        public string LastName { get; private set; }

        public Soldier(string id, string firstName, string lastName)
        {
            Id = id;
            FirstName = firstName;
            LastName = lastName;
        }

        public override string ToString()
        {
            return $"Name: {FirstName} {LastName} Id: {Id} ";
        }
    }
}
