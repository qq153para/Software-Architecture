using System;
using System.Collections.Generic;
using System.Text;
using Tasks.Entity;
using Tasks.UseCase.Message;

namespace Tasks.UseCase.Command
{
    public class HelpCommand : ICommand
    {
        public ReturnMessage Execute(string commandRest)
        {
            ReturnMessage returnMessage = new ReturnMessage();
            returnMessage.AddMessage("Commands:");
            returnMessage.AddMessage("  show");
            returnMessage.AddMessage("  add project <project name>");
            returnMessage.AddMessage("  add task <project name> <task description>");
            returnMessage.AddMessage("  check <task ID>");
            returnMessage.AddMessage("  uncheck <task ID>");
            returnMessage.AddMessage(string.Empty);
            return returnMessage;

        }
    }
}
