using System.Threading.Tasks;

namespace ChronoLedger.Core {
  public interface ICommandHandler<TCommand> {
    Task Handle(TCommand command);
  }
}