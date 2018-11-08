using System.Threading.Tasks;

namespace ChronoLedger.Core {
  public interface IQueryHandler<TQuery, TResult> {
    Task<TResult> HandleAsync(TQuery query);
  }
}