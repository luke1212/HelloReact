using System.Threading.Tasks;

namespace HelloReact.Core {
  public interface ICommandHandler<TCommand> {
    Task Handle(TCommand command);
  }
}