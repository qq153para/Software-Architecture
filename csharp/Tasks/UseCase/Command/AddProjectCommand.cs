using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Linq;
using Tasks.Entity;
using Tasks.UseCase.Message;

namespace Tasks.UseCase.Command
{
    public class AddProjectCommand : ICommand
    {
        public ReturnMessage Execute(string name)
        {
            var returnmessage = new ReturnMessage();
            TaskList taskList = TaskList.GetTaskList();
            IDictionary<string, IList<Task>> tasks = taskList.GetTasks();
            tasks[name] = new List<Task>();
            return returnmessage;
        }
    }
}
