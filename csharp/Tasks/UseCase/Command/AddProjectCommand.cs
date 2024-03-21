using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Linq;
using Tasks.Entity;
using Tasks.UseCase.port.input;
using Tasks.UseCase.port.UseCaseOutput;

namespace Tasks.UseCase.Command
{
    public class AddProjectCommand : ICommand<AddProjectInput, UseCaseOutput>
    {
        public UseCaseOutput Execute(AddProjectInput input)
        {
            var UseCaseOutputData = new UseCaseOutput();
            string name = input.getProjectName();
            TaskList taskList = TaskList.GetTaskList();
            IDictionary<string, IList<Task>> tasks = taskList.GetTasks();
            tasks[name] = new List<Task>();
            return UseCaseOutputData;
        }
    }
}
