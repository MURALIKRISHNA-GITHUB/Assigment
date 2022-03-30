using Microsoft.AspNetCore.Mvc;
using SelfAssignment_MvcVersion.Business;
using SelfAssignment_MvcVersion.Models;
using System.Diagnostics;
using System.Text.Json;
using Newtonsoft.Json.Linq;
using Microsoft.AspNetCore.Hosting;

namespace SelfAssignment_MvcVersion.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public HomeController(ILogger<HomeController> logger, IWebHostEnvironment webHostEnvironment)
        {
            _logger = logger;
            _webHostEnvironment = webHostEnvironment;
        }


        public IActionResult CreateUserInfo(UserInfo userInfo)
        {
            UserInfoManagar _userInfoManagar = new();
            userInfo.CreatedOn = DateTime.Now;
            userInfo.UpdatedOn = DateTime.Now;

            // need to map login user name/email/id based on deisgn here..
            userInfo.CreatedBy = userInfo.FirstName;

            //Generate Jobject
            JObject obj = (JObject)JToken.FromObject(userInfo);

            //Generate JSON file  at root directory - json
            GenerateJsonFile(obj);

            //Save the details to database and return
            return Json(_userInfoManagar.CreateRecord(userInfo));
        }




        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        private void GenerateJsonFile(JObject jobj)
        {
            string uploadDIR = Path.Combine(_webHostEnvironment.WebRootPath, "json");
            var fileName = Guid.NewGuid().ToString() + ".json";
            string filePath = Path.Combine(uploadDIR, fileName);
            System.IO.File.WriteAllText(filePath, jobj.ToString());
        }
    }
}