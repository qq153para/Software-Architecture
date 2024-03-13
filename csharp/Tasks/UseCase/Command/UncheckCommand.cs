using System;
using System.Collections.Generic;
using System.Text;
using Tasks.Concole;
using Tasks.Entity;
using Tasks.UseCase.Message;

namespace Tasks.UseCase.Command
{
    public class UncheckCommand : CommandBase
    {
        public override ReturnMessage Execute(string commandRest)
        {
            SetDone(commandRest, false);
            return returnmessage;
        }

    }
}
