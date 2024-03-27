using Tasks.UseCase.port.input;
using Tasks.UseCase.port.UseCaseOutput;


namespace Tasks.UseCase.Command
{
    public interface ICommand<I, O>
        where I : IUseCaseInput
    {
        O Execute(I input);
    }
}