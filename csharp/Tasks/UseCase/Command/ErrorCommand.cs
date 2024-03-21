using Tasks.UseCase.port.input;
using Tasks.UseCase.port.UseCaseOutput;

namespace Tasks.UseCase.Command
{
    public class ErrorCommand : ICommand<ErrorInput, UseCaseOutput>
    {
        public UseCaseOutput Execute(ErrorInput input)
        {
            UseCaseOutput UseCaseOutputData = new UseCaseOutput();
            string UnknownCommand = input.getUnKnownCommand(); 
            string formattedString = string.Format("I don't know what the command \"{0}\" is.", UnknownCommand);
            UseCaseOutputData.setMessage(formattedString);
            return UseCaseOutputData;
        }
    }
}
