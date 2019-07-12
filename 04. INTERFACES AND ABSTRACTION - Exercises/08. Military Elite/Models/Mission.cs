using System;
using System.Collections.Generic;
using System.Text;

namespace MilitaryElite
{
    public enum State
    {
        inProgress,
        Finished
    }
    public class Mission
    {
        public string CodeName { get; set; }

        public State State { get; private set; }

        public Mission(string codeName, State state)
        {
            this.CodeName = codeName;
            this.State = state;
        }

        public void CompleteMission()
        {
            this.State = State.Finished;
        }

        public override string ToString()
        {
            return $"Code Name: {CodeName} State: {State}";
        }
    }
}
