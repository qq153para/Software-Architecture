using System;
using System.Collections.Generic;
using System.Text;
using Tasks.Concole;
using Tasks.Entity;

namespace Tasks.UseCase
{
    public class ErrorCommand : CommandBase
    {

        public ErrorCommand(IDictionary<string, IList<Task>> tasks)
                    : base( tasks) { }

        public override List<string> Execute(string commandRest)
        {
            List<string> CommandReturn = new List<string>();
            string formattedString = string.Format("I don't know what the command \"{0}\" is.", commandRest);
            CommandReturn.Add(formattedString);
            return CommandReturn;
        }
    }
}
