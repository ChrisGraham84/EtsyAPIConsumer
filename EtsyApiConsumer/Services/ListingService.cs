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
using System.IO;
using System.Threading;

namespace EtsyApiConsumer.Services
{
    public class ListingService
    {
        #region POST
        
        //The parameters are the required for creating the listing
        //The shipping template must be created in a different process
        //as they may not be set up on an account
        //STATE MUST BE DRAFT
        public Listing CreateListing(RestClient RestClient, Listing Listing)
        {
            string strmaterials = string.Empty;
            foreach (var m in Listing.materials)
            {
                strmaterials += m.Replace("\"", "").Replace(".", "").Replace("%", "");
                if (Listing.materials.Last() != m)
                {
                    strmaterials += ",";
                }
            }
            string strtags = string.Empty;
            foreach (var t in Listing.tags)
            {
                strtags += t;
                if (Listing.tags.Last() != t)
                {
                    strtags += ",";
                }
            }

            Console.WriteLine("Creating Listing {0}", Listing.title);
            RestRequest request = new RestRequest();
            request.Method = Method.POST;
            request.AddParameter("quantity", Listing.quantity);
            request.AddParameter("title", Listing.title);
            request.AddParameter("description", Listing.description);
            request.AddParameter("price", Listing.price);
            request.AddParameter("shipping_template_id", Listing.shipping_template_id);
            request.AddParameter("state", Listing.state);
            request.AddParameter("is_supply", Listing.is_supply);
            request.AddParameter("who_made", Listing.who_made);
            request.AddParameter("when_made", Listing.when_made);
            request.AddParameter("materials", strmaterials);
            request.AddParameter("tags", strtags);
            request.AddParameter("category_id", Listing.category_id);
            request.AddParameter("taxonomy_id", Listing.taxonomy_id);
            request.Resource = "/listings";

            try
            {
                IRestResponse response = RestClient.Execute(request);
                if (response.StatusCode == System.Net.HttpStatusCode.Created)
                {
                    JObject o = JObject.Parse(response.Content);
                    Listing listing = JsonConvert.DeserializeObject<Listing>(o["results"][0].ToString());
                    Thread.Sleep(1000);
                    Console.WriteLine("listing created...");
                    return (listing);
                }
                else
                {
                    Console.WriteLine("Listing was unable to be created: {0}", response.StatusDescription);
                    Thread.Sleep(1000);
                    return (null);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("An Error has happened in the CreateListing Method : {0}", ex.ToString());
                return (null);
            }
        }
        public string CreateListingItemImage(RestClient RestClient, Listing Listing, string FileName, string FilePath)
        {
            Console.WriteLine("Creating Listing Image {0}", FileName);
            byte[] byteArray = File.ReadAllBytes(FilePath);

            RestRequest request = new RestRequest();
            request.AddHeader("Content-Type", "multipart/form-data");
            request.Method = Method.POST;
            request.AlwaysMultipartFormData = true;
            //request.AddParameter("image", FilePath);
            //request.AddParameter("type", "image/png");
            request.AddFile("image",byteArray,FileName,"image/png");
            request.Resource = string.Format("/listings/{0}/images",Listing.listing_id);

            try
            {
                IRestResponse response = RestClient.Execute(request);
                JObject o = JObject.Parse(response.Content);
                
                if(response.StatusCode == System.Net.HttpStatusCode.Created)
                {
                    Console.WriteLine("listing image created...");
                }
                else
                {
                    Console.WriteLine("Listing was unable to be created: {0}", response.StatusDescription);
                }

                Thread.Sleep(1000);
                return (response.StatusDescription);
            }
            catch (Exception ex)
            {
                Console.WriteLine("An Error has happened in the CreateListingItemImage Method : {0}", ex.ToString());
                return (ex.InnerException.ToString());
            }
        }
        public string CreateListingVariations(RestClient RestClient, Listing Listing, ListingVariation[] variations)
        {
            
            RestRequest request = new RestRequest();
            request.Method = Method.POST;
            request.AddParameter("variations", variations);
            request.AddParameter("custom_property_names", "{\"513\":\"Size\"");
            request.Resource = string.Format("/listings/{0}/variations", Listing.listing_id);
            try
            {
                IRestResponse response = RestClient.Execute(request);
                JObject o = JObject.Parse(response.Content);

                return (response.StatusDescription);
            }
            catch (Exception ex)
            {
                return (ex.InnerException.ToString());
            }
        }
        #endregion

        #region GET
        public Listing GetListing(RestClient RestClient, string listingid)
        {
            Listing listing = new Listing();

            RestRequest request = new RestRequest();
            request.Resource = string.Format("listings/{1}?method=GET&api_key={0}", AppKeys.GetApiKey(), listingid);
            IRestResponse response = RestClient.Execute(request);
            JObject o = JObject.Parse(response.Content);
            listing = JsonConvert.DeserializeObject<Listing>(o["results"][0].ToString());

            GetListingVariations(RestClient, listing);

            return (listing);
        }

        public void GetListingVariations(RestClient RestClient, Listing listing)
        {
            RestRequest request = new RestRequest();
            request.Resource = string.Format("/listings/{0}/variations", listing.listing_id);
            IRestResponse response = RestClient.Execute(request);
            if(response.StatusCode != System.Net.HttpStatusCode.OK)
            {
                Console.WriteLine("Variation Was Not Acquired : {0}", response.StatusDescription);
                Console.ReadLine();
            }
            JObject o = JObject.Parse(response.Content);
            Variation variation;
            foreach(var v in o["results"])
            {
                variation = JsonConvert.DeserializeObject<Variation>(v.ToString());
                listing.variations.Add(variation);
            }
        }
        #endregion

        #region PUT
        public string UpdateListingVariations(RestClient RestClient, Listing Listing, string variations)
        {
            Console.WriteLine("Updating Listring Varations");
            Console.WriteLine(variations);
            RestRequest request = new RestRequest();
            request.Method = Method.PUT;
            request.AddParameter("variations", variations);
            request.AddParameter("custom_property_names", "{\"513\":\"Size\"}");
            request.Resource = string.Format("/listings/{0}/variations", Listing.listing_id);
            try
            {
                IRestResponse response = RestClient.Execute(request);
                JObject o = JObject.Parse(response.Content);
                return (response.StatusDescription);
            }
            catch (Exception ex)
            {
                return (ex.InnerException.ToString());
            }
        }
        #endregion

        #region DELETE
        #endregion

        public void ImportListing(RestClient RestClient)
        {
            var dictListings = ImportHelpers.ImportTabDelimitedFile(@"C:\Internal\Etsy\listingimport.txt");
            var gclient = InternalClientService.GetInternalClientByID(dictListings.Where(x=>x.Key == 2).First().Value[0].ToString());
            //GETTING SHIPPING TEMPLATE
            string shiptempId = ShippingTemplateService.GetShippingTemplateId(RestClient, gclient.EtsyUserName);
            //string status = ShippingTemplateService.CreateShippingTemplate(RestClient, "Test Shipping Template", countries.Where(x => x.Value == "United States").FirstOrDefault().Key.ToString(), "2.00", "1.00");
            var countries = CountryService.GetCountryMapping(RestClient);

            foreach (var row in dictListings.Skip(1))
            {
                if (row.Key != 1)
                {
                    Console.WriteLine("CREATING A DRAFT LISTING");
                    var obj = row.Value;
                    Listing testListing = new Listing
                    {
                        title = obj[1].ToString(),
                        description = obj[2].ToString(),
                        price = obj[3].ToString(),
                        quantity = obj[7].ToString(),
                        shipping_template_id = shiptempId,
                        state = "draft",
                        is_supply = "false",
                        who_made = "i_did",
                        when_made = "made_to_order",
                    };
                    //var listing = CreateListing(RestClient, testListing);

                    Console.WriteLine("CREATING A LISTING IMAGE");
                    string filepath = string.Format(@"C:\Internal\EtsyProductImages\{0}", obj[4].ToString());
                    //CreateListingItemImage(RestClient, listing, obj[4].ToString(), filepath);

                    Console.WriteLine("CREATE LISTING VARIATIONS");
                    List <ListingVariation> variations = new List<ListingVariation>();
                    ListingVariation variation;

                    List<string> sizes = new List<string> { "S", "M", "L", "XL", "XXL" };
                    string style = obj[6].ToString();
                    foreach (var size in sizes)
                    {
                        variation = new ListingVariation();
                        variation.property_id = "513";
                        //variation.is_available = "TRUE";
                        variation.value = string.Format("{0}-{1}", size, style);
                        variations.Add(variation);
                    }

                    List<string> designs = obj[5].ToString().Split(';').ToList();
                    foreach (var design in designs)
                    {
                        string[] designcolor = design.Split(':');
                            variation = new ListingVariation();
                            variation.property_id = "200";
                            variation.value = string.Format("{0}-{1}", designcolor[0], designcolor[1]);
                            variations.Add(variation);
                    }
                    string output = JsonConvert.SerializeObject(variations.ToArray());
                    //UpdateListingVariations(RestClient, listing, output);
                    Console.WriteLine("Listing Created");
                    Thread.Sleep(1000);
                }
            }
        }
    }
}
