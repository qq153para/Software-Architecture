using System;
using System.Collections.Generic;
using Tasks.Adapter;
using Tasks.Concole;
using Tasks.Controller;


namespace Tasks
{
    public sealed class TaskListApp
    {
        private const string QUIT = "quit";

        private readonly IConsole console;
        private readonly IContorller commandController;

        public static void Main(string[] args)
        {
            new TaskListApp(new RealConsole()).Run();
        }

        public TaskListApp(IConsole console)
        {
            this.console = console;
            this.commandController = new CommandController();
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
                List<string> CommandReturn = commandController.Execute(command);
                foreach (string str in CommandReturn)
                {
                    console.WriteLine(str);
                }
            }
        }

    }
}
