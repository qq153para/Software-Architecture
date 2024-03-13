using System.Collections.Generic;
using Tasks.Entity;
using Tasks.UseCase.Message;

namespace Tasks.UseCase.Command
{
    public class ErrorCommand : CommandBase
    {
        public override ReturnMessage Execute(string commandRest)
        {
            string formattedString = string.Format("I don't know what the command \"{0}\" is.", commandRest);
            returnmessage.AddMessage(formattedString);
            return returnmessage;
        }
    }
}
