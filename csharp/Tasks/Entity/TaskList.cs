using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Tasks.Concole;

namespace Tasks.Entity
{
    public class TaskList
    {
        private readonly IDictionary<string, IList<Task>> tasks = new Dictionary<string, IList<Task>>();
        private static TaskList taskList = null;

        private int Id = 0;

        protected TaskList() { }
        public IDictionary<string, IList<Task>> GetTasks()
        {
            return tasks;
        }

        public int NextId()
        {
            return ++Id ;
        }
        public static TaskList GetTaskList()
        {
            if (taskList == null)
            {
                taskList = new TaskList();
            }
            return taskList;
        }
        public Task FindTask(string idString)
        {
            int id = int.Parse(idString);
            var identifiedTask = tasks
                .Select(project => project.Value.FirstOrDefault(task => task.Id == id))
                .Where(task => task != null)
                .FirstOrDefault();
            if (identifiedTask == null)
            {
                return null;
            }
            return identifiedTask;
        }
    }
}
