using System;
using System.Collections.Generic;
using System.Text;
using Tasks.Concole;
using Tasks.Entity;
using Tasks.UseCase;

namespace Tasks.Controller
{
    public class CommandController
    {
        private readonly IConsole console;
        private readonly IDictionary<string, IList<Task>> tasks = new Dictionary<string, IList<Task>>();
        private readonly IDictionary<string, CommandBase> commands;
        public CommandController(IConsole console)
        {
            this.console = console;
            this.commands = new Dictionary<string, CommandBase>
            {
                {"show", new ShowCommand( tasks)},
                {"add", new AddCommand( tasks)},
                {"check", new CheckCommand( tasks)},
                {"uncheck", new UncheckCommand( tasks)},
                {"help", new HelpCommand( tasks)}
            };
        }

        public void Execute(String commandLine)
        {
            var commandRest = commandLine.Split(" ".ToCharArray(), 2);
            var commandkey = commandRest[0];
            if (commands.ContainsKey(commandkey))
            {
                var CommandReturn = new List<string>(); ; 
                if (commandRest.Length >= 2)
                {
                    CommandReturn = commands[commandkey].Execute(commandRest[1]);
                }
                else
                {
                    CommandReturn = commands[commandkey].Execute("");
                }

                foreach (string str in CommandReturn)
                {
                    console.WriteLine(str);
                }
            }

        }
    }
}
