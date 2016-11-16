using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EtsyApiConsumer.Models
{
    public class Products
    {
        public string Title { get; set; }
        public float BasePrice { get; set; }
        public string Description { get; set; }
        public string Tags { get; set; }
        public int Category { get; set; }
        public List<string> Sizes { get; set; }
        public List<ProductDesignColors> DesignColors { get; set; }
        public StyleEtsyName StyleEtsyName { get; set; }

        public Products()
        {

        }

    }

    public class ProductDesignColors
    {
        public string Color { get; set; }
        public string Design { get; set; }

        public ProductDesignColors()
        {

        }
    }

    public class StyleEtsyName
    {
        public string StyleId { get; set; }
        public string EtsyName { get; set; }

        public StyleEtsyName()
        {

        }
    }
}
