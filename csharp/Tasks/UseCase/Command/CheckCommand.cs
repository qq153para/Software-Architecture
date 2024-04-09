using System.Collections.Generic;
using System.Linq;
using Tasks.Entity;
using Tasks.UseCase.port.input;
using Tasks.UseCase.port.UseCaseOutput;

namespace Tasks.UseCase.Command
{
    public class CheckCommand : ICommand<CheckInput, UseCaseOutput>
    {
        public UseCaseOutput Execute(CheckInput input)
        {
            UseCaseOutput UseCaseOutputData = new UseCaseOutput();
            TaskList taskList = TaskList.GetTaskList();
            bool Done = true;
            TaskId taskId = input.getTaskId();
            var IsSuccess = taskList.SetDoneById(taskId, Done);

            if (IsSuccess == false)
            {
                string formattedString = string.Format("Could not find a task with an ID of {0}.", taskId);
                UseCaseOutputData.setMessage(formattedString);
                return UseCaseOutputData;
            }
            return UseCaseOutputData;
        }

    }
}
