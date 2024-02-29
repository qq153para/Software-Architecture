using System;
using System.Collections.Generic;
using System.Linq;

namespace Tasks
{
    public sealed class TaskList
    {
        private const string QUIT = "quit";

        private readonly Dictionary<string, IList<Task>> tasks = new Dictionary<string, IList<Task>>();
        private readonly IConsole console;
        private readonly IDictionary<string, CommandBase> commands;


        public static void Main(string[] args)
        {
            new TaskList(new RealConsole()).Run();
        }

        public TaskList(IConsole console)
        {
            this.console = console;
            this.commands = new Dictionary<string, CommandBase>
            {
                {"show", new ViewByProjectCommand(this, console, tasks)},
                {"add", new AddCommand(this, console, tasks)},
                {"check", new CheckCommand(this, console, tasks)},
                {"uncheck", new UncheckCommand(this, console, tasks)},
                {"help", new HelpCommand(this, console, tasks)},
                {"setdeadline", new SetDeadlineCommand(this, console, tasks)},
                {"today", new TodayCommand(this, console, tasks)},
                {"delete", new DeleteCommand(this, console, tasks)},
                {"viewbydate", new ViewByDateCommand(this, console, tasks)},
                {"viewbydeadline", new ViewByDeadlineCommand(this, console, tasks)}
            };
        }

        public void Run()
        {
            while (true)
            {
                console.Write("> ");
                var command = console.ReadLine();
                if (command == QUIT)
                {
                    break;
                }
                Execute(command);
            }
        }

        private void Execute(string commandLine)
        {
            var commandRest = commandLine.Split(" ".ToCharArray(), 2);
            var commandkey = commandRest[0];
            if (commands.ContainsKey(commandkey))
            {
                if (commandRest.Length >= 2)
                {
                    commands[commandkey].Execute(commandRest[1]);
                }
                else
                {
                    commands[commandkey].Execute("");
                }

            }
            else
            {
                Error(commandkey);
            }
        }

        private void Error(string command)
        {
            console.WriteLine("I don't know what the command \"{0}\" is.", command);
        }

    }
}
