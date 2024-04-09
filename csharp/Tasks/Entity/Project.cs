using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Tasks.Entity
{
    public class Project
    {
        private readonly ProjectName projectName;
        private readonly List<Task> tasks;

        public Project(ProjectName name, List<Task> tasks)
        {
            this.projectName = name;
            this.tasks = tasks;
        }

        public ProjectName GetName()
        {
            return projectName;
        }

        public List<Task> GetTasks()
        {
            return tasks;
        }

        public virtual void AddTask(string description, TaskId id)
        {
            Task task = new Task(id, description, false);
            tasks.Add(task);
        }
    }
}
