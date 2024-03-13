using System;
using System.Collections.Generic;
using System.Text;
using Tasks.Concole;
using Tasks.Entity;
using Tasks.UseCase.Message;

namespace Tasks.UseCase.Command
{
    public class ShowCommand : CommandBase
    {
        public override ReturnMessage Execute(string commandRest)
        {
            //returnmessage.RemoveMessage();
            foreach (var project in tasks)
            {
                returnmessage.AddMessage(project.Key);
                foreach (var task in project.Value)
                {
                    string formattedString = string.Format("    [{0}] {1}: {2}", task.Done ? 'x' : ' ', task.Id, task.Description);
                    returnmessage.AddMessage(formattedString);
                }
                returnmessage.AddMessage(string.Empty);
            }
            return returnmessage;
        }
    }
}
