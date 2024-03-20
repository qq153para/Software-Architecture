using System;
using System.Collections.Generic;
using System.Text;

namespace Tasks.UseCase.port.input
{
    public class AddProjectInput : IUseCaseInput
    {
        private string projectName;

        public void setProjectName(string projectName)
        {
            this.projectName = projectName;
        }

        public string getProjectName()
        {
            return projectName;
        }
    }
}
