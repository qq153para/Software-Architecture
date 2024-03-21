using System;
using System.Collections.Generic;
using System.Text;
using Tasks.Entity;
using Tasks.UseCase.port.input;
using Tasks.UseCase.port.UseCaseOutput;

namespace Tasks.UseCase.Command
{
    public class AddTaskCommand : ICommand<AddTaskInput, UseCaseOutput>
    {
        public UseCaseOutput Execute(AddTaskInput input)
        {
            TaskList taskList = TaskList.GetTaskList();
            IDictionary<string, IList<Task>> tasks = taskList.GetTasks();
            string project = input.getProjectName();
            string description = input.getTaskDescription();
            var UseCaseOutputData = new UseCaseOutput();

            if (!tasks.TryGetValue(project, out IList<Task> projectTasks))
            {
                string formattedString = string.Format("Could not find a project with the name \"{0}\".", project);
                UseCaseOutputData.setMessage(formattedString);
                return UseCaseOutputData;
            }
            int id = taskList.NextId();
            projectTasks.Add(new Task { Id = id, Description = description, Done = false });
            return UseCaseOutputData;
        }
    }
}
