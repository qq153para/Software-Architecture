using System.Collections.Generic;
using Tasks.Entity;

namespace Tasks.UseCase
{
    public class AddCommand : CommandBase
    {

        public AddCommand(IDictionary<string, IList<Task>> tasks) : base(tasks) { }

        public override List<string> Execute(string commandRest)
        {
            var subcommandRest = commandRest.Split(" ".ToCharArray(), 2);
            var subcommand = subcommandRest[0];
            if (subcommand == "project")
            {
                return AddProject(subcommandRest[1]);
            }
            else if (subcommand == "task")
            {
                var projectTask = subcommandRest[1].Split(" ".ToCharArray(), 2);
                return AddTask(projectTask[0], projectTask[1]);
            }
            return new List<string>();
        }
        private List<string> AddProject(string name)
        {
            tasks[name] = new List<Task>();
            return new List<string>();
        }

        private List<string> AddTask(string project, string description)
        {
            List<string> CommandReturn = new List<string>();
            if (!tasks.TryGetValue(project, out IList<Task> projectTasks))
            {
                string formattedString = string.Format("Could not find a project with the name \"{0}\".", project);
                CommandReturn.Add(formattedString);
                return CommandReturn;
            }
            int id = NextId();
            projectTasks.Add(new Task { Id = id, Description = description, Done = false });
            return CommandReturn;
        }

        private int NextId()
        {
            return id++;
        }
    }
}
