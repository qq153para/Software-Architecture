using System;
using System.Collections.Generic;
using System.Text;

namespace Tasks.Entity
{
    public class TaskId
    {
        private readonly string taskId;

        private TaskId(string taskId)
        {
            this.taskId = taskId;
        }

        public static TaskId Of(long id)
        {
            return new TaskId(id.ToString());
        }

        public override string ToString()
        {
            return taskId;
        }

        public static bool operator ==(TaskId taskId_1, TaskId taskId_2)
        {
            return taskId_1.ToString() == taskId_2.ToString();
        }
        public static bool operator !=(TaskId taskId_1, TaskId taskId_2)
        {
            return taskId_1.ToString() != taskId_2.ToString();
        }
        public override bool Equals(object obj)
        {
            return obj is TaskId  name && taskId == name.taskId;
        }
        public override int GetHashCode()
        {
            return HashCode.Combine(taskId);
        }
    }
}
