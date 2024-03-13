using System;
using System.Collections.Generic;
using System.Text;
using Tasks.Entity;

namespace Tasks.UseCase
{
    public class HelpCommand : CommandBase
    {

        public HelpCommand(IDictionary<string, IList<Task>> tasks) : base(tasks) { }

        public override List<string> Execute(string commandRest)
        {
            List<string> CommandReturn = new List<string>();
            CommandReturn.Add("Commands:");
            CommandReturn.Add("  show");
            CommandReturn.Add("  add project <project name>");
            CommandReturn.Add("  add task <project name> <task description>");
            CommandReturn.Add("  check <task ID>");
            CommandReturn.Add("  uncheck <task ID>");
            CommandReturn.Add(string.Empty);
            return CommandReturn;

        }
    }
}
