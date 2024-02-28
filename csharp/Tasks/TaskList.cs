using System;
using System.Collections.Generic;
using System.Linq;

namespace Tasks
{
	public sealed class TaskList
	{
		private const string QUIT = "quit";

		private readonly IDictionary<string, IList<Task>> tasks = new Dictionary<string, IList<Task>>();
		private readonly IConsole console;


		public static void Main(string[] args)
		{
			new TaskList(new RealConsole()).Run();
		}

		public TaskList(IConsole console)
		{
			this.console = console;
		}

		public void Run()
		{
			while (true) {
				console.Write("> ");
				var command = console.ReadLine();
				if (command == QUIT) {
					break;
				}
				Execute(command);
			}
		}

		private void Execute(string commandLine)
		{
			var commandRest = commandLine.Split(" ".ToCharArray(), 2);
			var command = commandRest[0];
			switch (command) {
				case "show":
					ViewByProject();
					break;
				case "add":
					Add(commandRest[1]);
					break;
				case "check":
					Check(commandRest[1]);
					break;
				case "uncheck":
					Uncheck(commandRest[1]);
					break;
				case "help":
					Help();
					break;
				case "setdeadline":
					var subcommandRest = commandRest[1].Split(" ".ToCharArray(), 2);
					DateTime datetime1 = DateTime.Parse(subcommandRest[1]);
					SetDeadline(subcommandRest[0], datetime1);
					break;
				case "today":
                    Today();
					break;
                case "delete":
                    Delete(commandRest[1]);
                    break;
                case "viewbydate":
                    ViewByDate();
                    break;
                case "viewbydeadline":
                    ViewByDeadline();
                    break;
                default:
					Error(command);
					break;
			}
		}

		private void ViewByProject()
		{
			foreach (var project in tasks) {
				console.WriteLine(project.Key);
				foreach (var task in project.Value) {
					console.WriteLine("    [{0}] {1}: {2}", (task.Done ? 'x' : ' '), task.Id, task.Description);
				}
				console.WriteLine();
			}
		}

		private void Add(string commandLine)
		{
			var subcommandRest = commandLine.Split(" ".ToCharArray(), 2);
			var subcommand = subcommandRest[0];
			if (subcommand == "project") {
				AddProject(subcommandRest[1]);
			} else if (subcommand == "task") {
				var projectTask = subcommandRest[1].Split(" ".ToCharArray(), 3);
				AddTask(projectTask[0], projectTask[1] , projectTask[2]);
			}
		}

		private void AddProject(string name)
		{
			tasks[name] = new List<Task>();
		}

		private void AddTask(string project, string idString, string description)
		{
			if (!tasks.TryGetValue(project, out IList<Task> projectTasks))
			{
				Console.WriteLine("Could not find a project with the name \"{0}\".", project);
				return;
			}
  
            if (IsValidIdentifier(idString) | FindTask(idString) == null)
			{
                projectTasks.Add(new Task { Id = idString, Description = description, Done = false });
            }

		}

		private void Delete(string idString) 
		{
			var task = FindTask(idString);

            if (task == null)
            {
                console.WriteLine("Could not find a task with an ID of {0}.", idString);
                return;
            }

            foreach (var projectTasks in tasks.Values)
            {
                if (projectTasks.Remove(task))
                {
                    console.WriteLine("Task with ID {0} has been deleted.", idString);
                    return;
                }
            }
        }

		private void Check(string idString)
		{
			SetDone(idString, true);
		}

		private void Uncheck(string idString)
		{
			SetDone(idString, false);
		}

		private void SetDone(string idString, bool done)
		{
			var identifiedTask = FindTask(idString);
            if (identifiedTask == null)
            {
                console.WriteLine("Could not find a task with an ID of {0}.", idString);
                return;
            }
            identifiedTask.Done = done;
		}

        private void SetDeadline(string idString,DateTime date)
        {
			var identifiedTask = FindTask(idString);
            if (identifiedTask == null)
            {
                console.WriteLine("Could not find a task with an ID of {0}.", idString);
                return;
            }
            identifiedTask.deadline = date;
        }

		private Task FindTask(string idString)
		{
            var identifiedTask = tasks
                .Select(project => project.Value.FirstOrDefault(task => task.Id == idString))
                .Where(task => task != null)
                .FirstOrDefault();

			return identifiedTask;
        }
        private bool IsValidIdentifier(string identifier)
        {

            foreach (char c in identifier)
            {
                if (char.IsWhiteSpace(c) || char.IsSymbol(c) || char.IsPunctuation(c))
                {
                    return false; 
                }
            }

            return true;
        }
        private void Today()
        {
            DateTime today = DateTime.Today;
            foreach (var project in tasks)
            {
                foreach (var task in project.Value)
                {	
					if (task.deadline != null)
					{
                        if (today.Year == task.deadline.Year && today.Month == task.deadline.Month && today.Day == task.deadline.Day)
                        {
                            console.WriteLine("Task {0} is due today.", task.Description);

						}
                    }
                }
            }
			console.WriteLine();
        }

        private void ViewByDate()
        {
            var sortedTasks = tasks.Values.SelectMany(t => t).OrderBy(t => t.startDate);

            foreach (var task in sortedTasks)
            {
                console.WriteLine("Task {0} - Start Date: {1}: {2}", task.Id, task.startDate.ToShortDateString(), task.Description);
            }
        }

        private void ViewByDeadline()
        {
            var sortedTasks = tasks.Values.SelectMany(t => t).OrderBy(t => t.deadline);

            foreach (var task in sortedTasks)
            {
                console.WriteLine("Task {0} - Deadline: {1}: {2}", task.Id, task.deadline.ToShortDateString(), task.Description);
            }
        }
        private void Help()
		{
			console.WriteLine("Commands:");
			console.WriteLine("  show");
			console.WriteLine("  add project <project name>");
			console.WriteLine("  add task <project name> <task description>");
			console.WriteLine("  check <task ID>");
			console.WriteLine("  uncheck <task ID>");
			console.WriteLine();
		}

		private void Error(string command)
		{
			console.WriteLine("I don't know what the command \"{0}\" is.", command);
		}

	}
}
