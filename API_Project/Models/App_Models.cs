﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API_Project.Models
{
    public class User
    {
        public int UserID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public virtual ICollection<Favorite> Favorites { get; set; }
    }

    public class Favorite
    {
        public int FavoriteID { get; set; }
        public int UserID { get; set; }
        public int CovidDataID { get; set; }
        public CovidData CovidData { get; set; }
        public User User { get; set; }
    }

    public class State
    {
        public int StateID { get; set; }
        public string StateName { get; set; }
    }

    public class MyClass
            {
                public List<CovidData> data { get; set; }
            }

        public class CovidData
        {
            public int CovidDataID { get; set; }
            public string data_as_of { get; set; }
            public string startweek { get; set; }
            public string endweek { get; set; }
            public string state { get; set; }
            public string county { get; set; }
            public string fips_code { get; set; }
            public int covid_19_deaths { get; set; }
            public int total_deaths { get; set; }

        public virtual ICollection<Favorite> Favorites { get; set; }
       }
    public class ChartModel
    {
        public string ChartType { get; set; }
        public string Labels { get; set; }
        public string Data { get; set; }
        public string Title { get; set; }
    }
}
