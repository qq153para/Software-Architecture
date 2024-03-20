using System;
using System.Collections.Generic;
using System.Text;
using Tasks.Concole;
using Tasks.Entity;
using Tasks.UseCase.Message;

namespace Tasks.UseCase.Command
{
    public class ShowCommand : ICommand
    {
        public ReturnMessage Execute(string commandRest)
        {
            ReturnMessage returnMessage = new ReturnMessage();
            TaskList taskList = TaskList.GetTaskList();
            IDictionary<string, IList<Task>> tasks = taskList.GetTasks();
            foreach (var project in tasks)
            {
                returnMessage.AddMessage(project.Key);
                foreach (var task in project.Value)
                {
                    string formattedString = string.Format("    [{0}] {1}: {2}", task.Done ? 'x' : ' ', task.Id, task.Description);
                    returnMessage.AddMessage(formattedString);
                }
                returnMessage.AddMessage(string.Empty);
            }
            return returnMessage;
        }
    }
}
