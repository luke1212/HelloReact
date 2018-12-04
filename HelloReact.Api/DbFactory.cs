using HelloReact.Core;
using HelloReact.Data;
using Microsoft.EntityFrameworkCore;

namespace HelloReact.Api {
  public class DbFactory : IFactory<HelloReactDB> {
    private readonly DbContextOptions _options;

    public DbFactory(DbContextOptions options) {
      _options = options;
    }

    public HelloReactDB Create() =>
      new HelloReactDB(_options);

  }
}
