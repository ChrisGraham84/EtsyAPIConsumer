using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EtsyApiConsumer.Models
{
    public class InternalClientDesign
    {
        public string design_number { get; set; }
        public bool isDefault { get; set; }
        public List<string> colors { get; set; }
    }
}
