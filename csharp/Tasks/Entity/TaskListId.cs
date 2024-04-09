using System;
using System.Collections.Generic;
using System.Text;

namespace Tasks.Entity
{
    public class TaskListId
    {
        private readonly string taskListId;

        private TaskListId(string taskListId)
        {
            this.taskListId = taskListId;
        }

        public static TaskListId Of(long id)
        {
            return new TaskListId(id.ToString());
        }

        public override string ToString()
        {
            return taskListId;
        }

        public static bool operator ==(TaskListId taskId_1, TaskListId taskId_2)
        {
            return taskId_1.ToString() == taskId_2.ToString();
        }
        public static bool operator !=(TaskListId taskId_1, TaskListId taskId_2)
        {
            return taskId_1.ToString() != taskId_2.ToString();
        }
        public override bool Equals(object obj)
        {
            return obj is TaskListId name && taskListId == name.taskListId;
        }
        public override int GetHashCode()
        {
            return HashCode.Combine(taskListId);
        }
    }
}
