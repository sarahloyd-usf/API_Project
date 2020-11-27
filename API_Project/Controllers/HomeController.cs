using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using API_Project.Models;
using API_Project.DataAccess;

namespace API_Project.Controllers
{
    public class HomeController : Controller
    {
        public ApplicationDbContext dbContext;

        public HomeController(ApplicationDbContext context, ILogger<HomeController> logger)
        {
            dbContext = context;
            _logger = logger;
        }

        private readonly ILogger<HomeController> _logger;

        public IActionResult Index()
        {
            return View();
        }

        public class ViewModel
        {
            public IEnumerable<State> States { get; set; }
            public IEnumerable<CovidData> CovidDatas { get; set; }
        }

        [HttpGet]
        public IActionResult Data(string StateSel)
        {
            //Get COVID and State Data for the view
            ViewModel MyModel = new ViewModel();
            //Get all the states
            MyModel.States = dbContext.States.OrderBy(s => s.StateName);

            //get all the covid data or filter it by state if provided
            if (StateSel == null || StateSel == "All")
            {
                MyModel.CovidDatas = dbContext.CovidData.OrderBy(c => c.state);
            }
            else
            {
                MyModel.CovidDatas = dbContext.CovidData.Where(c => c.state == StateSel).OrderBy(c => c.county);
            }

            return View(MyModel);
        }

        public IActionResult Symptoms()
        {
            return View();
        }
        public IActionResult AboutUS()
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
    }
}





