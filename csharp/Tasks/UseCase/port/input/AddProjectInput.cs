using System;
using System.Collections.Generic;
using System.Text;
using Tasks.Entity;

namespace Tasks.UseCase.port.input
{
    public class AddProjectInput : IUseCaseInput
    {
        private ProjectName projectName;

        public void setProjectName(string projectName)
        {
            this.projectName = ProjectName.Of(projectName);
        }

        public ProjectName getProjectName()
        {
            return projectName;
        }
    }
}
