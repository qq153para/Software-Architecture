using System;
using System.Collections.Generic;
using System.Text;

namespace Tasks.UseCase.port.input
{
    public class ErrorInput : IUseCaseInput
    {
        private string unKnownCommand;

        public void setUnKnownCommand(string unKnownCommand)
        {
            this.unKnownCommand = unKnownCommand;
        }

        public string getUnKnownCommand()
        {
            return unKnownCommand;
        }
    }
}
