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
    public static class ShippingTemplateService
    {
        #region POST
        public static string CreateShippingTemplate(RestClient RestClient, string Title, string OriginCountryID, string PrimaryCost, string SecondaryCost)
        {
            RestRequest request = new RestRequest();
            request.Method = Method.POST;
            request.AddParameter("title", Title);
            request.AddParameter("origin_country_id", OriginCountryID);
            request.AddParameter("primary_cost", PrimaryCost);
            request.AddParameter("secondary_cost", SecondaryCost);
            request.Resource = string.Format("/shipping/templates");
            IRestResponse response = RestClient.Execute(request);

            return (response.StatusDescription);
        }
        #endregion

        #region GET
        public static string GetShippingTemplateId(RestClient RestClient, string UserId)
        {
            Console.WriteLine("Getting Shipping Template Id");
            RestRequest request = new RestRequest();
            request.Resource = string.Format("users/{0}/shipping/templates", UserId);
            IRestResponse response = RestClient.Execute(request);
            JObject o = JObject.Parse(response.Content);
            Thread.Sleep(500);
            return (o["results"][0]["shipping_template_id"].ToString());
        }

        #endregion

        #region PUT
        #endregion

        #region DELETE
        #endregion
    }
}
