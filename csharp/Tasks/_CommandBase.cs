using System.Collections.Generic;
using System.Linq;

namespace Tasks
{
    public abstract class CommandBase
    {
        public readonly TaskList taskList;
        public readonly IConsole console;
        public readonly IDictionary<string, IList<Task>> tasks;
        public CommandBase(TaskList taskList, IConsole console, Dictionary<string, IList<Task>> tasks)
        {
            this.taskList = taskList;
            this.console = console;
            this.tasks = tasks;
        }

        public abstract void Execute(string commandRest);
        protected Task FindTask(string idString)
        {
            var identifiedTask = tasks
                .Select(project => project.Value.FirstOrDefault(task => task.Id == idString))
                .Where(task => task != null)
                .FirstOrDefault();

            return identifiedTask;
        }
        protected void SetDone(string idString, bool done)
        {
            var identifiedTask = FindTask(idString);
            if (identifiedTask == null)
            {
                console.WriteLine("Could not find a task with an ID of {0}.", idString);
                return;
            }
            identifiedTask.Done = done;
        }

    }
}