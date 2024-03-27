using System;
using System.Collections.Generic;
using System.Text;
using Tasks.Entity;
using Tasks.UseCase.port.input;
using Tasks.UseCase.port.UseCaseOutput;

namespace Tasks.UseCase.Command
{
    public class HelpCommand : ICommand<HelpInput, UseCaseOutput>
    {
        public UseCaseOutput Execute(HelpInput input)
        {
            UseCaseOutput UseCaseOutputData = new UseCaseOutput();
            UseCaseOutputData.setMessage("Commands:");
            UseCaseOutputData.setMessage("  show");
            UseCaseOutputData.setMessage("  add project <project name>");
            UseCaseOutputData.setMessage("  add task <project name> <task description>");
            UseCaseOutputData.setMessage("  check <task ID>");
            UseCaseOutputData.setMessage("  uncheck <task ID>");
            UseCaseOutputData.setMessage(string.Empty);
            return UseCaseOutputData;

        }
    }
}
