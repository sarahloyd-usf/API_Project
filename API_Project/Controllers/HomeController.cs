using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using API_Project.Models;
using System.Net.Http;
using Newtonsoft.Json;

namespace API_Project.Controllers
{
    public class HomeController : Controller
    {
        HttpClient httpClient;

        static string BASE_URL = "https://data.cdc.gov/resource/6vqh-esgs.json";
        //        static string API_KEY = "mdBybOievMdeX3eYSC0MhFu3U7xRV18xHAPG04qb"; //Add your API key here inside ""

        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Data()
        {
            httpClient = new HttpClient();
            httpClient.DefaultRequestHeaders.Accept.Clear();
            //            httpClient.DefaultRequestHeaders.Add("X-Api-Key", API_KEY);
            httpClient.DefaultRequestHeaders.Accept.Add(
                new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

            //            string NATIONAL_PARK_API_PATH = BASE_URL + "/parks?limit=20";
            string covidDataStr = "";

            MyClass myclass = null;

            httpClient.BaseAddress = new Uri(BASE_URL);

            try
            {
                HttpResponseMessage response = httpClient.GetAsync(BASE_URL).GetAwaiter().GetResult();

                if (response.IsSuccessStatusCode)
                {
                    covidDataStr = response.Content.ReadAsStringAsync().GetAwaiter().GetResult();
                }

                if (!covidDataStr.Equals(""))
                {
                    //fix this crappy json
                    covidDataStr = "{\"data\":" + covidDataStr + "}";
                    // JsonConvert is part of the NewtonSoft.Json Nuget package
                    myclass = JsonConvert.DeserializeObject<MyClass>(covidDataStr);
                }
            }
            catch (Exception e)
            {
                // This is a useful place to insert a breakpoint and observe the error message
                Console.WriteLine(e.Message);
            }
            return View(myclass);
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





