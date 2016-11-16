using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EtsyApiConsumer.Models
{
    public class Variation_SelectedProperty
    {
        public string property_id { get; set; }
        public string value_id { get; set; }
        public string formatted_name { get; set; }
        public string formatted_value { get; set; }
        public string is_valid { get; set; }

        public Variation_SelectedProperty()
        {

        }
    }
}
