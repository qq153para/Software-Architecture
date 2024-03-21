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
            IDictionary<string, IList<Task>> tasks = taskList.GetTasks();
            foreach (var project in tasks)
            {
                UseCaseOutputData.setMessage(project.Key);
                foreach (var task in project.Value)
                {
                    string formattedString = string.Format("    [{0}] {1}: {2}", task.Done ? 'x' : ' ', task.Id, task.Description);
                    UseCaseOutputData.setMessage(formattedString);
                }
                UseCaseOutputData.setMessage(string.Empty);
            }
            return UseCaseOutputData;
        }
    }
}
