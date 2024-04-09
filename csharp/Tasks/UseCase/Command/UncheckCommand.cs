using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tasks.Concole;
using Tasks.Entity;
using Tasks.UseCase.port.input;
using Tasks.UseCase.port.UseCaseOutput;

namespace Tasks.UseCase.Command
{
    public class UncheckCommand : ICommand<UncheckInput, UseCaseOutput>
    {
        public UseCaseOutput Execute(UncheckInput input)
        {
            UseCaseOutput UseCaseOutputData = new UseCaseOutput();
            TaskList taskList = TaskList.GetTaskList();
            bool Done = false;
            TaskId taskid = input.getTaskId(); 
            var IsSuccess = taskList.SetDoneById(taskid, Done);

            if (IsSuccess == false)
            {
                string formattedString = string.Format("Could not find a task with an ID of {0}.", taskid);
                UseCaseOutputData.setMessage(formattedString);
                return UseCaseOutputData;
            }
            return UseCaseOutputData;
        }

    }
}
