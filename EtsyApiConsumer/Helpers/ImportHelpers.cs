using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EtsyApiConsumer.Models;
using System.IO;
using System.Dynamic;
using EtsyApiConsumer.Services;
using System.Data;
using System.Data.OleDb;
using RestSharp.Authenticators;
using RestSharp;
using System.Threading;

namespace EtsyApiConsumer.Helpers
{
    public static class ImportHelpers
    {
        private static IEnumerable<DataRow> ReadFrom(string file, string sheet)
        {

            using (OleDbConnection con = new OleDbConnection(string.Format(@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source={0};Extended Properties=Excel 8.0", file)))
            {
                OleDbDataAdapter da = new OleDbDataAdapter(string.Format("select * from [{0}$]", sheet), con);
                DataTable dt = new DataTable();
                da.Fill(dt);

                foreach (DataRow dr in dt.AsEnumerable())
                {
                    yield return dr;

                }
            }

        }
        private static IEnumerable<DataRow> ReadFromLongColumn(string file, string sheet)
        {
            using (OleDbConnection con = new OleDbConnection(string.Format(@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source={0};Extended Properties=""Excel 8.0;HDR=No;IMEX=1""", file)))
            {
                OleDbDataAdapter da = new OleDbDataAdapter(string.Format("select * from [{0}$]", sheet), con);
                DataTable dt = new DataTable();
                da.Fill(dt);

                DataTable dt2 = new DataTable();

                foreach (DataColumn dc in dt.Columns)
                {
                    dt2.Columns.Add(dt.Rows[0][dc.ColumnName].ToString());
                }
                foreach (DataRow drreal in dt.AsEnumerable().Skip(1))
                {
                    DataRow newRow = dt2.NewRow();
                    int count = 0;
                    foreach (DataColumn dc in dt.Columns)
                    {
                        newRow[count] = drreal[dc];
                        count++;
                    }
                    dt2.Rows.Add(newRow);
                }

                foreach (DataRow dr in dt2.AsEnumerable())
                {
                    yield return dr;

                }
            }
        }
        private static List<string> Columns(string file, string sheet)
        {
            List<string> columnNames = new List<string>();
            using (OleDbConnection con = new OleDbConnection(string.Format(@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source={0};Extended Properties=""Excel 8.0;HDR=No;IMEX=1""", file)))
            {
                OleDbDataAdapter da = new OleDbDataAdapter(string.Format("select * from [{0}$]", sheet), con);
                DataTable dt = new DataTable();
                da.Fill(dt);

                foreach (DataColumn dc in dt.Columns)
                {
                    columnNames.Add(dt.Rows[0][dc.ColumnName].ToString());
                }
            }
            return (columnNames);
        }

        public static void ShippingSummaries()
        {
            string path = @"C:\Internal\Shipping Summary.xls";
            string sheet = "Shipping Summary";
            var data = ReadFrom(path, sheet);

            var summaries = data.Select(x => new
            {
                CompanyID = x["Company_ID"].ToString(),
                OrderNumber = x["Order_No"].ToString(),
                Tracking = x["Tracking"].ToString()
            }).ToList();

            var gclient = InternalClientService.GetInternalClientByID(summaries.First().CompanyID);
            if (gclient != null)
            {

                var client = new RestClient();
                client.BaseUrl = AppKeys.GetBaseUri();
                client.Authenticator = OAuth1Authenticator.ForProtectedResource(AppKeys.GetApiKey(), AppKeys.GetSharedSecretKey(), gclient.AccessToken, gclient.AccessSecretKey);

                ShopService SS = new ShopService();
                ReceiptService RS = new ReceiptService();
                var receipts = SS.GetShopReceipts(client, gclient.EtsyShopIDs.First());
                foreach (var summary in summaries)
                {
                    Console.WriteLine("Updating Receipt : {0}", summary.OrderNumber);
                    var receipt = receipts.FirstOrDefault(x => x.order_id == summary.OrderNumber);
                    if (receipt != null)
                    {
                        if (!bool.Parse(receipt.was_shipped))
                        {
                            Console.WriteLine("Receipt Status : {0}",RS.UpdateReceipt(client, receipt.receipt_id));
                            Thread.Sleep(1000);
                        }
                        //submit tracking
                        Console.WriteLine("Transcation Status : {0}", RS.SubmitTracking(client, receipt.receipt_id, gclient.EtsyShopIDs.FirstOrDefault(), summary.Tracking, "USPS"));
                        Thread.Sleep(1000);
                    }

                }
            }
        }

        public static void TempImportStyleDesc()
        {
            string path = @"C:\Internal\StyleDescriptions.xls";
            string sheet = "Sheet1";
            var data = ReadFrom(path, sheet);

            var descriptions = data.Select(x => new
            {
                Id = x["client id"].ToString(),
                stylenumber = x["style number"].ToString(),
                styledesc = x["style description"].ToString(),
                clientdesc = x["client description"].ToString()

            }).ToList();

            var gclient = InternalClientService.GetInternalClientByID(descriptions.First().Id);
            if (gclient != null)
            {
                foreach (var desc in descriptions)
                {
                    var gstyledesc = gclient.ClientStyles.FirstOrDefault(x => x.style_number == desc.stylenumber);
                    if (gstyledesc == null)
                    {
                        gstyledesc = new InternalClientStyle();
                        gclient.ClientStyles.Add(gstyledesc);
                    }
                    gstyledesc.etsy_style_descripion = desc.clientdesc;
                    gstyledesc.style_number = desc.stylenumber;
                    gstyledesc.style_description = desc.styledesc;

                    InternalClientService.UpdateInternalClient(gclient);
                }
            }
        }

        public static Dictionary<int, List<string>> ImportTabDelimitedFile(string filepath)
        {

            string line;
            int count = 1;
            Dictionary<int, List<string>> dictRecords = new Dictionary<int, List<string>>();


            // Read the file and display it line by line.
            using (StreamReader file = new StreamReader(filepath))
            {
                while ((line = file.ReadLine()) != null)
                {
                    List<string> sepList = new List<string>();
                    char[] delimiters = new char[] { '\t' };
                    string[] parts = line.Replace("\t", "\t ").Split(delimiters, StringSplitOptions.RemoveEmptyEntries);
                    for (int i = 0; i < parts.Length; i++)
                    {

                        //Console.WriteLine(parts[i]);
                        sepList.Add(parts[i].Trim());

                    }
                    dictRecords.Add(count, sepList);
                    count++;
                }

                file.Close();
            }
            return (dictRecords);
        }
        public static List<T> ImportListFromTabFile<T>(string filepath, List<string> PropertyExceptions, T ObjectType, int HeaderLines, int ColumnRowIndex)
        {
            List<T> data = new List<T>();

            var rawdata = ImportTabDelimitedFile(filepath).Skip(HeaderLines).ToDictionary(x=>x.Key,x=>x.Value);
            List<string> properties = ObjectType.GetType().GetProperties().Where(x => !PropertyExceptions.Contains(x.Name)).Select(x => x.Name).ToList();
            foreach(var v in rawdata.Skip(1))
            {
                T tabobject = (T)Activator.CreateInstance(typeof(T), null);
                foreach(var property in properties)
                {
                    string value = v.Value[rawdata[ColumnRowIndex].IndexOf(property)];
                    var propertyInfo = tabobject.GetType().GetProperty(property);
                    propertyInfo.SetValue(tabobject, value, null);
                }
                data.Add(tabobject);
            }
            return (data);

        }
    }
}
