using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tasks.Entity;
using Tasks.UseCase.Message;


namespace Tasks.UseCase.Command
{
    public interface ICommand
    {
        public ReturnMessage Execute(string commandRest);
    }
}