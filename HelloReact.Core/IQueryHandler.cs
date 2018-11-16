using System.Threading.Tasks;

namespace HelloReact.Core {
  public interface IQueryHandler<TQuery, TResult> {
    Task<TResult> HandleAsync(TQuery query);
  }
}