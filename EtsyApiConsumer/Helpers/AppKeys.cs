using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EtsyApiConsumer.Helpers
{
    public static class AppKeys
    {

        public static string GetApiKey()
        {
            return ("");
        }

        public static Uri GetBaseUri()
        {
            return (new Uri("https://openapi.etsy.com/v2/"));
        }

        public static string GetSharedSecretKey()
        {
            return ("");
        }

        public static string GetDataContextString()
        {
            return ("InternalEtsyData.db");
        }
    }
}
