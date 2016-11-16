using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EtsyApiConsumer.Models
{
    public class Shop
    {
        public string shop_id { get; set; }
        public string shop_name { get; set; }
        public string user_id { get; set; }
        public string creation_tsz { get; set; }
        public string title { get; set; }
        public string announcement { get; set; }
        public string currency_code { get; set; }
        public string is_vacation { get; set; }
        public string vacation_message { get; set; }
        public string sale_message { get; set; }
        public string digital_sale_message { get; set; }
        public string last_updated_tsz { get; set; }
        public string listing_active_count { get; set; }
        public string digital_listin_count { get; set; }
        public string login_name { get; set; }
        public string lat { get; set; }
        public string lon { get; set; }
        public string accepts_custom_requests { get; set; }
        public string policy_welcome { get; set; }
        public string policy_payment { get; set; }
        public string policy_shipping { get; set; }
        public string policy_refunds { get; set; }
        public string policy_additional { get; set; }
        public string policy_seller_info { get; set; }
        public string policy_updated_tsz { get; set; }
        public string vacation_autoreply { get; set; }
        public string ga_code { get; set; }
        public string url { get; set; }
        public string image_url_760x100 { get; set; }
        public string num_favorers { get; set; }
        public string[] languages { get; set; }
        public string upcoming_local_event_id { get; set; }
        public string icon_ul_fullxfull { get; set; }
        public List<Listing> listings;
        public List<Receipt> receipts;

        public Shop()
        {
            this.listings = new List<Listing>();
            this.receipts = new List<Receipt>();
        }
    }
}
