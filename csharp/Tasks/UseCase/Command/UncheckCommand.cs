using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Tasks.Concole;
using Tasks.Entity;
using Tasks.UseCase.port.input;
using Tasks.UseCase.port.UseCaseOutput;

namespace Tasks.UseCase.Command
{
    public class UncheckCommand : IUseCase<UncheckInput, UseCaseOutput>
    {
        public UseCaseOutput Execute(UncheckInput input)
        {
            UseCaseOutput UseCaseOutputData = new UseCaseOutput();
            TaskList taskList = TaskList.GetTaskList();
            bool Done = false;
            string taskid = input.getTaskId(); 
            var task = taskList.FindTask(taskid);

            if (task == null)
            {
                string formattedString = string.Format("Could not find a task with an ID of {0}.", taskid);
                UseCaseOutputData.setMessage(formattedString);
                return UseCaseOutputData;
            }
            task.Done = Done;
            return UseCaseOutputData;
        }

    }
}
