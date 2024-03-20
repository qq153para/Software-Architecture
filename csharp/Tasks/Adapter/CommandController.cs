using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Tasks.Entity;
using Tasks.UseCase.Command;
using Tasks.UseCase.port.input;
using Tasks.UseCase.port.UseCaseOutput;

namespace Tasks.Controller
{
    public class CommandController
    {
        public List<string> Execute(String commandLine)
        {
            var commandRest = commandLine.Split(" ".ToCharArray(), 2);
            var command = commandRest[0];
            UseCaseOutput UseCaseOutputData;
            switch (command)
            {
                case "show":
                    ShowInput showInputData = new ShowInput();
                    UseCaseOutputData = new ShowCommand().Execute(showInputData);
                    break;
                case "add":
                    var subcommandRest = commandRest[1].Split(" ".ToCharArray(), 2);
                    var subcommand = subcommandRest[0];
                    UseCaseOutputData = new UseCaseOutput();
                    if (subcommand == "project")
                    {
                        AddProjectInput addProjectInput = new AddProjectInput();
                        addProjectInput.setProjectName(subcommandRest[1]);
                        UseCaseOutputData = new AddProjectCommand().Execute(addProjectInput);
                    }
                    else if (subcommand == "task")
                    {
                        var TaskToken = subcommandRest[1].Split(" ".ToCharArray(), 2);
                        string project = TaskToken[0];
                        string description = TaskToken[1];
                        AddTaskInput addTaskinput = new AddTaskInput();
                        addTaskinput.setProjectName(project);
                        addTaskinput.setTaskDescription(description);
                        UseCaseOutputData = new AddTaskCommand().Execute(addTaskinput);
                    }
                    break;
                case "check":
                    CheckInput checkInputData = new CheckInput();
                    checkInputData.setTaskId(commandRest[1]);
                    UseCaseOutputData = new CheckCommand().Execute(checkInputData);
                    break;
                case "uncheck":
                    UncheckInput uncheckInputData = new UncheckInput();
                    uncheckInputData.setTaskId(commandRest[1]);
                    UseCaseOutputData = new UncheckCommand().Execute(uncheckInputData);
                    break;
                case "help":
                    HelpInput helpInput = new HelpInput();
                    UseCaseOutputData = new HelpCommand().Execute(helpInput);
                    break;
                default:
                    ErrorInput errorInput = new ErrorInput();
                    errorInput.setUnKnownCommand(commandRest[1]);
                    UseCaseOutputData = new ErrorCommand().Execute(errorInput);
                    break;
            }
            return UseCaseOutputData.getMessage();
        }
    }
}
