using System.Collections.Generic;
using System.Linq;
using Tasks.Entity;

namespace Tasks
{
    public abstract class CommandBase
    {
        public readonly IDictionary<string, IList<Task>> tasks;
        public int id = 1;
        public CommandBase(IDictionary<string, IList<Task>> tasks)
        {
            this.tasks = tasks;
        }

        public abstract List<string> Execute(string commandRest);
        protected Task FindTask(string idString)
        {
            int id = int.Parse(idString);
            var identifiedTask = tasks
                .Select(project => project.Value.FirstOrDefault(task => task.Id == id))
                .Where(task => task != null)
                .FirstOrDefault();

            return identifiedTask;
        }
        protected List<string> SetDone(string idString, bool done)
        {
            List<string> CommandReturn = new List<string>();
            var identifiedTask = FindTask(idString);
            if (identifiedTask == null)
            {
                string formattedString = string.Format("Could not find a task with an ID of {0}.", idString);
                CommandReturn.Add(formattedString);
                return CommandReturn;
            }
            identifiedTask.Done = done;
            return CommandReturn;
        }

    }
}