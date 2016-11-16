using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EtsyApiConsumer.Models
{
    public class CountryShippingMethod
    {
        public int Id { get; set; }
        public string Country { get; set; }
        public string Shipping_Method { get; set; }
    }
}