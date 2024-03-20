using System;
using System.Collections.Generic;
using Tasks.UseCase.Command;
using Tasks.UseCase.Message;

namespace Tasks.Controller
{
    public class CommandController
    {
        private IDictionary<string, ICommand> commands;

        private IDictionary<string, ICommand> GetCommands()
        {
            return new Dictionary<string, ICommand>
            {
                {"show", new ShowCommand()},
                {"add", new AddCommand()},
                {"check", new CheckCommand()},
                {"uncheck", new UncheckCommand()},
                {"help", new HelpCommand()},
                {"error", new ErrorCommand()}
            };
        }
        public List<string> Execute(String commandLine)
        {
            var commandRest = commandLine.Split(" ".ToCharArray(), 2);
            var commandkey = commandRest[0];
            var CommandReturn = new ReturnMessage();
            this.commands = GetCommands();
            if (commands.ContainsKey(commandkey))
            {   
                if (commandRest.Length >= 2)
                {
                    CommandReturn = commands[commandkey].Execute(commandRest[1]);
                }
                else
                {
                    CommandReturn = commands[commandkey].Execute("");
                }
            }
            return CommandReturn.getMessage();
        }
    }
}
