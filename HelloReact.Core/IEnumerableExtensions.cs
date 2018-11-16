using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HelloReact.Core {
  public static class IEnumerableExtensions {

    public static void Merge<TDest, TSource>(this IEnumerable<TDest> target,
      IEnumerable<TSource> source,
      Func<TDest, TSource, bool> predicate,
      Func<TSource, TDest> create,
      Action<TDest> delete,
      Action<TDest> add,
      Action<TDest, TSource> update
    ) {
      List<(TDest d, TSource s)> updates = null;
      List<TSource> adds = null;
      List<TDest> deletes = null;

      if (source != null) {
        if (update != null) updates = (
          from d in target
          from s in source
          where predicate(d, s)
          select (d, s)
        ).ToList();
        if (add != null || create != null) adds = source.Where(m => !target.Any(s => predicate(s, m))).ToList();
        if (delete != null) deletes = target.Where(s => !source.Any(m => predicate(s, m))).ToList();
      } else {
        if (delete != null) deletes = target.ToList();
      }

      updates?.ForEach(t => update(t.d, t.s));
      deletes?.ForEach(delete);
      adds?.ForEach(item => {
        TDest o = create(item);
        update?.Invoke(o, item);
        add?.Invoke(o);
      });
    }

    public static async Task MergeAsync<TDest, TSource>(
      this IEnumerable<TDest> target,
      IEnumerable<TSource> source,
      Func<TDest, TSource, bool> predicate,
      Func<TSource, Task<TDest>> create,
      Func<TDest, Task> delete,
      Func<TDest, Task> add,
      Func<TDest, TSource, Task> update
    ) {
      List<(TDest d, TSource s)> updates = null;
      List<TSource> adds = null;
      List<TDest> deletes = null;

      if (source != null) {
        if (update != null) {
          updates = (
            from d in target
            from s in source
            where predicate(d, s)
            select (d, s)
          ).ToList();
        }

        if (add != null || create != null) {
          adds = source.Where(m => !target.Any(s => predicate(s, m))).ToList();
        }

        if (delete != null) {
          deletes = target.Where(s => !source.Any(m => predicate(s, m))).ToList();
        }
      } else {
        if (delete != null) {
          deletes = target.ToList();
        }
      }

      if (updates != null) {
        foreach (var item in updates) {
          await update(item.d, item.s);
        }
      }

      if (deletes != null) {
        foreach (var item in deletes) {
          await delete(item);
        }
      }

      if (adds != null) {
        foreach (var item in adds) {
          TDest o = await create(item);
          if (update != null) {
            await update(o, item);
          }
          if (add != null) {
            await add(o);
          }
        }
      }
    }

  }
}
