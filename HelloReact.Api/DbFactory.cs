using HelloReact.Core;
using Microsoft.EntityFrameworkCore;
using HelloReact.Data;

namespace HelloReact.Api {
  public class DbFactory : IFactory<UserDb> {
    private readonly DbContextOptions _options;

    public DbFactory(DbContextOptions options) {
      _options = options;
    }

    public UserDb Create() =>
      new UserDb(_options);

  }
}
