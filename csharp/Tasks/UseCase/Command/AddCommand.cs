using System.Collections.Generic;
using Tasks.Entity;
using Tasks.UseCase.Message;

namespace Tasks.UseCase.Command
{
    public class AddCommand : CommandBase
    {
        public override ReturnMessage Execute(string commandRest)
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
            return returnmessage;
        }
        private ReturnMessage AddProject(string name)
        {
            tasks[name] = new List<Task>();
            return returnmessage;
        }

        private ReturnMessage AddTask(string project, string description)
        {
            if (!tasks.TryGetValue(project, out IList<Task> projectTasks))
            {
                string formattedString = string.Format("Could not find a project with the name \"{0}\".", project);
                returnmessage.AddMessage(formattedString);
                return returnmessage;
            }
            int id = tasklist.NextId();
            projectTasks.Add(new Task { Id = id, Description = description, Done = false });
            return returnmessage;
        }
    }
}
