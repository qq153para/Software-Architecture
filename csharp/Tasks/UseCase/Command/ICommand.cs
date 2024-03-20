using Tasks.UseCase.port.input;
using Tasks.UseCase.port.UseCaseOutput;


namespace Tasks.UseCase.Command
{
    public interface IUseCase<I, O>
        where I : IUseCaseInput
    {
        O Execute(I input);
    }
}