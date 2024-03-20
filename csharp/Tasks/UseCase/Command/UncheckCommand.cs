using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Tasks.Concole;
using Tasks.Entity;
using Tasks.UseCase.Message;

namespace Tasks.UseCase.Command
{
    public class UncheckCommand : ICommand
    {
        public ReturnMessage Execute(string commandRest)
        {

            return SetDone(commandRest, false);
        }
        protected Task FindTask(string idString)
        {
            TaskList taskList = TaskList.GetTaskList();
            IDictionary<string, IList<Task>> tasks = taskList.GetTasks();
            int id = int.Parse(idString);
            var identifiedTask = tasks
                .Select(project => project.Value.FirstOrDefault(task => task.Id == id))
                .Where(task => task != null)
                .FirstOrDefault();

            return identifiedTask;
        }
        protected ReturnMessage SetDone(string idString, bool done)
        {
            ReturnMessage returnMessage = new ReturnMessage();
            var identifiedTask = FindTask(idString);
            if (identifiedTask == null)
            {
                string formattedString = string.Format("Could not find a task with an ID of {0}.", idString);
                returnMessage.AddMessage(formattedString);
            }
            identifiedTask.Done = done;
            return returnMessage;
        }

    }
}
