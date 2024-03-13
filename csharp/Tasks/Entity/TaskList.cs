using System;
using System.Collections.Generic;
using System.Text;

namespace Tasks.Entity
{
    public class TaskList
    {
        private readonly IDictionary<string, IList<Task>> tasks = new Dictionary<string, IList<Task>>();

        private int Id = 0;
        public IDictionary<string, IList<Task>> GetTasks()
        {
            return tasks;
        }

        public int NextId()
        {
            return ++Id ;
        }
    }
}
