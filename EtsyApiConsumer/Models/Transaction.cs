using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RestSharp;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using EtsyApiConsumer.Helpers;

namespace EtsyApiConsumer.Models
{
    public class Transaction
    {
        public string transaction_id { get; set; }
        public string title { get; set; }
        public string description { get; set; }
        public string seller_user_id { get; set; }
        public string buyer_user_id { get; set; }
        public string creation_tsz { get; set; }
        public string paid_tsz { get; set; }
        public string shipped_tsz { get; set; }
        public string price { get; set; }
        public string currency_code { get; set; }
        public string quantity { get; set; }
        public string[] tags { get; set; }
        public string[] materials { get; set; }
        public string image_listing_id { get; set; }
        public string receipt_id { get; set; }
        public string shipping_cost { get; set; }
        public string is_digital { get; set; }
        public string file_data { get; set; }
        public string listing_id { get; set; }
        public string is_quick_sale { get; set; }
        public string seller_feedback_id { get; set; }
        public string buyer_feedback_id { get; set; }
        public string transaction_type { get; set; }
        public string url { get; set; }
        public List<Variation_SelectedProperty> variations { get; set; }

        public Transaction()
        {
            variations = new List<Variation_SelectedProperty>();
        }



    }
}
