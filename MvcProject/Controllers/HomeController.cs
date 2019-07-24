using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MvcProject.Helper;
using MvcProject.Models;
using Newtonsoft.Json;

namespace MvcProject.Controllers
{
    public class HomeController : Controller
    {
        private IHostingEnvironment hostingEnvironment;
        ApiHelper _api = new ApiHelper();

        public HomeController(IHostingEnvironment hostingEnvironment)
        {
            this.hostingEnvironment = hostingEnvironment;
        }
        //[HttpGet]
        //public IActionResult Index()
        //{

        //    return View();

        //}
        [HttpGet]
        public IActionResult Index()
        {
            IEnumerable<LogError> movies = null;

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:44347/api/");
                //HTTP GET
                var responseTask = client.GetAsync("LoggingErrors?pageNo=");
                responseTask.Wait();

                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {

                    var readTask = result.Content.ReadAsAsync<IList<LogError>>();
                    readTask.Wait();

                    movies = readTask.Result;
                }
                else //web api sent error response 
                {
                    //log response status here..

                    movies = Enumerable.Empty<LogError>();

                    ModelState.AddModelError(string.Empty, "Server error. Please contact administrator.");
                }
            }
            return View(movies);
        }


        public IActionResult DeleteLog(string datetime, string type)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:44347/api/");
                string ee = datetime.Replace('/', '-');
                //HTTP DELETE
                var deleteTask = client.DeleteAsync($"LoggingErrors/{ee}/{type}");
                deleteTask.Wait();

                var result = deleteTask.Result;
                if (result.IsSuccessStatusCode)
                {

                    return RedirectToAction("Index");
                }
            }

            return RedirectToAction("Index");
        }
    }
}
