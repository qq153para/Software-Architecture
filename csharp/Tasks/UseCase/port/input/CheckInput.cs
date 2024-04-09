using System;
using System.Collections.Generic;
using System.Text;
using Tasks.Entity;

namespace Tasks.UseCase.port.input
{
    public class CheckInput :  IUseCaseInput
    {
        private TaskId taskId;

        public void setTaskId(long taskId)
        {
            this.taskId = TaskId.Of(taskId);
        }

        public TaskId getTaskId()
        {
            return taskId;
        }
    }
}
