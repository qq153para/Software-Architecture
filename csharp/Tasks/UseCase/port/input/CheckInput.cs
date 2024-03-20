using System;
using System.Collections.Generic;
using System.Text;

namespace Tasks.UseCase.port.input
{
    public class CheckInput :  IUseCaseInput
    {
        private string taskId;

        public void setTaskId(string taskId)
        {
            this.taskId = taskId;
        }

        public string getTaskId()
        {
            return taskId;
        }
    }
}
