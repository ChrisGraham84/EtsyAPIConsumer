using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EtsyApiConsumer.Models
{
    public class SKUImportTemplate
    {
        public string item_sku { get; set; }
        public string item_name { get; set; }
        public string external_product_id { get; set; }
        public string external_product_id_type { get; set; }
        public string brand_name { get; set; }
        public string item_type { get; set; }
        public string main_image_url { get; set; }
        public string color_name { get; set; }
        public string department_name { get; set; }
        public string size_name { get; set; }
        public string product_description { get; set; }
        public string model { get; set; }
        public string update_delete { get; set; }
        public string standard_price { get; set; }
        public string list_price { get; set; }
        public string currency { get; set; }
        public string product_tax_code { get; set; }
        public string fulfillment_latency { get; set; }
        public string product_site_launch_date { get; set; }
        public string merchant_release_date { get; set; }
        public string restock_date { get; set; }
        public string quantity { get; set; }
        public string sale_price { get; set; }
        public string sale_from_date { get; set; }
        public string sale_end_date { get; set; }
        public string item_package_quantity { get; set; }
        public string number_of_items { get; set; }
        public string offering_can_be_gift_messaged { get; set; }
        public string offering_can_be_giftwrapped { get; set; }
        public string website_shipping_weight { get; set; }
        public string website_shipping_weight_unit_of_measure { get; set; }
        public string bullet_point1 { get; set; }
        public string bullet_point2 { get; set; }
        public string bullet_point3 { get; set; }
        public string bullet_point4 { get; set; }
        public string bullet_point5 { get; set; }
        public string generic_keywords1 { get; set; }
        public string generic_keywords2 { get; set; }
        public string generic_keywords3 { get; set; }
        public string generic_keywords4 { get; set; }
        public string generic_keywords5 { get; set; }
        public string other_image_url1 { get; set; }
        public string other_image_url2 { get; set; }
        public string other_image_url3 { get; set; }
        public string swatch_image_url { get; set; }
        public string fulfillment_center_id { get; set; }
        public string package_height { get; set; }
        public string package_width { get; set; }
        public string package_length { get; set; }
        public string package_length_unit_of_measure { get; set; }
        public string package_weight { get; set; }
        public string package_weight_unit_of_measure { get; set; }
        public string parent_child { get; set; }
        public string parent_sku { get; set; }
        public string relationship_type { get; set; }
        public string variation_theme { get; set; }
        public string cpsia_cautionary_statement1 { get; set; }
        public string cpsia_cautionary_statement2 { get; set; }
        public string cpsia_cautionary_statement3 { get; set; }
        public string cpsia_cautionary_statement4 { get; set; }
        public string belt_style { get; set; }
        public string subject_character { get; set; }
        public string chest_size { get; set; }
        public string chest_size_unit_of_measure { get; set; }
        public string collar_style { get; set; }
        public string color_map { get; set; }
        public string cuff_type { get; set; }
        public string cup_size { get; set; }
        public string fit_type { get; set; }
        public string front_style { get; set; }
        public string rise_height { get; set; }
        public string leg_style { get; set; }
        public string fabric_type { get; set; }
        public string import_designation { get; set; }
        public string country_as_labeled { get; set; }
        public string neck_size { get; set; }
        public string neck_size_unit_of_measure { get; set; }
        public string size_map { get; set; }
        public string special_size_type { get; set; }
        public string sleeve_length { get; set; }
        public string sleeve_length_unit_of_measure { get; set; }
        public string style_name { get; set; }
        public string theme { get; set; }
        public string wheel_type { get; set; }
        public string sport_type { get; set; }
        public List<SKUImportTemplate> children { get; set; }

        public SKUImportTemplate()
        {

        }
    }
}
