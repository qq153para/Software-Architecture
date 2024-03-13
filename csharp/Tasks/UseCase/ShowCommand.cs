using System;
using System.Collections.Generic;
using System.Text;
using Tasks.Concole;
using Tasks.Entity;

namespace Tasks.UseCase
{
    public class ShowCommand : CommandBase
    {
        public ShowCommand(IDictionary<string, IList<Task>> tasks) : base(tasks) { }

        public override List<string> Execute(string commandRest)
        {
            List<string> CommandReturn = new List<string>();
            foreach (var project in tasks)
            {
                CommandReturn.Add(project.Key);
                foreach (var task in project.Value)
                {
                    string formattedString = string.Format("    [{0}] {1}: {2}", task.Done ? 'x' : ' ', task.Id, task.Description);
                    CommandReturn.Add(formattedString);
                }
                CommandReturn.Add(string.Empty);
            }
            return CommandReturn;
        }
    }
}
