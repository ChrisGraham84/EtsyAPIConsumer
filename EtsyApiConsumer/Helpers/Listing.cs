using EtsyApiConsumer.Models;
using EtsyApiConsumer.Services;
using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace EtsyApiConsumer.Helpers
{
    public static class ListingHelper
    {
        public static void CreateEtsyListingFromCustomMapping(RestClient client, InternalClient Company, String MappingPath)
        {
            ListingService LS = new ListingService();

            List<SKUImportTemplate> skus = ImportHelpers.ImportListFromTabFile<SKUImportTemplate>(MappingPath,
                new List<string> { "children" }, new SKUImportTemplate(), 2, 3);
            string imageFolderPath = @"C:\Internal\EtsyProductImages\JPG\";

            List<SKUImportTemplate> parents = skus.Where(x => x.item_sku.StartsWith("prt-")).ToList();
            foreach (var parent in parents)
            {
                if (parent.children == null)
                {
                    parent.children = new List<SKUImportTemplate>();
                }

                List<string> images = new List<string>();

                parent.children.AddRange(skus.Where(x => x.parent_sku == parent.item_sku).ToList());


                Products prod = new Products();
                prod.Title = parent.item_name.Split('-')[0].Trim();
                prod.Description = parent.product_description;

                string TagString = string.Empty;
                if (parent.generic_keywords1.Length < 20)
                {
                    TagString += parent.generic_keywords1;
                }
                if (parent.generic_keywords2.Length < 20)
                {
                    if (TagString != string.Empty)
                    {
                        TagString += ",";
                    }
                    TagString += parent.generic_keywords1;
                }
                if (parent.generic_keywords3.Length < 20)
                {
                    if (TagString != string.Empty)
                    {
                        TagString += ",";
                    }
                    TagString += parent.generic_keywords1;
                }
                if (parent.generic_keywords4.Length < 20)
                {
                    if (TagString != string.Empty)
                    {
                        TagString += ",";
                    }
                    TagString += parent.generic_keywords1;
                }
                if (parent.generic_keywords5.Length < 20)
                {
                    if (TagString != string.Empty)
                    {
                        TagString += ",";
                    }
                    TagString += parent.generic_keywords1;
                }
                prod.Tags = TagString;


                List<string> tags = new List<string>();
                if (parent.generic_keywords1.Length < 20)
                {
                    tags.Add(parent.generic_keywords1);
                }
                if (parent.generic_keywords2.Length < 20)
                {
                    tags.Add(parent.generic_keywords2);
                }
                if (parent.generic_keywords3.Length < 20)
                {
                    tags.Add(parent.generic_keywords3);
                }
                if (parent.generic_keywords4.Length < 20)
                {
                    tags.Add(parent.generic_keywords4);
                }
                if (parent.generic_keywords5.Length < 20)
                {
                    tags.Add(parent.generic_keywords5);
                }

                List<string> materials = new List<string>();
                if (parent.bullet_point1.Length <= 45)
                {
                    materials.Add(parent.bullet_point1.Replace("-", ""));
                }
                if (parent.bullet_point2.Length <= 45)
                {
                    materials.Add(parent.bullet_point2.Replace("-", ""));
                }
                if (parent.bullet_point3.Length <= 45)
                {
                    materials.Add(parent.bullet_point3.Replace("-", ""));
                }
                if (parent.bullet_point4.Length <= 45)
                {
                    materials.Add(parent.bullet_point4.Replace("-", ""));
                }
                if (parent.bullet_point5.Length <= 45)
                {
                    materials.Add(parent.bullet_point5.Replace("-", ""));
                }

                float addPrice = 0.0f;
                foreach (var child in parent.children)
                {
                    addPrice += float.Parse(child.list_price);
                }

                float averagePrice = (addPrice / (float)parent.children.Count);

                string shiptempId = ShippingTemplateService.GetShippingTemplateId(client, Company.EtsyUserName);
                //string status = ShippingTemplateService.CreateShippingTemplate(RestClient, "Test Shipping Template", countries.Where(x => x.Value == "United States").FirstOrDefault().Key.ToString(), "2.00", "1.00");
                //var countries = CountryService.GetCountryMapping(client);

                Models.Listing testListing = new Listing
                {
                    title = parent.item_name.Split('-')[0].Trim(),
                    description = parent.product_description,
                    quantity = "300",
                    price = averagePrice.ToString("n2"),
                    shipping_template_id = shiptempId,
                    state = "draft",
                    is_supply = "false",
                    who_made = "i_did",
                    when_made = "made_to_order",
                    taxonomy_id = "132",
                    category_id = "69150455",

                    materials = materials.ToArray(),
                    tags = tags.ToArray()
                };
                var listing = LS.CreateListing(client, testListing);

                if (listing != null)
                {
                    //listing imaages
                    var imagenames = parent.children.Select(x => x.main_image_url).Distinct().ToList();
                    foreach (var url in imagenames.Take(5))
                    {
                        var split = url.Split('/');
                        var name = split[split.Length - 1];
                        if (File.Exists(imageFolderPath + name))
                        {
                            LS.CreateListingItemImage(client, listing, name, imageFolderPath + name);
                        }
                    }

                    //variations
                    var colorGroups = parent.children.GroupBy(x => x.color_name);
                    var sizeGroups = parent.children.GroupBy(x => x.size_name);

                    Dictionary<string, List<SKUImportTemplate>> dictColorDesigns = new Dictionary<string, List<SKUImportTemplate>>();
                    List<ListingVariation> variations = new List<ListingVariation>();
                    ListingVariation variation;
                    foreach (var colorgroup in colorGroups)
                    {
                        //group by design
                        variation = new ListingVariation();
                        variation.value = string.Format("{0}-{1}", colorgroup.FirstOrDefault().color_name, colorgroup.FirstOrDefault().item_sku.Split('-')[0]);
                        variation.property_id = "200";
                        variations.Add(variation);
                    }
                    foreach (var sizegroup in sizeGroups)
                    {
                        //group by design
                        variation = new ListingVariation();
                        string styleid = sizegroup.FirstOrDefault().item_sku.Split('-')[1];
                        string etsystylename = Company.ClientStyles.Where(x => x.style_number == styleid).FirstOrDefault().etsy_style_descripion;

                        variation.value = string.Format("{0}-{1}", sizegroup.FirstOrDefault().item_sku.Split('-')[3], etsystylename); ;
                        variation.property_id = "513";
                        variations.Add(variation);
                    }
                    string output = JsonConvert.SerializeObject(variations.ToArray());
                    LS.UpdateListingVariations(client, listing, output);
                }
            }
            Console.WriteLine("Done With Listings");
        }
        public static void CreateCustomListing(RestClient client, InternalClient Company)
        {

            ShopService SS = new ShopService();
            ListingService LS = new ListingService();
            UserService US = new UserService();

            //GETTING SHIPPING TEMPLATE
            string shiptempId = ShippingTemplateService.GetShippingTemplateId(client, "80374327");
            var countries = CountryService.GetCountryMapping(client);
            string status = ShippingTemplateService.CreateShippingTemplate(client, "Test Shipping Template", countries.Where(x => x.Value == "United States").FirstOrDefault().Key.ToString(), "2.00", "1.00");
            

           // CREATING A DRAFT LISTING
            string shippingTemplateId = ShippingTemplateService.GetShippingTemplateId(client, Company.EtsyID);
            Listing testListing = new Listing
            {
                quantity = "20",
                title = "Better Living Through Despair Orange Font Hoodie",
                description = "Designs are made to order with high quality cotton shirts.",
                price = ".50",
                shipping_template_id = shippingTemplateId,
                state = "draft",
                is_supply = "false",
                who_made = "i_did",
                when_made = "made_to_order"
            };
            ListingService ls = new ListingService();
            ls.CreateListing(client, testListing);

            //CREATING A LISTING IMAGE
            
            var listing = ls.GetListing(client, "265534678");
            string filepath = @"C:\Internal\EtsyProductImages\bettr_despair_orange_white.png";
            ls.CreateListingItemImage(client, listing, "bettr_despair_orange_white.png", filepath);

            //IMPORTING STYLE DATA
            ImportHelpers.TempImportStyleDesc();

            var gclient = InternalClientService.GetInternalClientByID("646");
            List<string> colors = new List<string> { "Black", "White" };
            List<string> designs = new List<string> { "W81MA", "W81WA", "W81XA", "W81YA" };
            List<string> sizes = new List<string> { "S", "M", "L", "XL", "XXL" };



            List<ListingVariation> variations = new List<ListingVariation>();
            ListingVariation variation;

           
            var listings = SS.GetShopListings(client, gclient.EtsyShopIDs.First());

            foreach (var style in gclient.ClientStyles.Where(x => x.style_number == "G2000"))
            {
                foreach (var size in sizes)
                {
                    variation = new ListingVariation();
                    variation.property_id = "100";
                    //variation.is_available = "TRUE";
                    variation.value = string.Format("{0}-{1}", size, style.etsy_style_descripion);
                    variations.Add(variation);
                }
            }
            string output = JsonConvert.SerializeObject(variations.ToArray());
            //Console.Write(output);

            foreach (var l in listings)
            {
                LS.UpdateListingVariations(client, l, output);
                Thread.Sleep(1000);
            }
        }
    }
}
