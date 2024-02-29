using System;
using System.Collections.Generic;
using System.Linq;



namespace Tasks
{

    public class ViewByProjectCommand : CommandBase
    {
        public ViewByProjectCommand(TaskList taskList, IConsole console, Dictionary<string, IList<Task>> tasks)
            : base(taskList, console, tasks) { }


        public override void Execute(string commandRest)
        {
            foreach (var project in tasks)
            {
                console.WriteLine(project.Key);
                foreach (var task in project.Value)
                {
                    console.WriteLine("    [{0}] {1}: {2}", (task.Done ? 'x' : ' '), task.Id, task.Description);
                }
                console.WriteLine();
            }
        }
    }
    public class AddCommand : CommandBase
    {

        public AddCommand(TaskList taskList, IConsole console, Dictionary<string, IList<Task>> tasks)
            : base(taskList, console, tasks) { }

        public override void Execute(string commandRest)
        {
            var subcommandRest = commandRest.Split(" ".ToCharArray(), 2);
            var subcommand = subcommandRest[0];
            if (subcommand == "project")
            {
                AddProject(subcommandRest[1]);
            }
            else if (subcommand == "task")
            {
                var projectTask = subcommandRest[1].Split(" ".ToCharArray(), 3);
                AddTask(projectTask[0], projectTask[1], projectTask[2]);
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
    }

    public class CheckCommand : CommandBase
    {

        public CheckCommand(TaskList taskList, IConsole console, Dictionary<string, IList<Task>> tasks)
            : base(taskList, console, tasks) { }


        public override void Execute(string commandRest)
        {
            SetDone(commandRest, true);
        }

    }

    public class UncheckCommand : CommandBase
    {

        public UncheckCommand(TaskList taskList, IConsole console, Dictionary<string, IList<Task>> tasks)
            : base(taskList, console, tasks) { }

        public override void Execute(string commandRest)
        {
            SetDone(commandRest, false);
        }

    }
    public class HelpCommand : CommandBase
    {

        public HelpCommand(TaskList taskList, IConsole console, Dictionary<string, IList<Task>> tasks)
                    : base(taskList, console, tasks) { }

        public override void Execute(string commandRest)
        {
            console.WriteLine("Commands:");
            console.WriteLine("  show");
            console.WriteLine("  add project <project name>");
            console.WriteLine("  add task <project name> <task description>");
            console.WriteLine("  check <task ID>");
            console.WriteLine("  uncheck <task ID>");
            console.WriteLine();
        }
    }
    public class SetDeadlineCommand : CommandBase
    {

        public SetDeadlineCommand(TaskList taskList, IConsole console, Dictionary<string, IList<Task>> tasks)
                : base(taskList, console, tasks) { }

        public override void Execute(string commandRest)
        {
            var subcommandRest = commandRest.Split(" ".ToCharArray(), 2);
            string idString = subcommandRest[0];
            DateTime date = DateTime.Parse(subcommandRest[1]);
            var identifiedTask = FindTask(subcommandRest[0]);
            if (identifiedTask == null)
            {
                console.WriteLine("Could not find a task with an ID of {0}.", idString);
                return;
            }
            identifiedTask.deadline = date;
        }

    }

    public class TodayCommand : CommandBase
    {

        public TodayCommand(TaskList taskList, IConsole console, Dictionary<string, IList<Task>> tasks)
                    : base(taskList, console, tasks) { }

        public override void Execute(string commandRest)
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
    }

    public class DeleteCommand : CommandBase
    {

        public DeleteCommand(TaskList taskList, IConsole console, Dictionary<string, IList<Task>> tasks)
             : base(taskList, console, tasks) { }

        public override void Execute(string commandRest)
        {
            String idString = commandRest;
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

    }
    public class ViewByDateCommand : CommandBase
    {

        public ViewByDateCommand(TaskList taskList, IConsole console, Dictionary<string, IList<Task>> tasks)
            : base(taskList, console, tasks) { }

        public override void Execute(string commandRest)
        {
            var sortedTasks = tasks.Values.SelectMany(t => t).OrderBy(t => t.startDate);

            foreach (var task in sortedTasks)
            {
                console.WriteLine("Task {0} - Start Date: {1}: {2}", task.Id, task.startDate.ToShortDateString(), task.Description);
            }
        }

    }

    public class ViewByDeadlineCommand : CommandBase
    {

        public ViewByDeadlineCommand(TaskList taskList, IConsole console, Dictionary<string, IList<Task>> tasks)
            : base(taskList, console, tasks) { }

        public override void Execute(string commandRest)
        {
            var sortedTasks = tasks.Values.SelectMany(t => t).OrderBy(t => t.deadline);

            foreach (var task in sortedTasks)
            {
                console.WriteLine("Task {0} - Deadline: {1}: {2}", task.Id, task.deadline.ToShortDateString(), task.Description);
            }
        }

    }
}
