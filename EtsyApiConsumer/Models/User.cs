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
    public class User
    {
        public string user_id { get;set; }
        public string login_name { get; set; }
        public string primary_email { get; set; }
        public UserProfile userprofile { get; set; }
        //public string creation_tsz { get; set; }
        //public string user_pub_key { get; set; }
        //public string referred_by_user_id { get; set; }
       // public string feedback_info { get; set; }
        public List<Shop> shops;

        public User()
        {
            shops = new List<Shop>();
        }
    }
}
