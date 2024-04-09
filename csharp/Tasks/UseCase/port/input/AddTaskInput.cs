using System;
using System.Collections.Generic;
using System.Text;
using Tasks.Entity;

namespace Tasks.UseCase.port.input
{
    public class AddTaskInput : IUseCaseInput
    {
        private ProjectName projectName;
        private string taskDescription;

        public void setProjectName(string projectName)
        {
            this.projectName = ProjectName.Of(projectName);
        }

        public ProjectName getProjectName()
        {
            return projectName;
        }
        public void setTaskDescription(string taskDescription)
        {
            this.taskDescription = taskDescription;
        }

        public string getTaskDescription()
        {
            return taskDescription;
        }
    }
}
