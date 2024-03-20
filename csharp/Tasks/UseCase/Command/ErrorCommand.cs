using System.Collections.Generic;
using Tasks.Entity;
using Tasks.UseCase.Message;

namespace Tasks.UseCase.Command
{
    public class ErrorCommand : ICommand
    {
        public ReturnMessage Execute(string commandRest)
        {
            ReturnMessage returnMessage = new ReturnMessage();
            string formattedString = string.Format("I don't know what the command \"{0}\" is.", commandRest);
            returnMessage.AddMessage(formattedString);
            return returnMessage;
        }
    }
}
