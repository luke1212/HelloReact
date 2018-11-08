using System;

namespace ChronoLedger.Core {
  public static class ObjectExtensionMethods {

    public static TOutput Apply<TInput, TOutput>(this TInput input, Func<TInput, TOutput> function) =>
      function(input);

    public static TInput Dump<TInput>(this TInput input, string id = "") {
#if DEBUG
      if (string.IsNullOrWhiteSpace(id)) {
        Console.WriteLine(ObjectDumper.Dump(input));
      } else {
        Console.WriteLine(id + ": " + ObjectDumper.Dump(input));
      }
#endif
      return input;
    }

    public static TInput Dump<TInput, TDump>(this TInput input, Func<TInput, TDump> getValue, string id = "") {
      getValue(input).Dump(id);
      return input;
    }

  }
}
