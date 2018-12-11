using System.Collections.Generic;
using System.IO;
using System.Linq;
using HelloReact.Api;
using HelloReact.DomainModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace HelloReact.Web.Controllers {
  [Route("api/[controller]")]
  public class UserController : Controller {

    private const string _UploadsDirectoryName = "C:\\Temp\\Uploads";
    private readonly UserApi _userApi;

    public UserController(UserApi userApi) {
      _userApi = userApi;
    }

    [HttpGet("[action]")]
    public IEnumerable<UserModel> GetUser()
      => _userApi.GetUser();

    [HttpPost("[action]")]
    public IEnumerable<UserModel> AddNewUser([FromBody] UserArgs args) {
      _userApi.AddNewUser(args.UserName);
      return _userApi.GetUser();
    }

    [HttpPost("[action]")]
    public void DeleteUser([FromBody] UserArgs args) {
      _userApi.DeleteUser(args.UserName);
    }

    [HttpPost("[action]")]
    public void UploadFile([FromForm] UploadFileModel model) {

      var savePath = Path.Combine(_UploadsDirectoryName, model.FileName);

      using (var writeStream = System.IO.File.Create(savePath))
      using (var readStream = model.File.OpenReadStream()) {
        readStream.Seek(0, SeekOrigin.Begin);
        readStream.CopyTo(writeStream);
      }
    }

    [HttpGet("[action]")]
    public IActionResult GetImages([FromForm] UploadFileModel model) {
      var fileNames = Directory.EnumerateFiles(_UploadsDirectoryName)
        .Except(new List<string> { Path.Combine(_UploadsDirectoryName, ".keep") })
        .ToList();

      return this.Json(new ImageListModel {
        FileNames = fileNames
      });
    }

    public class UploadFileModel {
      public string FileName { get; set; }
      public IFormFile File { get; set; }
    }

    public class UserArgs {
      public string UserName { get; set; }
    }
  }
}
