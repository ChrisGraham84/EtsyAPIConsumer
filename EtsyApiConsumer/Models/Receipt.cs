using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EtsyApiConsumer.Models
{
    public class Receipt
    {
        public string receipt_id { get; set; }
        public string order_id { get; set; }
        public string seller_user_id { get; set; }
        public string buyer_user_id { get; set; }
        public string creation_tsz { get; set; }
        public string last_modified_tsz { get; set; }
        public string name { get; set; }
        public string first_line { get; set; }
        public string second_line { get; set; }
        public string city { get; set; }
        public string state { get; set; }
        public string zip { get; set; }
        public string country_id { get; set; }
        public string payment_method { get; set; }
        public string payment_email { get; set; }
        public string message_from_seller { get; set; }
        public string message_from_buyer { get; set; }
        public string was_paid { get; set; }
        public string total_tax_cost { get; set; }
        public string total_vat_cost { get; set; }
        public string total_price { get; set; }
        public string total_shipping_cost { get; set; }
        public string currency_code { get; set; }
        public string message_from_payment { get; set; }
        public string was_shipped { get; set; }
        public string buyer_email { get; set; }
        public string seller_email { get; set; }
        public string discount_amt { get; set; }
        public string subtotal { get; set; }
        public string grandtotal { get; set; }
        public string adjusted_grandtotal { get; set; }
        public List<Transaction> transactions;
        public User buyer { get; set; }
            

        public Receipt()
        {
            transactions = new List<Transaction>();
        }

    }
}
