using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EtsyApiConsumer.Models
{
    public class Listing
    {

        public string listing_id { get; set; }
        public string state { get; set; }
        public string user_id { get; set; }
        public string category_id { get; set; }
        public string title { get; set; }
        public string description { get; set; }
        public string creation_tsz { get; set; }
        public string ending_tsz { get; set; }
        public string original_creation_tsz { get; set; }
        public string last_modified_tsz { get; set; }
        public string price { get; set; }
        public string currency_code { get; set; }
        public string quantity { get; set; }
        public string[] tags { get; set; }
        public string[] category_path { get; set; }
        public string[] category_path_ids { get; set; }
        public string taxonomy_id { get; set; }
        public string suggested_taxonomy_id { get; set; }
        public string[] taxonomy_path { get; set; }
        public string[] materials { get; set; }
        public string shop_section_id { get; set; }
        public string state_tsz { get; set; }
        public string url { get; set; }
        public string views { get; set; }
        public string num_favorers { get; set; }
        public string shipping_template_id { get; set; }
        public string shipping_profile_id { get; set; }
        public string processing_min { get; set; }
        public string processing_max { get; set; }
        public string who_made { get; set; }
        public string is_supply { get; set; }
        public string when_made { get; set; }
        public string item_weight { get; set; }
        public string item_weight_units { get; set; }
        public string item_length { get; set; }
        public string item_width { get; set; }
        public string item_height { get; set; }
        public string item_dimension_unit { get; set; }
        public string is_private { get; set; }
        public string recipient { get; set; }
        public string occasion { get; set; }
        public string[] style { get; set; }
        public string non_taxable { get; set; }
        public string is_customizable { get; set; }
        public string is_digital { get; set; }
        public string file_data { get; set; }
        public string has_variations { get; set; }
        public string should_auto_renew { get; set; }
        public string language { get; set; }
        public List<Variation> variations { get; set; }

        public Listing()
        {
            variations = new List<Variation>();
        }
    }
}
