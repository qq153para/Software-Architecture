using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using Tasks.Concole;

namespace Tasks.Entity
{
    public class TaskList
    {
        private readonly List<Project> projectList;
        private static TaskList taskList = null;
        private int Id = 0;

        protected TaskList() 
        {
            projectList = new List<Project>();
        }

        public TaskId NextId()
        {
            return TaskId.Of(++Id) ;
        }
        public void AddProject(ProjectName name)
        {
            Project project = new Project(name, new List<Task>());
            projectList.Add(project);
        }

        public void AddTask(ProjectName projectName, string description)
        {
            Project project = GetProjectByProjectName(projectName);
            project.AddTask(description, NextId());
        }

        public bool SetDoneById(TaskId id , bool done)
        {
            var task = projectList
               .Select(project => project.GetTasks().FirstOrDefault(task => task.GetId() == id))
               .Where(task => task != null)
               .FirstOrDefault();
            if (task == null)
            {
                return false;
            }
            task.SetDone(done);
            return true;
        }
        public static TaskList GetTaskList()
        {
            if (taskList == null)
            {
                taskList = new TaskList();
            }
            return taskList;
        }
        public List<Task> GetTasks(ProjectName projectName)
        {
            var project = 
            projectList.Where(project => project.GetName().Equals(projectName))
                    .FirstOrDefault();
            if (project == null)
            {
                return null;
            }
            return project.GetTasks().Select(t => (Task) new ReadOnlyTask(t.GetId(), t.GetDescription(), t.IsDone())).ToList();
        }
        public bool CheckProjectName(ProjectName projectName)
        {
            foreach (Project project in projectList)
            {
                if (project.GetName() == projectName)
                {
                    return true;
                }
            }
            return false;
        }

        public IReadOnlyList<Project> GetProjects()
        {
            return projectList.Select(p => new ReadOnlyProject(p.GetName(), p.GetTasks())).ToList();
        }

        private Project GetProjectByProjectName(ProjectName projectName)
        {
            foreach (Project project in projectList)
            {
                if (project.GetName() == projectName)
                {
                    return project;
                }
            }
            return null;
        }
    }
}
