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
using Newtonsoft.Json;
using EtsyApiConsumer.Models;
using EtsyApiConsumer.Services;
using EtsyApiConsumer.Helpers;
using Newtonsoft.Json.Linq;
using System.Threading;
using System.Windows.Forms;

namespace EtsyApiConsumer
{
    class Program
    {
        static void Main(string[] args)
        {
            //Just here for the purposes of alpha prototype stuff
            //UserService US = new UserService();
            //User ushi = US.GetUser(client, "ushi84", true, false);
            const string consumerKey = "";
            const string consumerSecret = "";
            const string accessToken = "";
            const string accessTokenSecret = "";




            var client = new RestClient();
            client.BaseUrl = AppKeys.GetBaseUri();
            client.Authenticator = OAuth1Authenticator.ForProtectedResource(consumerKey, consumerSecret, accessToken, accessTokenSecret);
            ShopService SS = new ShopService();
            ListingService LS = new ListingService();
            UserService US = new UserService();
            var Company = InternalClientService.GetInternalClientByID("646");
            bool consoleApp = false;

            if (consoleApp)
            {

                //RestRequest request = new RestRequest("/oauth/scopes", Method.GET);
                //IRestResponse response = client.Execute(request);
                //JObject oq = JObject.Parse(response.Content);
                //Console.WriteLine(oq.ToString());
                var command = Console.ReadLine();
                var user = US.GetUser(client, "threadedtees", true, false);

               
                if (command.ToLower() == "getlistings")
                {
                    RestRequest request = new RestRequest();
                    request.Resource = string.Format("/taxonomy/seller/get");
                    IRestResponse response = client.Execute(request);
                    JObject o = JObject.Parse(response.Content);
                    Console.WriteLine(o.ToString());

                    LS.ImportListing(client);

                    Authorization.GetAccessToken();

                    var listings = SS.GetShopListings(client, Company.EtsyShopIDs.First());
                    //listring id
                    //title
                    //variation name
                    //variation value

                    ExportHelpers.ExportListingIdAndVariations(user.shops.FirstOrDefault().listings, @"C:\Internal\Etsy\ListingIdAndVariation.txt", true);
                }
                if(command.ToLower()=="createlistings")
                {
                    ListingHelper.CreateEtsyListingFromCustomMapping(client, Company, @"C:\Internal\Etsy\CalculatedFailure_FirstTest_Amazon_Feed.txt");
                }
                #region Listing Tool Code
               
                #endregion
                
                if (command.ToLower() == "download")
                {
                    string path = @"C:\Internal\Etsy.txt";

                    var receipts = SS.GetOpenShopReceipts(client, Company.EtsyShopIDs.FirstOrDefault());
                    Console.WriteLine("Exporting...");
                    ExportHelpers.ExtractionExport(receipts, path, CountryService.GetCountryMapping(client), true);
                    Console.Write("Export Complete");
                }

                if (command.ToLower() == "upload")
                {
                    ImportHelpers.ShippingSummaries();
                    Console.Write("Upload Complete");
                    Console.ReadLine();
                }
            }
            else
            {
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Application.Run(new DownloadUploadForm());
            }


            #region Listing Creation Stuff
            
            #endregion

        }

    }

   
}
