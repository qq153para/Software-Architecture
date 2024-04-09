using System;
using System.Collections.Generic;
using System.Text;

namespace Tasks.Entity
{
        public class ReadOnlyTask : Task
        {
            public ReadOnlyTask(TaskId id, string description, bool done) : base(id, description, done) { }

            public override void SetDone(bool done)
            {
                throw new InvalidOperationException("Cannot modify Done property in ReadOnlyTask.");
            }
        }
}
