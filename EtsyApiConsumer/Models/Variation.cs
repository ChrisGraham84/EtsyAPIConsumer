using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EtsyApiConsumer.Models
{
    public class Variation
    {
        public string property_id;
        public string formatted_name;
        public List<VariationOptions> options;

        public Variation()
        {
            options = new List<VariationOptions>();
        }
    }
}
