using MilitaryElite.Contracts;
using System;
using MilitaryElite.Enums;

namespace MilitaryElite.Models
{
    public class Mission : IMission
    {
        public string CodeName { get; private set; }

        public States State { get; set; }

        public Mission(string codeName, States state)
        {
            CodeName = codeName;
            State = state;
        }

        public void CompleteMission()
        {
            this.State = States.Finished;
        }

        public override string ToString()
        {
            return $"Code Name: {CodeName} State: {State}";
        }
    }
}
