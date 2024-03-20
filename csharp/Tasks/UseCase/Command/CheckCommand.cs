using System.Collections.Generic;
using System.Linq;
using Tasks.Entity;
using Tasks.UseCase.Message;

namespace Tasks.UseCase.Command
{
    public class CheckCommand : ICommand
    {
        public ReturnMessage Execute(string taskId)
        {
            ReturnMessage returnMessage = new ReturnMessage();
            TaskList taskList = TaskList.GetTaskList();
            bool Done = true;
            var task = taskList.FindTask(taskId);

            if (task == null)
            {
                string formattedString = string.Format("Could not find a task with an ID of {0}.", taskId);
                returnMessage.AddMessage(formattedString);
                return returnMessage;
            }
            task.Done = Done;
            return returnMessage;
        }

    }
}
