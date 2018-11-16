namespace HelloReact.Core {
  public interface IFactory<T> {
    T Create();
  }
}