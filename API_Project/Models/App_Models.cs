using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API_Project.Models
{
//    public class App_Models
  //  {
        //public class Users
        //{
        //    public int userid { get; set; }
        //    public string FirstName { get; set; }
        //    public string LastName { get; set; }
        //    public string Email { get; set; }
        //    public string password { get; set; }

        //}

        //public class UserFavorite
        //{
        //    public string fips_code { get; set; }
        //    public int userid { get; set; }

        //}

        public class MyClass
        {
            public List<CovidData> data { get; set; }
        }

        public class CovidData
    {
            public string data_as_of { get; set; }
            public string startweek { get; set; }
            public string endweek { get; set; }
            public string state { get; set; }
            public string county { get; set; }
            public string fips_code { get; set; }
            public int covid_19_deaths { get; set; }
            public int total_deaths { get; set; }
        }

//    }
}
