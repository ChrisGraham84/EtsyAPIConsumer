using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RestSharp;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using EtsyApiConsumer.Helpers;
using EtsyApiConsumer.Models;

namespace EtsyApiConsumer.Services
{
    public class ReceiptService
    {
        #region POST
        public string SubmitTracking(RestClient RestClient, string ReceiptId, string ShopId, string TrackingCode, string CarrierName)
        {
            RestRequest request = new RestRequest();
            request.Method = Method.POST;
            request.AddParameter("tracking_code", TrackingCode);
            request.AddParameter("carrier_name", CarrierName);
            request.Resource = string.Format("shops/{0}/receipts/{1}/tracking", ShopId, ReceiptId);
            IRestResponse response = RestClient.Execute(request);

            return (response.StatusDescription);
        }
        #endregion

        #region GET
        public Receipt GetReceipt(RestClient RestClient, string ReceiptId, bool GetBuyer)
        {
            Receipt receipt = new Receipt();

            RestRequest request = new RestRequest();
            request.Resource = string.Format("receipts/{0}", ReceiptId);
            IRestResponse response = RestClient.Execute(request);
            JObject o = JObject.Parse(response.Content);
            receipt = JsonConvert.DeserializeObject<Receipt>(o["results"][0].ToString());

            UserService US = new UserService();
            if (GetBuyer) { receipt.buyer = US.GetUser(RestClient, receipt.buyer_user_id, false, true); }

            return (receipt);
        }

        public string GetReciptRawJson(RestClient RestClient, string ReceiptId)
        {
            RestRequest request = new RestRequest();
            request.Resource = string.Format("receipts/{0}", ReceiptId);
            IRestResponse response = RestClient.Execute(request);

            return (response.Content);
        }

        public void GetReceiptTransactions(RestClient RestClient, Receipt Receipt)
        {
            Console.WriteLine("Getting Transaction");
            RestRequest request = new RestRequest();
            request.Resource = string.Format("receipts/{0}/transactions", Receipt.receipt_id);
            IRestResponse response = RestClient.Execute(request);
            JObject o = JObject.Parse(response.Content);
            Transaction transaction;
            foreach (var t in o["results"])
            {
                transaction = JsonConvert.DeserializeObject<Transaction>(t.ToString());

                foreach(var v in transaction.variations)
                {
                    v.formatted_name = FormattingHelpers.FixEncoding(v.formatted_name);
                    v.formatted_value = FormattingHelpers.FixEncoding(v.formatted_value);
                }

                Receipt.transactions.Add(transaction);
            }
        }

        public string GetReceiptTransactionRawJson(RestClient RestClient, string ReceiptId)
        {
            RestRequest request = new RestRequest();
            request.Resource = string.Format("receipts/{0}/transactions", ReceiptId);
            IRestResponse response = RestClient.Execute(request);

            return (response.Content);
        }
        #endregion

        #region PUT
        public string UpdateReceipt(RestClient RestClient, string ReceiptId)
        {
            RestRequest request = new RestRequest();
            request.Method = Method.PUT;
            request.AddParameter("was_paid", false);
            request.Resource = string.Format("receipts/{0}", ReceiptId);
            IRestResponse response = RestClient.Execute(request);

            return (response.StatusDescription);
        }
        #endregion


        #region DELETE
        #endregion

    }
}
