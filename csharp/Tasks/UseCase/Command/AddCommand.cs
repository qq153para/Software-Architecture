using System.Collections.Generic;
using System.Threading.Tasks;
using Tasks.Entity;
using Tasks.UseCase.Message;
using Task = Tasks.Entity.Task;

namespace Tasks.UseCase.Command
{
    public class AddCommand : ICommand
    {
        public ReturnMessage Execute(string commandRest)
        {
            return addCommand(commandRest);
        }

        public ReturnMessage addCommand(string commandRest)
        {
            var subcommandRest = commandRest.Split(" ".ToCharArray(), 2);
            var subcommand = subcommandRest[0];
            var returnmessage = new ReturnMessage();
            TaskList taskList = TaskList.GetTaskList();
            if (subcommand == "project")
            {
                return AddProject(returnmessage, taskList, subcommandRest[1]);
            }
            else if (subcommand == "task")
            {
                var projectTask = subcommandRest[1].Split(" ".ToCharArray(), 2);
                return AddTask(taskList, returnmessage, projectTask[0], projectTask[1]);
            }
            return returnmessage;
        }

        private ReturnMessage AddProject(ReturnMessage returnmessage, TaskList taskList, string name)
        {
            IDictionary<string, IList<Task>> tasks = taskList.GetTasks();
            tasks[name] = new List<Task>();
            return returnmessage;
        }

        private ReturnMessage AddTask(TaskList taskList, ReturnMessage returnmessage, string project, string description)
        {
            IDictionary<string, IList<Task>> tasks = taskList.GetTasks();
            if (!tasks.TryGetValue(project, out IList<Task> projectTasks))
            {
                string formattedString = string.Format("Could not find a project with the name \"{0}\".", project);
                returnmessage.AddMessage(formattedString);
                return returnmessage;
            }
            int id = taskList.NextId();
            projectTasks.Add(new Task { Id = id, Description = description, Done = false });
            return returnmessage;
        }
    }
}



