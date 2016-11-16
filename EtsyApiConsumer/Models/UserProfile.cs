using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RestSharp;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using EtsyApiConsumer.Helpers;


namespace EtsyApiConsumer.Models
{
    public class UserProfile
    {
        public string user_id { get; set; }
        public string first_name { get; set; }
        public string last_name { get; set; }
    }
}
