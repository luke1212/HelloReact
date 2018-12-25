using System;
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

    private const string _UploadsDirectoryName = "uploads";
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

    private string _MakeFileNameUnique(string fileName) =>
      $"{Path.GetFileNameWithoutExtension(fileName)}_{Guid.NewGuid()}.{Path.GetExtension(fileName)}";

    [HttpPost("[action]")]
    public void UploadFile([FromForm] UploadFileModel model) {
      Directory.CreateDirectory(Path.Combine("wwwroot", _UploadsDirectoryName));

      var savePath = Path.Combine("wwwroot", _UploadsDirectoryName, _MakeFileNameUnique(model.FileName));

      using (var writeStream = System.IO.File.Create(savePath))
      using (var readStream = model.File.OpenReadStream()) {
        readStream.Seek(0, SeekOrigin.Begin);
        readStream.CopyTo(writeStream);
      }
    }

    [HttpGet("[action]")]
    public IActionResult GetImages([FromForm] UploadFileModel model) {
      Directory.CreateDirectory(Path.Combine("wwwroot", _UploadsDirectoryName));

      var fileNames = Directory.EnumerateFiles(Path.Combine("wwwroot", _UploadsDirectoryName))
        .Select(Path.GetFileName)
        .Select(p => Path.Combine(_UploadsDirectoryName, p))
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
