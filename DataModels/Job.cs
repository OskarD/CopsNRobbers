using System.Collections.Generic;

namespace Server.DataModels
{
    public class Job
    {
        public readonly Queue<Objective> Objectives = new Queue<Objective>();

        public Objective CurrentObjective => Objectives.Count > 0 ? Objectives.Peek() : null;

        public void AddObjective(Objective objective)
        {
            Objectives.Enqueue(objective);
        }
    }
}