using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EtsyApiConsumer.Models
{
    public class ReceiptTransaction
    {
        public string seller_user_id { get; set; }
        public string transaction_id { get; set; }
        public string quanity { get; set; }
        public string variations { get; set; }
        public string order_id { get; set; }
        public string name { get; set; }
        public string first_line { get; set; }
        public string second_line { get; set; }
        public string city { get; set; }
        public string state { get; set; }
        public string zip { get; set; }
        public string country_id { get; set; }
        public string message_from_buyer { get; set; }
        public string was_paid { get; set; }
        public string buyer_email { get; set; }

        public ReceiptTransaction()
        {

        }
    }
}
