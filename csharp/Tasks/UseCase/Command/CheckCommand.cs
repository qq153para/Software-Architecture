using System.Collections.Generic;
using Tasks.Entity;
using Tasks.UseCase.Message;

namespace Tasks.UseCase.Command
{
    public class CheckCommand : CommandBase
    {
        public override ReturnMessage Execute(string commandRest)
        {
            SetDone(commandRest, true);
            return returnmessage;
        }

    }
}
