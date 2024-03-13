using System;
using System.Collections.Generic;
using System.Text;

namespace Tasks.UseCase.Message
{
    public class ReturnMessage
    {
        private List<string> CommandReturn = new List<string>();

        public void AddMessage(string msg)
        {
            CommandReturn.Add(msg);
        }

        public List<string> getMessage()
        {
            return CommandReturn;
        }
        public void RemoveMessage()
        {
            CommandReturn.Clear();
        }

    }
}
