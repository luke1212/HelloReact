using System.Collections.Generic;
using System.Linq;
using HelloReact.Core;
using HelloReact.DomainModels;
using User.Data;

namespace HelloReact.Api {
  public class UserApi {
    private readonly IFactory<UserDb> _dbFactory;

    public UserApi(IFactory<UserDb> dbFactory) {
      _dbFactory = dbFactory;
    }

    public IEnumerable<UserModel> GetUser() {
      using (var db = _dbFactory.Create()) {
        return db.Users.Select(i => new UserModel {
          Id = i.Id,
          Name = i.Name,
        }).ToList();
      }
    }
  }
}
