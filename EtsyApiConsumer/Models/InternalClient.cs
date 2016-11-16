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
    public class InternalClient
    {
        public int Id { get; set; }
        public string clientID { get; set; }
        public string clientName { get; set; }
        public string EtsyUserName { get; set; }
        public string EtsyID { get; set; }
        public List<string> EtsyShopIDs { get; set; }
        public string AccessToken { get; set; }
        public string AccessSecretKey { get; set; }
        public List<InternalClientStyle> ClientStyles { get; set; }
        public List<InternalClientDesign> ClientDesigns { get; set; }
    }

    public enum InternalClientProperties
    {
        EtsyUserName,
        EtsyID,
        AccessToken,
        AccessSecretKey,
        ClientStyles
    }
}
