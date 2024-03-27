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
            ProjectName project = input.getProjectName();
            string description = input.getTaskDescription();
            var UseCaseOutputData = new UseCaseOutput();

            if (!taskList.CheckProjectName(project))
            {
                string formattedString = string.Format("Could not find a project with the name \"{0}\".", project);
                UseCaseOutputData.setMessage(formattedString);
                return UseCaseOutputData;
            }
            taskList.AddTask(project, description);
            return UseCaseOutputData;
        }
    }
}
