using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using API_Project.DataAccess;
using API_Project.Models;
using System.Net.Http;
using Newtonsoft.Json;


namespace API_Project.Controllers
{
    public class DatabaseController : Controller
    {
        HttpClient httpClient;

        static string BASE_URL = "https://data.cdc.gov/resource/6vqh-esgs.json";

        public ApplicationDbContext dbContext;

        public DatabaseController(ApplicationDbContext context)
        {
            dbContext = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        public async Task<ViewResult> SeedOperations()
        {
            // Create User
            User MyUser = new User();
            MyUser.Email = "bapo@gmail.com";
            MyUser.FirstName = "Bob";
            MyUser.LastName = "Apo";
            MyUser.Password = "abc123";

            dbContext.Users.Add(MyUser);

            //Populate States
            dbContext.States.Add(new State() { StateName = "AK" });
            dbContext.States.Add(new State() { StateName = "AL" });
            dbContext.States.Add(new State() { StateName = "AZ" });
            dbContext.States.Add(new State() { StateName = "AR" });
            dbContext.States.Add(new State() { StateName = "CA" });
            dbContext.States.Add(new State() { StateName = "CO" });
            dbContext.States.Add(new State() { StateName = "CT" });
            dbContext.States.Add(new State() { StateName = "DE" });
            dbContext.States.Add(new State() { StateName = "AL" });
            dbContext.States.Add(new State() { StateName = "DC" });
            dbContext.States.Add(new State() { StateName = "FL" });
            dbContext.States.Add(new State() { StateName = "GA" });
            dbContext.States.Add(new State() { StateName = "HI" });
            dbContext.States.Add(new State() { StateName = "ID" });
            dbContext.States.Add(new State() { StateName = "IL" });
            dbContext.States.Add(new State() { StateName = "IN" });
            dbContext.States.Add(new State() { StateName = "IA" });
            dbContext.States.Add(new State() { StateName = "KS" });
            dbContext.States.Add(new State() { StateName = "KY" });
            dbContext.States.Add(new State() { StateName = "LA" });
            dbContext.States.Add(new State() { StateName = "ME" });
            dbContext.States.Add(new State() { StateName = "MD" });
            dbContext.States.Add(new State() { StateName = "MA" });
            dbContext.States.Add(new State() { StateName = "MI" });
            dbContext.States.Add(new State() { StateName = "MN" });
            dbContext.States.Add(new State() { StateName = "MS" });
            dbContext.States.Add(new State() { StateName = "MO" });
            dbContext.States.Add(new State() { StateName = "MT" });
            dbContext.States.Add(new State() { StateName = "NE" });
            dbContext.States.Add(new State() { StateName = "NV" });
            dbContext.States.Add(new State() { StateName = "NH" });
            dbContext.States.Add(new State() { StateName = "NJ" });
            dbContext.States.Add(new State() { StateName = "NM" });
            dbContext.States.Add(new State() { StateName = "NY" });
            dbContext.States.Add(new State() { StateName = "NC" });
            dbContext.States.Add(new State() { StateName = "ND" });
            dbContext.States.Add(new State() { StateName = "OH" });
            dbContext.States.Add(new State() { StateName = "OK" });
            dbContext.States.Add(new State() { StateName = "OR" });
            dbContext.States.Add(new State() { StateName = "PA" });
            dbContext.States.Add(new State() { StateName = "RI" });
            dbContext.States.Add(new State() { StateName = "SC" });
            dbContext.States.Add(new State() { StateName = "SD" });
            dbContext.States.Add(new State() { StateName = "TN" });
            dbContext.States.Add(new State() { StateName = "TX" });
            dbContext.States.Add(new State() { StateName = "UT" });
            dbContext.States.Add(new State() { StateName = "VA" });
            dbContext.States.Add(new State() { StateName = "WA" });
            dbContext.States.Add(new State() { StateName = "WV" });
            dbContext.States.Add(new State() { StateName = "WI" });

            //Get the Covid data and put it in the DB
            httpClient = new HttpClient();
            httpClient.DefaultRequestHeaders.Accept.Clear();

            httpClient.DefaultRequestHeaders.Accept.Add(
                new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

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

            foreach (CovidData coviddata in myclass.data)
            {
                dbContext.CovidData.Add(coviddata);

            }


            dbContext.SaveChanges();

            //// READ operation
            //Company CompanyRead1 = dbContext.Companies
            //                        .Where(c => c.symbol == "MCOB")
            //                        .First();

            //Company CompanyRead2 = dbContext.Companies
            //                        .Include(c => c.Quotes)
            //                        .Where(c => c.symbol == "MCOB")
            //                        .First();

            //// UPDATE operation
            //CompanyRead1.iexId = "MCOB";
            //dbContext.Companies.Update(CompanyRead1);
            ////dbContext.SaveChanges();
            //await dbContext.SaveChangesAsync();

            //// DELETE operation
            ////dbContext.Companies.Remove(CompanyRead1);
            ////await dbContext.SaveChangesAsync();

            return View();
        }

        public ViewResult LINQOperations()
        {
            //Company CompanyRead1 = dbContext.Companies
            //                                .Where(c => c.symbol == "MCOB")
            //                                .First();

            //Company CompanyRead2 = dbContext.Companies
            //                                .Include(c => c.Quotes)
            //                                .Where(c => c.symbol == "MCOB")
            //                                .First();

            //Quote Quote1 = dbContext.Companies
            //                        .Include(c => c.Quotes)
            //                        .Where(c => c.symbol == "MCOB")
            //                        .FirstOrDefault()
            //                        .Quotes
            //                        .FirstOrDefault();

            return View();
        }

    }
}
