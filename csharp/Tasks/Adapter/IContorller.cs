using System;
using System.Collections.Generic;
using System.Text;

namespace Tasks.Adapter
{
    public interface IContorller
    {
        public List<string> Execute(string executeCommand);
    }
}
