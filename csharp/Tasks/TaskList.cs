using System;
using System.Collections.Generic;
using System.Linq;
using Tasks.Concole;
using Tasks.Controller;
using Tasks.Entity;
using Tasks.UseCase;

namespace Tasks
{
    public sealed class TaskList
    {
        private const string QUIT = "quit";

        private readonly IConsole console;
        private readonly CommandController commandController;
        private int id = 1;

        public static void Main(string[] args)
        {
            new TaskList(new RealConsole()).Run();
        }

        public TaskList(IConsole console)
        {
            this.console = console;
            this.commandController = new CommandController(console);
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
                commandController.Execute(command);
            }
        }
        public int NextId()
        {
            return ++id;
        }

    }
}
