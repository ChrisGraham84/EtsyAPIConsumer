using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RestSharp;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using EtsyApiConsumer.Helpers;
using EtsyApiConsumer.Models;
using System.Threading;

namespace EtsyApiConsumer.Services
{
    public class UserService
    {
        private ShopService shopservice = new ShopService();
        private ListingService listingservice = new ListingService();

        #region POST
        #endregion

        #region GET
        public User GetUser(RestClient RestClient, string UserId, bool GetShop, bool GetProfile)
        {
            User user = new User();

            RestRequest request = new RestRequest();
            request.Resource = "users/" + UserId + "";
            IRestResponse response = RestClient.Execute(request);
            JObject o = JObject.Parse(response.Content);
            user = JsonConvert.DeserializeObject<User>(o["results"][0].ToString());

            if (GetProfile) { GetUserProfile(RestClient, user); }
            if (GetShop) { GetUserShops(RestClient, user, true, false); }

            return (user);
        }

        public void GetUserShops(RestClient RestClient, User User, bool GetListings, bool GetReceipts)
        {
            RestRequest request = new RestRequest();
            request.Resource = string.Format("users/{0}/shops", User.user_id);
            IRestResponse response = RestClient.Execute(request);
            JObject o = JObject.Parse(response.Content);

            Shop shop;
            foreach (var s in o["results"])
            {
                shop = JsonConvert.DeserializeObject<Shop>(s.ToString());
                Thread.Sleep(1000);
                if (GetListings) { shopservice.GetShopListings(RestClient, shop); }
                if (GetReceipts) { shopservice.GetShopReceipts(RestClient, shop); }
                User.shops.Add(shop);
            }
        }

        private void GetUserProfile(RestClient RestClient, User User)
        {
            RestRequest request = new RestRequest();
            request.Resource = string.Format("users/{0}/profile", User.user_id );
            IRestResponse response = RestClient.Execute(request);
            JObject o = JObject.Parse(response.Content);
            UserProfile userProfile = JsonConvert.DeserializeObject<UserProfile>(o["results"][0].ToString());
            User.userprofile = userProfile;
        }
        #endregion

        #region PUT
        #endregion

        #region DELETE
        #endregion
    }
}
