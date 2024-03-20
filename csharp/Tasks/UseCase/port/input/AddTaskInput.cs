using System;
using System.Collections.Generic;
using System.Text;

namespace Tasks.UseCase.port.input
{
    public class AddTaskInput : IUseCaseInput
    {
        private string projectName;
        private string taskDescription;

        public void setProjectName(string projectName)
        {
            this.projectName = projectName;
        }

        public string getProjectName()
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
