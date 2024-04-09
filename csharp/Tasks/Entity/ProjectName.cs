using System;
using System.Collections.Generic;
using System.Text;

namespace Tasks.Entity
{
    public class ProjectName
    {
        private readonly string projectName;

        private ProjectName(string projectName)
        {
            this.projectName = projectName;
        }

        public static ProjectName Of(string projectName)
        {
            return new ProjectName(projectName);
        }
        public override string ToString()
        {
            return projectName;
        }

        public static bool operator ==(ProjectName ProjectName_1, ProjectName ProjectName_2)
        {
            return ProjectName_1.ToString() == ProjectName_2.ToString();
        }
        public static bool operator !=(ProjectName ProjectName_1, ProjectName ProjectName_2)
        {
            return ProjectName_1.ToString() != ProjectName_2.ToString();
        }
        public override bool Equals(object obj)
        {
            return obj is ProjectName name && projectName == name.projectName;
        }
        public override int GetHashCode()
        {
            return HashCode.Combine(projectName);
        }
    }
}
