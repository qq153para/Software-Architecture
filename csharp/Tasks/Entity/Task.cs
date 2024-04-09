using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;

namespace Tasks.Entity
{
    public class Task
    {
        private TaskId Id;
        private string Description;
        private bool Done;
        public Task(TaskId id,string description,bool done)
        {
            this.Id = id;
            this.Description = description; 
            this.Done = done;
        }
        public TaskId GetId()
        {
            return Id;
        }

        public string GetDescription()
        {
            return Description;
        }

        public bool IsDone()
        {
            return Done;
        }

        public virtual void SetDone(bool done)
        {
            Done = done;
        }

    }
}
