using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EtsyApiConsumer.Models
{
    public class ExtractionModel
    {
        public string company_id { get; set; }
        public string Order_ID { get; set; }
        public string date_purchased { get; set; }
        public string customer_email_address { get; set; }
        public string first_name { get; set; }
        public string last_name { get; set; }
        public string delivery_address_1 { get; set; }
        public string delivery_address_2 { get; set; }
        public string delivery_city { get; set; }
        public string delivery_state { get; set; }
        public string delivery_zipCode { get; set; }
        public string country { get; set; }
        public string design_number { get; set; }
        public string design_description { get; set; }
        public string print_location { get; set; }
        public string style_number { get; set; }
        public string style_description { get; set; }
        public string color { get; set; }
        public string size { get; set; }
        public string product_quantity { get; set; }
        public string gift_message { get; set; }
        public string Insured_Order { get; set; }
        public string shipping_method { get; set; }
        public string order_status { get; set; }

    }
}
