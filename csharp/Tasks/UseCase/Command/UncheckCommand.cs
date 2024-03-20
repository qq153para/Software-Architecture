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
        public ReturnMessage Execute(string taskid)
        {
            ReturnMessage returnMessage = new ReturnMessage();
            TaskList taskList = TaskList.GetTaskList();
            bool Done = false;
            var task = taskList.FindTask(taskid);

            if (task == null)
            {
                string formattedString = string.Format("Could not find a task with an ID of {0}.", taskid);
                returnMessage.AddMessage(formattedString);
                return returnMessage;
            }
            task.Done = Done;
            return returnMessage;
        }

    }
}
