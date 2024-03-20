using System.Collections.Generic;
using System.Linq;
using Tasks.Entity;
using Tasks.UseCase.port.input;
using Tasks.UseCase.port.UseCaseOutput;

namespace Tasks.UseCase.Command
{
    public class CheckCommand : IUseCase<CheckInput, UseCaseOutput>
    {
        public UseCaseOutput Execute(CheckInput input)
        {
            UseCaseOutput UseCaseOutputData = new UseCaseOutput();
            TaskList taskList = TaskList.GetTaskList();
            bool Done = true;
            string taskId = input.getTaskId();
            var task = taskList.FindTask(taskId);

            if (task == null)
            {
                string formattedString = string.Format("Could not find a task with an ID of {0}.", taskId);
                UseCaseOutputData.setMessage(formattedString);
                return UseCaseOutputData;
            }
            task.Done = Done;
            return UseCaseOutputData;
        }

    }
}
