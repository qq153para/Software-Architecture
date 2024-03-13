using System.Collections.Generic;
using Tasks.Entity;

namespace Tasks.UseCase
{
    public class CheckCommand : CommandBase
    {

        public CheckCommand(IDictionary<string, IList<Task>> tasks) : base(tasks) { }


        public override List<string> Execute(string commandRest)
        {
            return SetDone(commandRest, true);
        }

    }
}
