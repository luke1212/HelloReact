using System.Collections.Generic;
using HelloReact.Api;
using HelloReact.DomainModels;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace HelloReact.Web.Controllers {
  [Route("api/[controller]")]
  public class UserController : Controller {
    private readonly UserApi _userApi;

    public UserController(UserApi userApi) {
      _userApi = userApi;
    }

    [HttpGet("[action]")]
    public IEnumerable<UserModel> GetUser()
      => _userApi.GetUser();

    [HttpPost("[action]")]
    public void AddNewUser([FromBody] NewUserArgs args) =>
      _userApi.AddNewUser(args.UserName);

    public class NewUserArgs {
      public string UserName { get; set; }
    }
  }
}
