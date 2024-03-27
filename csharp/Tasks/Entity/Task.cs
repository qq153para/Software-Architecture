using System;
using System.Collections.Generic;

namespace Tasks.Entity
{
    public class Task
    {
        public Task(long Id,string Description,bool Done)
        {
            this.Id = Id;
            this.Description = Description; 
            this.Done = Done;
        }
        public long Id { get; set; }

        public string Description { get; set; }

        public bool Done { get;private set; }

        public void SetDone(bool done)
        {
            Done = done;
        }

    }
}
