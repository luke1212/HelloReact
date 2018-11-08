namespace ChronoLedger.Core {
  public interface IFactory<T> {
    T Create();
  }
}