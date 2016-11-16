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
    public class ShopService
    {
      
        private ListingService listingservice = new ListingService();
        private ReceiptService receiptservice = new ReceiptService();

        #region POST
        #endregion

        #region GET
        public Shop GetShop(RestClient RestClient, string ShopId, bool GetListings, bool GetReceipts)
        {
            Shop shop = new Shop();

            RestRequest request = new RestRequest();
            request.Resource = string.Format("shops/{0}", ShopId);
            IRestResponse response = RestClient.Execute(request);
            JObject o = JObject.Parse(response.Content);
            shop = JsonConvert.DeserializeObject<Shop>(o["results"][0].ToString());

            if (GetListings) { GetShopListings(RestClient, shop); }
            if (GetReceipts) { GetShopReceipts(RestClient, shop); }

            return (shop);
        }
        public void GetShopListings(RestClient RestClient, Shop shop)
        {
            //start offset at 0
            int offset = 0;
            Console.WriteLine("Grabbing Shop Listings..");

            //initial request
            Console.WriteLine("Getting Batch {0}..", (100 + offset/100).ToString());
            RestRequest request = new RestRequest();
            request.AddParameter("limit", 100);
            request.AddParameter("offset", offset);
            request.Resource = string.Format("/shops/{0}/listings/active", shop.shop_id);
            IRestResponse response = RestClient.Execute(request);
            JObject o = JObject.Parse(response.Content);
            Listing listing;

            //keep making requests until no results come back
            while (o["results"].Count() > 0)
            {
                foreach (var l in o["results"])
                {
                    listing = JsonConvert.DeserializeObject<Listing>(l.ToString());
                    shop.listings.Add(listing);
                }

                //offset by 100 after every edition
                offset += 100;
                Console.WriteLine("Getting Batch {0}..", (100 + offset / 100).ToString());
                RestRequest request2 = new RestRequest();
                request2.AddParameter("limit", 100);
                request2.AddParameter("offset", offset);
                request2.Resource = string.Format("/shops/{0}/listings/active", shop.shop_id);
                response = RestClient.Execute(request2);
                o = JObject.Parse(response.Content);
                Thread.Sleep(1000);
            }

            int counter = 1;
            int count = shop.listings.Count;
            foreach(var l in shop.listings)
            {
                Console.WriteLine("Getting Variations For Listing {0} : {1}/{2} ", l.title,counter,count);
                listingservice.GetListingVariations(RestClient, l);
                counter++;
                Thread.Sleep(1000);
            }

            Console.WriteLine("Shop Listring Obtained..");

        }
        public List<Listing> GetShopListings(RestClient RestClient, string ShopId)
        {
            Console.WriteLine("Grabbing Shop Listings..");
            List<Listing> listings = new List<Listing>();
            RestRequest request = new RestRequest();
            request.Resource = string.Format("/shops/{0}/listings/active", ShopId);
            IRestResponse response = RestClient.Execute(request);
            JObject o = JObject.Parse(response.Content);
            Listing listing;
            foreach (var l in o["results"])
            {
                listing = JsonConvert.DeserializeObject<Listing>(l.ToString());
                Console.WriteLine("Getting Variations For Listing {0}", listing.title);
                Thread.Sleep(1000);
                listingservice.GetListingVariations(RestClient, listing);
                listings.Add(listing);
            }
            Console.WriteLine("Shop Listring Obtained..");
            return (listings);

        }
        public void GetShopReceipts(RestClient RestClient, Shop shop)
        {
            RestRequest request = new RestRequest();
            request.Resource = string.Format("/shops/{0}/receipts/open", shop.shop_id);
            IRestResponse response = RestClient.Execute(request);
            JObject o = JObject.Parse(response.Content);
            Receipt receipt;
            foreach (var l in o["results"])
            {
                receipt = JsonConvert.DeserializeObject<Receipt>(l.ToString());
                //receiptservice.GetReceiptTransactions(rc, receipt);
                UserService US = new UserService();
                //receipt.buyer = US.GetUser(rc, receipt.buyer_user_id,false);

                shop.receipts.Add(receipt);
            }
        }
        public List<Receipt> GetShopReceipts(RestClient RestClient, string ShopID)
        {
            List<Receipt> shopReceipts = new List<Receipt>();
            RestRequest request = new RestRequest();
            //request.AddParameter("includes", "Transaction"); TODO: Figure out access denial issue
            request.Resource = string.Format("/shops/{0}/receipts/open", ShopID);
            IRestResponse response = RestClient.Execute(request);
            JObject o = JObject.Parse(response.Content);
            Receipt receipt;
            foreach (var l in o["results"])
            {
                receipt = JsonConvert.DeserializeObject<Receipt>(l.ToString());
                receiptservice.GetReceiptTransactions(RestClient, receipt);
                Thread.Sleep(1000);
                shopReceipts.Add(receipt);
            }

            return (shopReceipts);
        }
        public List<Receipt> GetOpenShopReceipts(RestClient RestClient, string ShopID)
        {
            List<Receipt> shopReceipts = new List<Receipt>();
            RestRequest request = new RestRequest();
            //request.AddParameter("includes", "Transaction"); TODO: Figure out access denial issue
            request.Resource = string.Format("/shops/{0}/receipts/open", ShopID);
            IRestResponse response = RestClient.Execute(request);
            JObject o = JObject.Parse(response.Content);
           
            Receipt receipt;
            foreach (var l in o["results"])
            {
                Console.WriteLine("Getting Receipts");
                receipt = JsonConvert.DeserializeObject<Receipt>(l.ToString());
                receiptservice.GetReceiptTransactions(RestClient, receipt);
                Thread.Sleep(1000);
                shopReceipts.Add(receipt);
            }

            Console.WriteLine("Got Receipts and Transactions");
            return (shopReceipts);
        }
        #endregion

        #region PUT
        #endregion

        #region DELETE
        #endregion
    }
}
