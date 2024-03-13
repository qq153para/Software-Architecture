using System.Collections.Generic;
using System.Linq;
using Tasks.Entity;
using Tasks.UseCase.Message;

namespace Tasks.UseCase.Command
{
    public abstract class CommandBase
    {
        protected static TaskList tasklist = new TaskList();
        protected ReturnMessage returnmessage = new ReturnMessage();
        protected static IDictionary<string, IList<Task>> tasks = tasklist.GetTasks();

        public abstract ReturnMessage Execute(string commandRest);

        protected Task FindTask(string idString)
        {
            int id = int.Parse(idString);
            var identifiedTask = tasks
                .Select(project => project.Value.FirstOrDefault(task => task.Id == id))
                .Where(task => task != null)
                .FirstOrDefault();

            return identifiedTask;
        }
        protected void SetDone(string idString, bool done)
        {
            var identifiedTask = FindTask(idString);
            if (identifiedTask == null)
            {
                string formattedString = string.Format("Could not find a task with an ID of {0}.", idString);
                returnmessage.AddMessage(formattedString);
            }
            identifiedTask.Done = done;
        }

    }
}