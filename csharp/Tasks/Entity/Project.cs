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

        public IReadOnlyList<Task> GetTasks()
        {
            return tasks.AsReadOnly();
        }

        public void AddTask(string description, long id)
        {
            Task task = new Task(id, description, false);
            tasks.Add(task);
        }
    }
}
