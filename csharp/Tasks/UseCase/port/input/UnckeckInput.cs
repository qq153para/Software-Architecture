using System;
using System.Collections.Generic;
using System.Text;

namespace Tasks.UseCase.port.input
{
    public class UncheckInput : IUseCaseInput
    {
        private long taskId;

        public void setTaskId(long taskId)
        {
            this.taskId = taskId;
        }

        public long getTaskId()
        {
            return taskId;
        }

    }
}
