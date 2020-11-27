using System;
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
        //            public List<UserFavorite> Favorites { get; set; }
        public virtual ICollection<UserFavorite> Favorites { get; set; }
    }

        public class UserFavorite
        {
            public int CovidDataID { get; set; }
            public int UserID { get; set; }

            public virtual ICollection<User> Users { get; set; }
            public virtual ICollection<CovidData> CovidDatas { get; set; }

        }

    public class State
    {
        public string state { get; set; }

        public virtual ICollection<CovidData> CovidDatas { get; set; }

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

        public virtual ICollection<UserFavorite> Favorites { get; set; }
       }

}
