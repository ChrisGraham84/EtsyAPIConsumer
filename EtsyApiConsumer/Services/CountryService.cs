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
using LiteDB;
using System.Threading;

namespace EtsyApiConsumer.Services
{
    public static class CountryService
    {
        #region Etsy Methods

        #region POST
        #endregion

        #region GET
        public static Dictionary<int, string> GetCountryMapping(RestClient RestClient)
        {
            Console.WriteLine("Getting Country Mapping Table");
            Dictionary<int, string> dictCountry = new Dictionary<int, string>();
            try
            {
                RestRequest request = new RestRequest();
                request.Resource = string.Format("/countries");
                IRestResponse response = RestClient.Execute(request);
                JObject o = JObject.Parse(response.Content);
                foreach (var country in o["results"])
                {
                    dictCountry.Add(int.Parse(country["country_id"].ToString()), country["name"].ToString());
                }
                Thread.Sleep(500);
            }
           catch(Exception ex)
            {
                Console.WriteLine("An Error Has Occured In The GetCountryMappingMethod : {0}", ex.ToString());
            }
            return (dictCountry);
        }
        #endregion

        #region PUT
        #endregion

        #region DELETE
        #endregion

        #endregion

        #region LiteDb Methods

        #region CREATE
        /// <summary>
        /// Returns true if new CountryShippingMethod is created. Returns false if CountryShippingMethod with Country is found
        /// </summary>
        /// <param name="ClientID"></param>
        /// <param name="ClientName"></param>
        /// <returns></returns>
        public static bool CreateCountyShippingMethod(string Country, string ShippingMethod)
        {
            using (var db = new LiteDatabase(AppKeys.GetDataContextString()))
            {
                var countries = db.GetCollection<CountryShippingMethod>("countries");

                var newcountry = countries.Find(x => x.Country == Country).FirstOrDefault();
                if(newcountry == null)
                {
                    newcountry = new CountryShippingMethod();
                    newcountry.Country = Country;
                    newcountry.Shipping_Method = ShippingMethod;

                    countries.Insert(newcountry);
                    countries.EnsureIndex(x => x.Country);

                    return (true);
                }
            }
            return (false);
        }

        public static void PopulateShipping(RestClient Client)
        {
            var countries = GetCountryMapping(Client);

            List<string> USAOnly = new List<string>
            {
                "United States",
                "Puerto Rico",
                "Guam",
                "U.S. Virgin Islands",
                "American Samoa",
                "Northern Mariana Islands",
                "Midway Islands",
                "Wake Island",
                "Johnston Atoll",
                "Baker, Howland, and Jarvis Islands",
                "Kingman Reef",
                "Navassa Island",
                "Palmyra Atoll",
            };
            string usonly = "USPS - First Class (USA Only)";
            string intl = "USPS - First Class International";

            string shipmethod;
            foreach (var country in countries.Values)
            {
                if (USAOnly.Contains(country))
                {
                    shipmethod = usonly;
                }
                else
                {
                    shipmethod = intl;
                }
                CountryService.CreateCountyShippingMethod(country, shipmethod);
            }
        }

        #endregion

        #region READ
        public static List<CountryShippingMethod> GetAllCountryShippingMethod()
        {
            using (var db = new LiteDatabase(AppKeys.GetDataContextString()))
            {
                var countries = db.GetCollection<CountryShippingMethod>("countries");

                return (countries.FindAll().ToList());
            }
        }
        public static CountryShippingMethod GetCountryShippingMethodByCountry(string Country)
        {
            CountryShippingMethod country = null;
            using (var db = new LiteDatabase(AppKeys.GetDataContextString()))
            {
                var countries = db.GetCollection<CountryShippingMethod>("countries");
                country = countries.Find(x => x.Country == Country).FirstOrDefault();
            }


                return (country);
        }
        #endregion

        #region UPDATE
        #endregion

        #region DELETE
        #endregion

        #endregion
    }
}
