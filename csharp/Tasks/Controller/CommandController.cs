using System;
using System.Collections.Generic;
using Tasks.Entity;
using Tasks.UseCase.Command;
using Tasks.UseCase.Message;

namespace Tasks.Controller
{
    public class CommandController
    {
        public List<string> Execute(String commandLine)
        {
            var commandRest = commandLine.Split(" ".ToCharArray(), 2);
            var command = commandRest[0];
            ReturnMessage CommandReturn;
            switch (command)
            {
                case "show":
                    CommandReturn = new ShowCommand().Execute("");
                    break;
                case "add":
                    var subcommandRest = commandRest[1].Split(" ".ToCharArray(), 2);
                    var subcommand = subcommandRest[0];
                    CommandReturn = new ReturnMessage();
                    if (subcommand == "project")
                    {
                        CommandReturn = new AddProjectCommand().Execute(subcommandRest[1]);
                    }
                    else if (subcommand == "task")
                    {
                        CommandReturn = new AddTaskCommand().Execute(subcommandRest[1]);
                    }
                    break;
                case "check":
                    CommandReturn = new CheckCommand().Execute(commandRest[1]);
                    break;
                case "uncheck":
                    CommandReturn = new UncheckCommand().Execute(commandRest[1]);
                    break;
                case "help":
                    CommandReturn = new HelpCommand().Execute("");
                    break;
                default:
                    CommandReturn = new ErrorCommand().Execute("");
                    break;
            }
            return CommandReturn.getMessage();
        }
    }
}
