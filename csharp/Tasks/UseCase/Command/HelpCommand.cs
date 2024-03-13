using System;
using System.Collections.Generic;
using System.Text;
using Tasks.Entity;
using Tasks.UseCase.Message;

namespace Tasks.UseCase.Command
{
    public class HelpCommand : CommandBase
    {
        public override ReturnMessage Execute(string commandRest)
        {
            //returnmessage.RemoveMessage();
            returnmessage.AddMessage("Commands:");
            returnmessage.AddMessage("  show");
            returnmessage.AddMessage("  add project <project name>");
            returnmessage.AddMessage("  add task <project name> <task description>");
            returnmessage.AddMessage("  check <task ID>");
            returnmessage.AddMessage("  uncheck <task ID>");
            returnmessage.AddMessage(string.Empty);
            return returnmessage;

        }
    }
}
