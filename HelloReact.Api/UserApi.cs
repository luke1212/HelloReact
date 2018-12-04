using System.Collections.Generic;
using System.Linq;
using HelloReact.Core;
using HelloReact.Data;
using HelloReact.DomainModels;

namespace HelloReact.Api {
  public class UserApi {
    private readonly IFactory<HelloReactDB> _dbFactory;

    public UserApi(IFactory<HelloReactDB> dbFactory) {
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

    public void AddNewUser(string newUserName) {
      using (var db = _dbFactory.Create()) {
        db.Users.Add(new User {
          Name = newUserName,
        });
        db.SaveChanges();
      }
    }

    public void DeleteUser(string UserName) {
      using (var db = _dbFactory.Create()) {
        var user = db.Users.Single(u => u.Name == UserName);
        db.Users.Remove(user);
        db.SaveChanges();
      }
    }
  }
}
