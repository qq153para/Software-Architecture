using System;
using System.Collections.Generic;
using System.Text;
using Tasks.Concole;
using Tasks.Entity;
using Tasks.UseCase.port.input;
using Tasks.UseCase.port.UseCaseOutput;

namespace Tasks.UseCase.Command
{
    public class ShowCommand : ICommand<ShowInput, UseCaseOutput>
    {
        public UseCaseOutput Execute(ShowInput input)
        {
            UseCaseOutput UseCaseOutputData = new UseCaseOutput();
            TaskList taskList = TaskList.GetTaskList();
            IReadOnlyList<Project> ProjectList = taskList.GetProjects();
            foreach (var project in ProjectList)
            {
                UseCaseOutputData.setMessage(project.GetName().ToString());
                foreach (var task in project.GetTasks())
                {
                    string formattedString = string.Format("    [{0}] {1}: {2}", task.IsDone() ? 'x' : ' ', task.GetId(), task.GetDescription());
                    UseCaseOutputData.setMessage(formattedString);
                }
                UseCaseOutputData.setMessage(string.Empty);
            }
            return UseCaseOutputData;
        }
    }
}
