using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tasks.Entity
{
    public class ReadOnlyProject : Project
    {
        public ReadOnlyProject(ProjectName name, List<Task> tasks): base(name, tasks) { }


        public override void AddTask(string description, TaskId id)
        {
            throw new InvalidOperationException("Cannot modify Done property in ReadOnlyTask.");
        }

    }
}
