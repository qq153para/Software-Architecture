using System;
using System.Collections.Generic;
using System.Text;
using Tasks.Entity;
using Tasks.UseCase.Message;

namespace Tasks.UseCase.Command
{
    public class AddTaskCommand : ICommand
    {
        public ReturnMessage Execute(string commandRest)
        {
            TaskList taskList = TaskList.GetTaskList();
            IDictionary<string, IList<Task>> tasks = taskList.GetTasks();
            var TaskToken = commandRest.Split(" ".ToCharArray(), 2);
            string project = TaskToken[0];
            string description = TaskToken[1];
            var returnMessage = new ReturnMessage();
            if (!tasks.TryGetValue(project, out IList<Task> projectTasks))
            {
                string formattedString = string.Format("Could not find a project with the name \"{0}\".", project);
                returnMessage.AddMessage(formattedString);
                return returnMessage;
            }
            int id = taskList.NextId();
            projectTasks.Add(new Task { Id = id, Description = description, Done = false });
            return returnMessage;
        }
    }
}
