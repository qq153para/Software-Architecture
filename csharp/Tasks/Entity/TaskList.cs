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
        private readonly List<Project> projectList = new List<Project>();
        private static TaskList taskList = null;

        private int Id = 0;

        protected TaskList() { }

        public int NextId()
        {
            return ++Id ;
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

        public void SetDone(Task task , bool done)
        {
            task.SetDone(done);
        }
        public static TaskList GetTaskList()
        {
            if (taskList == null)
            {
                taskList = new TaskList();
            }
            return taskList;
        }
        public Task GetTaskById(long id)
        {
            var identifiedTask = projectList
                .Select(project => project.GetTasks().FirstOrDefault(task => task.Id == id))
                .Where(task => task != null)
                .FirstOrDefault();
            if (identifiedTask == null)
            {
                return null;
            }
            return identifiedTask;
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
            return projectList.AsReadOnly();
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
