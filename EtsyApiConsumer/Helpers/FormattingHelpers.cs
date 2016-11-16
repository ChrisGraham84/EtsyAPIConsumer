using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EtsyApiConsumer.Helpers
{
    public static class FormattingHelpers
    {
        public static DateTime FromEpochUnixTime(string EpochSeconds)
        {
            long time = long.Parse(EpochSeconds);
            var epoch = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);
            return epoch.AddSeconds(time);
        }
        public static Tuple<string,string> FirstNameLastNameFormatter(string Name)
        {
            string[] nameSplit = Name.Split(' ');

            string lastname;
            string firstname;
            if (nameSplit.Length > 1)
            {
                lastname = nameSplit[nameSplit.Length - 1];
                firstname = string.Empty;
                for (int i = 0; i < nameSplit.Length - 1; i++)
                {
                    if(i > 0)
                    {
                        firstname += " ";
                    }
                    firstname += nameSplit[i];
                }
            }
            else
            {
                lastname = Name;
                firstname = Name;
            }

            Tuple<string, string> tplFirstnameLastName = new Tuple<string, string>(firstname, lastname);
            return (tplFirstnameLastName);
        }
        public static string DesignNumberFormatCheck(string DesignNumber)
        {
                return (DesignNumber.Length == 5 ? DesignNumber : DesignNumber + "A");
        }
        public static string FixEncoding(string encodedString)
        {
            return (encodedString.Replace("&#39;", "'"));
        }
    }
}
