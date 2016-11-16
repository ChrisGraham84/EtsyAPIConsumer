using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RestSharp;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using EtsyApiConsumer.Helpers;

namespace EtsyApiConsumer.Models
{
    public class EtsyOrders
    {
        public int Id { get; set; }
        public string OrderId { get; set; }
        public DateTime DateShipped { get; set; }
        public DateTime DateRecieved { get; set; }
        public List<Transaction> Transactions { get; set; }

        public EtsyOrders()
        {

        }
    }
}
