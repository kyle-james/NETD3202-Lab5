using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Lab5.Models;

namespace Lab5.Controllers
{
    public class HomeController : Controller
    {
        public static List<ShopModel> smList = new List<ShopModel>();
        public static List<ProjectModel> projectList = new List<ProjectModel>();

        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
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

        public IActionResult Products()
        {
            return View();
        }
        public IActionResult Contact()
        {
            return View();
        }

        public IActionResult About()
        {
            return View();
        }
        [HttpGet]
        public IActionResult Projects()
        {
            ProjectModel pm = new ProjectModel();
            pm.GenerateProjects();
            return View();
        }
        [HttpPost]
        public IActionResult Projects(ProjectModel project)
        {

            if (project != null && ModelState.IsValid)
            {
                projectList.Add(project);
                ViewData["Message"] = project.ToString(projectList);
                return View("Projects");
            }
            else
            {
                return View("Error");
            }
        }
        [HttpPost]
        public IActionResult Shop(ShopModel sm)
        {
            Random r = new Random();

            sm.name = r.Next().ToString();
            sm.price = r.NextDouble();
            sm.skuId = r.Next();

            smList.Add(sm);
            return View("Shop", sm);
        }
    }
}
