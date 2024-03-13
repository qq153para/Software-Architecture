using System;
using System.Collections.Generic;
using System.Text;
using Tasks.Concole;
using Tasks.Entity;

namespace Tasks.UseCase
{
    public class UncheckCommand : CommandBase
    {

        public UncheckCommand(IDictionary<string, IList<Task>> tasks) : base(tasks) { }

        public override List<string> Execute(string commandRest)
        {
            return SetDone(commandRest, false);
        }

    }
}
