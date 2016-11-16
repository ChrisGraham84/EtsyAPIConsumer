using EtsyApiConsumer.Helpers;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Data;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using RestSharp;
using RestSharp.Authenticators;
using RestSharp.Authenticators.OAuth;
using RestSharp.Extensions.MonoHttp;

namespace EtsyApiConsumer.Helpers
{
    public static class Authorization
    {
        public static Dictionary<string,string> GetAccessToken()
        {
            Dictionary<string, string> dictAccessTokens = new Dictionary<string, string>();

            const string consumerKey = "";
            const string consumerSecret = "";

            //Authorization request
            Uri baseUrl = AppKeys.GetBaseUri();

            RestClient oauthClient = new RestClient(baseUrl)
            {
                Authenticator = OAuth1Authenticator.ForRequestToken(consumerKey, consumerSecret)
            };
            RestRequest request = new RestRequest("oauth/request_token", Method.POST);
            IRestResponse response = oauthClient.Execute(request);

            NameValueCollection qs = HttpUtility.ParseQueryString(response.Content);
            string oauthToken = qs["oauth_token"];
            string oauthTokenSecret = qs["oauth_token_secret"];
            string loginUrl = qs["login_url"];

            Process.Start(loginUrl);

            string verifier = Console.ReadLine();

            //request = new RestRequest("oauth/authorize");
            //request.AddParameter("oauth_token", oauthToken);

            //string url = oauthClient.BuildUri(request).ToString();
            
            request = new RestRequest("oauth/access_token", Method.POST);
            oauthClient.Authenticator = OAuth1Authenticator
                .ForAccessToken(consumerKey, consumerSecret, oauthToken, oauthTokenSecret, verifier);
            response = oauthClient.Execute(request);
            NameValueCollection qs2 = HttpUtility.ParseQueryString(response.Content);
            oauthToken = qs2["oauth_token"];
            oauthTokenSecret = qs2["oauth_token_secret"];
            dictAccessTokens.Add("accessToken", oauthToken);
            dictAccessTokens.Add("accessToeknSecret", oauthTokenSecret);
            Console.WriteLine("Access: {0}  -  Access Secret {1}", oauthToken, oauthTokenSecret);
            Console.ReadLine();
            return (dictAccessTokens);

        }
    }
   
}
