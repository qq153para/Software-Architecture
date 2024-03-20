using System;
using System.Collections.Generic;
using System.Text;

namespace Tasks.UseCase.port.UseCaseOutput
{
    public class UseCaseOutput
    {
        private List<string> commandMessage = new List<string>();

        public void setMessage(string msg)
        {
            commandMessage.Add(msg);
        }

        public List<string> getMessage()
        {
            return commandMessage;
        }

    }
}
