using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EtsyApiConsumer.Models;
using EtsyApiConsumer.Services;
using EtsyApiConsumer.Helpers;
using RestSharp;
using RestSharp.Authenticators;
using System.IO;

namespace EtsyApiConsumer.Services
{
    public static class ExtractionService
    {
        public static List<ExtractionModel> CreateExtractionFromReceipt(InternalClient GClient, bool allReceipts)
        {
            //Creation New Rest Client
            var client = new RestClient();
            client.BaseUrl = AppKeys.GetBaseUri();
            client.Authenticator = OAuth1Authenticator.ForProtectedResource(AppKeys.GetApiKey(), AppKeys.GetSharedSecretKey(), GClient.AccessToken, GClient.AccessSecretKey);

            //The shop servce is where we pull receipts because functionally
            //The call is related to the shop object and te shop id
            ShopService shopservice = new ShopService();
            List<Receipt> receipts;

            //This is just in case for some reason we want every transaction from a shop
            if (allReceipts)
            {
                receipts = shopservice.GetShopReceipts(client, GClient.EtsyShopIDs.FirstOrDefault());
            }
            else
            {
                receipts = shopservice.GetOpenShopReceipts(client, GClient.EtsyShopIDs.FirstOrDefault());
            }
            
            //Get the country list from etsy in advance so it doesn't
            //Have to be called per receipt request
            var countries = CountryService.GetCountryMapping(client);

            List<ExtractionModel> extractions = new List<ExtractionModel>();
            
            //make sure we actually pulled back client data
            if (GClient != null)
            {
                //iteract through receipts
                foreach (Receipt r in receipts)
                {
                    //iterrate through transactions of receipts
                    foreach (var t in r.transactions)
                    {
                        string country = countries[int.Parse(r.country_id)];

                        ExtractionModel em = new ExtractionModel();
                        em.company_id = GClient.clientID;
                        em.Order_ID = r.receipt_id;
                        em.date_purchased = FormattingHelpers.FromEpochUnixTime(t.creation_tsz).ToString("g");
                        em.customer_email_address = r.buyer_email;
                        var FirstnameLastname = FormattingHelpers.FirstNameLastNameFormatter(r.name);
                        em.first_name = FirstnameLastname.Item1;
                        em.last_name = FirstnameLastname.Item2;

                        em.delivery_address_1 = r.first_line;
                        em.delivery_address_2 = r.second_line;
                        em.delivery_city = r.city;
                        em.delivery_state = r.state;
                        em.delivery_zipCode = r.zip;
                        em.country = country;
                        
                        //This is for the variation that is assuming
                        //it follows the format "Color - Design"
                        string[] color_design = t.variations.Where(x => x.formatted_name == "Color").FirstOrDefault().formatted_value.Split('-');
                        
                        //If there is not a "-" then it automatically
                        //is the wrong format
                        if(color_design.Length > 1)
                        {
                            //This is making sure that the Design actually is associated
                            //with the client
                            //TODO: Eventually check that the design is actually available in the color
                            //that is provided. 
                            if (GClient.ClientDesigns.Where(x => x.design_number.Trim() == color_design[1].Trim()).Any())
                            {
                                em.color = color_design[0].Trim();
                                em.design_number = FormattingHelpers.DesignNumberFormatCheck(color_design[1].Trim());
                            }
                            else
                            {
                                em.color = color_design[0].Trim();
                                em.design_number = string.Format("{0} Is Not a Correct Design Id",color_design[1]);
                            }
                        }
                        else
                        {
                            em.color = color_design[0].Trim();
                            em.design_number = "Color_Design Incorrect Format";
                        }
                        em.design_description = "TBD";
                        em.print_location = "TBD";


                        //This is for the variation that is assuming
                        //it follows the format "Style - Size"
                        string[] size_style = t.variations.Where(x => x.formatted_name == "Size").FirstOrDefault().formatted_value.Split('-');

                        if (size_style.Length > 1)
                        {
                            string etsystyle = size_style[1].Trim();
                            em.size = size_style[0].Trim();

                            //Check to see if the style from the variation
                            //has a mapping otherwise we can't know what 
                            //prodct style its suposed to be
                            var style = GClient.ClientStyles.Where(x => x.etsy_style_descripion == etsystyle).FirstOrDefault();
                            if (style != null)
                            {
                                em.style_number = style.style_number;
                                em.style_description = style.style_description;
                            }
                            else
                            {
                                em.style_number = "ESTY STYLE '" + etsystyle + "' NOT FOUND";
                                em.style_description = "ESTY STYLE '" + etsystyle + "' NOT FOUND";
                            }
                        }
                        else
                        {
                            em.style_number = size_style[0].Trim();
                            em.style_description = "Size_Style Incorrect Format";
                        }

                        em.product_quantity = t.quantity;
                        em.gift_message = r.message_from_buyer;
                        em.Insured_Order = "No";
                        em.shipping_method = CountryService.GetCountryShippingMethodByCountry(country).Shipping_Method;
                        em.order_status = "2";

                        extractions.Add(em);
                    }
                }
            }
            return (extractions);
        }
        public static void WriteRecieptExtractions(object Extractions)
        {
            var extractions = (List<ExtractionModel>)Extractions;

            List<string> properties = new ExtractionModel().GetType().GetProperties().Select(x => x.Name).ToList();

            StringBuilder sbHeader = new StringBuilder();
            foreach (var prop in properties)
            {
                sbHeader.AppendFormat("{0}\t", prop);
            }
            string filepath = string.Format(@"C:\Internal\Etsy\{0}_etsy_extractiondata.txt", DateTime.Now.ToString("yyMMdd"));
            using (StreamWriter writer = new StreamWriter(filepath))
            {
                writer.WriteLine(sbHeader.ToString());
                foreach (var ext in extractions.OrderBy(x => x.Order_ID))
                {
                    StringBuilder sbData = new StringBuilder();
                    foreach (var prop in properties)
                    {
                        var o = ext.GetType().GetProperty(prop).GetValue(ext, null);
                        if (o == null)
                        {
                            o = "";
                        }
                        sbData.AppendFormat("{0}\t", o.ToString());
                    }
                    writer.WriteLine(sbData.ToString());
                }
            }
        }
    }
}
