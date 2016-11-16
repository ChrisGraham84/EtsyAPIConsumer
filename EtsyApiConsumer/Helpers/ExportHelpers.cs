using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EtsyApiConsumer.Models;
using System.IO;
using System.Dynamic;
using EtsyApiConsumer.Services;

namespace EtsyApiConsumer.Helpers
{
    public static class ExportHelpers
    {
        public static void ShopDataExport(List<User> users, string filepath, bool run)
        {
            if (run)
            {
                if (File.Exists(filepath))
                {
                    File.Delete(filepath);
                }

                //get all shops
                List<Shop> shops = users.SelectMany(x => x.shops).ToList();
                List<Listing> listings = shops.SelectMany(x => x.listings).ToList();
                List<Receipt> receipts = shops.SelectMany(x => x.receipts).ToList();
                List<Transaction> transactions = receipts.SelectMany(x => x.transactions).ToList();

                //Export the user data set
                using (StreamWriter writer = new StreamWriter(filepath.Replace(".txt", "_user.txt")))
                {
                    StringBuilder sbHeader = new StringBuilder();
                    List<string> properties = users.FirstOrDefault().GetType().GetProperties().Select(x => x.Name).ToList();

                    foreach (var prop in properties)
                    {
                        sbHeader.AppendFormat("{0}\t", prop);
                    }
                    writer.WriteLine(sbHeader.ToString());

                    foreach (User user in users)
                    {
                        StringBuilder sbUserData = new StringBuilder();
                        foreach (var prop in properties)
                        {
                            var o = user.GetType().GetProperty(prop).GetValue(user, null);
                            if (o != null)
                            {
                                sbUserData.AppendFormat("{0}\t", o.ToString());
                            }
                        }
                        writer.WriteLine(sbUserData.ToString());
                    }
                }


                //Export the shop data set
                using (StreamWriter writer = new StreamWriter(filepath.Replace(".txt", "_shops.txt")))
                {
                    StringBuilder sbHeader = new StringBuilder();
                    List<string> properties = new Shop().GetType().GetProperties().Select(x => x.Name).ToList();

                    foreach (var prop in properties)
                    {
                        sbHeader.AppendFormat("{0}\t", prop);
                    }
                    writer.WriteLine(sbHeader.ToString());

                    foreach (Shop shop in shops)
                    {
                        StringBuilder sbShopData = new StringBuilder();
                        foreach (var prop in properties)
                        {
                            var o = shop.GetType().GetProperty(prop).GetValue(shop, null);
                            if (o != null)
                            {
                                sbShopData.AppendFormat("{0}\t", o.ToString());
                            }
                        }
                        writer.WriteLine(sbShopData.ToString());
                    }

                }

                //Export listing data set
                using (StreamWriter writer = new StreamWriter(filepath.Replace(".txt", "_listings.txt")))
                {
                    StringBuilder sbHeader = new StringBuilder();
                    List<string> properties = new Listing().GetType().GetProperties().Select(x => x.Name).ToList();

                    foreach (var prop in properties)
                    {
                        sbHeader.AppendFormat("{0}\t", prop);
                    }
                    writer.WriteLine(sbHeader.ToString());

                    foreach (Listing listing in listings)
                    {
                        StringBuilder sbListringData = new StringBuilder();
                        foreach (var prop in properties)
                        {
                            var o = listing.GetType().GetProperty(prop).GetValue(listing, null);
                            if (o != null)
                            {
                                if (o is Array)
                                {
                                    var array = (string[])o;
                                    StringBuilder sbArrayData = new StringBuilder();
                                    for (int i = 0; i < array.Length; i++)
                                    {

                                        sbArrayData.Append(array[i]);
                                        if (i > 0)
                                        {
                                            sbArrayData.Append(",");
                                        }
                                    }
                                    sbListringData.AppendFormat("{0}\t", sbArrayData.ToString());
                                }
                                else
                                {
                                    sbListringData.AppendFormat("{0}\t", o.ToString());
                                }
                            }
                        }
                        writer.WriteLine(sbListringData.ToString());
                    }
                }

                //Export Receipt Data Set
                using (StreamWriter writer = new StreamWriter(filepath.Replace(".txt", "_receipts.txt")))
                {
                    StringBuilder sbHeader = new StringBuilder();
                    List<string> properties = new Receipt().GetType().GetProperties().Select(x => x.Name).ToList();

                    foreach (var prop in properties)
                    {
                        sbHeader.AppendFormat("{0}\t", prop);
                    }
                    writer.WriteLine(sbHeader.ToString());

                    foreach (Receipt receipt in receipts)
                    {
                        StringBuilder sbData = new StringBuilder();
                        foreach (var prop in properties)
                        {
                            var o = receipt.GetType().GetProperty(prop).GetValue(receipt, null);
                            if (o == null)
                            {
                                o = "";
                            }

                            if (o is Array)
                            {
                                var array = (string[])o;
                                StringBuilder sbArrayData = new StringBuilder();
                                for (int i = 0; i < array.Length; i++)
                                {
                                    sbArrayData.Append(array[i]);
                                    if (i > 0)
                                    {
                                        sbArrayData.Append(",");
                                    }
                                }
                                sbData.AppendFormat("{0}\t", sbArrayData.ToString());
                            }
                            else
                            {
                                sbData.AppendFormat("{0}\t", o.ToString());
                            }
                        }
                        writer.WriteLine(sbData.ToString());
                    }


                }

                //Export Transaction Data
                using (StreamWriter writer = new StreamWriter(filepath.Replace(".txt", "_transactions.txt")))
                {
                    StringBuilder sbHeader = new StringBuilder();
                    List<string> properties = new Transaction().GetType().GetProperties().Select(x => x.Name).ToList();

                    foreach (var prop in properties)
                    {
                        sbHeader.AppendFormat("{0}\t", prop);
                    }
                    writer.WriteLine(sbHeader.ToString());

                    foreach (Transaction transaction in transactions)
                    {
                        StringBuilder sbData = new StringBuilder();
                        foreach (var prop in properties)
                        {
                            var o = transaction.GetType().GetProperty(prop).GetValue(transaction, null);
                            if (o == null)
                            {
                                o = "";
                            }

                            if (o is Array)
                            {
                                var array = (string[])o;
                                StringBuilder sbArrayData = new StringBuilder();
                                for (int i = 0; i < array.Length; i++)
                                {
                                    sbArrayData.Append(array[i]);
                                    if (i > 0)
                                    {
                                        sbArrayData.Append(",");
                                    }
                                }
                                sbData.AppendFormat("{0}\t", sbArrayData.ToString());
                            }
                            else if (o is List<Variation_SelectedProperty>)
                            {
                                var variations = (List<Variation_SelectedProperty>)o;
                                foreach (var variation in variations)
                                {
                                    sbData.AppendFormat("Variation: {0}, {1} , {2}; ", variation.formatted_value, variation.formatted_name, variation.value_id);
                                }
                                sbData.AppendFormat("\t");
                            }
                            else
                            { sbData.AppendFormat("{0}\t", o.ToString()); }
                        }
                        writer.WriteLine(sbData.ToString());
                    }
                }
            }
        }
        public static void ExtractionExport(List<Receipt> Receipts, string filepath,Dictionary<int,string> Countries, bool run)
        {
            if (run)
            {
                if (File.Exists(filepath))
                {
                    File.Delete(filepath);
                }
                List<ExtractionModel> extractions = new List<ExtractionModel>();

                var gclient = InternalClientService.GetInternalClientByEtsyID(Receipts.FirstOrDefault().seller_user_id);
                
                if (gclient != null)
                {
                    foreach (Receipt r in Receipts)
                    {
                        foreach (var t in r.transactions)
                        {
                            string country = Countries[int.Parse(r.country_id)];

                            ExtractionModel em = new ExtractionModel();
                            em.company_id = gclient.clientID;
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

                            string[] color_design = t.variations.Where(x => x.formatted_name == "Color").FirstOrDefault().formatted_value.Split('-');
                            em.color = color_design[0].Trim();
                            em.design_number = FormattingHelpers.DesignNumberFormatCheck(color_design[1].Trim());
                            em.design_description = "TBD";
                            em.print_location = "TBD";

                           
                            string[] size_style = t.variations.Where(x => x.formatted_name == "Size").FirstOrDefault().formatted_value.Split('-');
                            string etsystyle = size_style[1].Trim();
                            em.size = size_style[0].Trim();
                            em.style_number = gclient.ClientStyles.Where(x=>x.etsy_style_descripion == etsystyle).First().style_number;
                            em.style_description = gclient.ClientStyles.Where(x => x.etsy_style_descripion == etsystyle).First().style_description;

                            em.product_quantity = t.quantity;
                            em.gift_message = r.message_from_buyer;
                            em.Insured_Order = "No";
                            em.shipping_method = CountryService.GetCountryShippingMethodByCountry(country).Shipping_Method;
                            em.order_status = "2";

                            extractions.Add(em);
                        }
                    }
                }

                List<string> properties = new ExtractionModel().GetType().GetProperties().Select(x => x.Name).ToList();

                StringBuilder sbHeader = new StringBuilder();
                foreach (var prop in properties)
                {
                    sbHeader.AppendFormat("{0}\t", prop);
                }

                using (StreamWriter writer = new StreamWriter(filepath.Replace(".txt", "_extractiondata"+DateTime.Now.ToString("yyMMdd") + ".txt")))
                {
                    writer.WriteLine(sbHeader.ToString());
                    foreach (var ext in extractions.OrderBy(x=>x.Order_ID))
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
        public static void ReceiptTransactionExport(List<Receipt> Receipts, string filepath, bool run)
        {
            List<ReceiptTransaction> export = new List<ReceiptTransaction>();

            string rawdata = string.Empty;

            foreach (Receipt r in Receipts)
            {
                foreach (var t in r.transactions)
                {
                    ReceiptTransaction rt = new ReceiptTransaction();
                    rt.transaction_id = t.transaction_id;
                    rt.quanity = t.quantity;
                    StringBuilder sbVariations = new StringBuilder();
                    foreach (var v in t.variations)
                    {
                        sbVariations.AppendFormat("Variation: {0}, {1} , {2}; ", v.formatted_value, v.formatted_name, v.value_id);
                    }
                    rt.seller_user_id = r.seller_user_id;
                    rt.variations = sbVariations.ToString();
                    rt.order_id = r.order_id;
                    rt.name = r.name;
                    rt.first_line = r.first_line;
                    rt.second_line = r.second_line;
                    rt.city = r.city;
                    rt.state = r.state;
                    rt.zip = r.zip;
                    rt.country_id = r.country_id;
                    rt.message_from_buyer = r.message_from_buyer;
                    rt.was_paid = r.was_paid;
                    rt.buyer_email = r.buyer_email;

                    export.Add(rt);
                }

                
            }

            using (StreamWriter writer = new StreamWriter(filepath.Replace(".txt", "_transactionsdata.txt")))
            {
                StringBuilder sbHeader = new StringBuilder();
                List<string> properties = new ReceiptTransaction().GetType().GetProperties().Select(x => x.Name).ToList();

                foreach (var prop in properties)
                {
                    sbHeader.AppendFormat("{0}\t", prop);
                }
                writer.WriteLine(sbHeader.ToString());
                foreach (var rt in export)
                {
                    StringBuilder sbData = new StringBuilder();
                    foreach (var prop in properties)
                    {
                        var o = rt.GetType().GetProperty(prop).GetValue(rt, null);
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
        public static void ExportRawData(string data,string receiptid, string filepath, bool run)
        {
            using (StreamWriter writer = new StreamWriter(filepath.Replace(".txt", "_"+receiptid+"_raw.txt")))
            {
                writer.WriteLine(data);
            }
        }
        public static void ExportListingIdAndVariations(List<Models.Listing> Listings, string filepath, bool run)
        {
            if (run)
            {
                using (StreamWriter writer = new StreamWriter(filepath))
                {
                    List<string> lstProperties = new List<string> { "listing_id", "title", "variations", "variation_value","variation1","variation2" };
                    StringBuilder sbHeader = new StringBuilder();
                    foreach (var prop in lstProperties)
                    {
                        sbHeader.AppendFormat("{0}\t", prop);
                    }
                    writer.WriteLine(sbHeader.ToString());
                    foreach (var listing in Listings)
                    {
                        if (listing.variations.Count > 1)
                        {
                            foreach (var opt_v1 in listing.variations[0].options)
                            {
                                foreach (var opt_v2 in listing.variations[1].options)
                                {
                                    StringBuilder sbData = new StringBuilder();
                                    string optv1v2 = opt_v1.value + "," + opt_v2.value;
                                    sbData.AppendFormat("{0}\t{1}\t{2},{3}\t{4}\t{5}\t{6}", listing.listing_id, listing.title.Replace("&#39;","'"), listing.variations[0].formatted_name.Replace("&#39;", "'"),
                                        listing.variations[1].formatted_name.Replace("&#39;", "'"), optv1v2.Replace("&#39;", "'"), opt_v1.value.Replace("&#39;", "'"), opt_v2.value.Replace("&#39;", "'"));
                                    writer.WriteLine(sbData.ToString());
                                }
                            }
                        }
                        //foreach (var variation in listing.variations)
                        //{
                        //    foreach (var option in variation.options)
                        //    {
                        //        StringBuilder sbData = new StringBuilder();
                        //        foreach (var prop in lstProperties)
                        //        {
                        //            if (listing.GetType().GetProperty(prop) != null)
                        //            {
                        //                var o = listing.GetType().GetProperty(prop).GetValue(listing, null);
                        //                if (o == null)
                        //                {
                        //                    o = "";
                        //                }
                        //                else if (o is List<Variation>)
                        //                {
                        //                    o = variation.formatted_name;
                        //                }
                        //                sbData.AppendFormat("{0}\t", o.ToString());
                        //            }
                        //            else
                        //            {
                        //                sbData.AppendFormat("{0}\t", option.value);
                        //            }
                        //        }
                        //        writer.WriteLine(sbData.ToString());
                        //    }
                        //}

                    }
                }
            }
        }
    }
}
