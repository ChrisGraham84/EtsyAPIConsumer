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
using LiteDB;

namespace EtsyApiConsumer.Services
{
    //example for beta purposes
    //bool created = InternalClientService.CreateInternalClient("646", "Calculated Failure");
    /// <summary>
    /// Service for all InternalClient CRUD operation. Currently Implementing LiteDB
    /// </summary>
    public static class InternalClientService
    {
        #region CREATE
        /// <summary>
        /// Returns true if new InternalClient is created. Returns false if InternalClient with ClientID is found
        /// </summary>
        /// <param name="ClientID"></param>
        /// <param name="ClientName"></param>
        /// <returns></returns>
        public static bool CreateInternalClient(string ClientID, string ClientName)
        {
            try
            {
                using (var db = new LiteDatabase(AppKeys.GetDataContextString()))
                {
                    var clients = db.GetCollection<InternalClient>("clients");

                    var newclient = clients.Find(x => x.clientID == ClientID).FirstOrDefault();
                    if (newclient == null)
                    {
                        newclient = new InternalClient();
                        newclient.clientID = ClientID;
                        newclient.clientName = ClientName;

                        clients.Insert(newclient);
                        clients.EnsureIndex(x => x.clientID);

                        return (true);
                    }
                    return (false);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("An Error has happened in the CreateInternalClient Method : {0}", ex.ToString());
                return (false);
            }
        }
        #endregion

        #region READ
        public static List<InternalClient> GetAllInternalClients()
        {
            try
            {
                using (var db = new LiteDatabase(AppKeys.GetDataContextString()))
                {
                    var clients = db.GetCollection<InternalClient>("clients");
                    return (clients.FindAll().ToList());
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine("An Error has happened in the GetAllInternalClients Method : {0}", ex.ToString());
                return (null);
            }

        }
        public static InternalClient GetInternalClientByID(string ClientID)
        {
            try
            {
                using (var db = new LiteDatabase(AppKeys.GetDataContextString()))
                {
                    var clients = db.GetCollection<InternalClient>("clients");
                    return (clients.Find(x => x.clientID == ClientID).FirstOrDefault());
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine("An Error has happened in the GetInternalClientByID Method : {0}", ex.ToString());
                return (null);
            }
            
           
        }
        public static InternalClient GetInternalClientByEtsyID(string EtsyID)
        {
            try
            {
                using (var db = new LiteDatabase(AppKeys.GetDataContextString()))
                {
                    var clients = db.GetCollection<InternalClient>("clients");
                    return (clients.Find(x => x.EtsyID == EtsyID).FirstOrDefault());
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine("An Error has happened in the GetInternalClientByEtsyID Method : {0}", ex.ToString());
                return (null);
            }
        }
        #endregion

        #region UPDATE
        public static bool UpdateInternalClient(InternalClient Client)
        {
            try
            {
                using (var db = new LiteDatabase(AppKeys.GetDataContextString()))
                {

                    var clients = db.GetCollection<InternalClient>("clients");
                    var dbclient = clients.Find(x => x.clientID == Client.clientID).FirstOrDefault();

                    //if there is no clientID and no clientName it's not a valid client to update from
                    if (!string.IsNullOrEmpty(Client.clientID) && !string.IsNullOrEmpty(Client.clientName))
                    {
                        //if it is not in the database add it
                        if (dbclient == null)
                        {
                            dbclient = new InternalClient();
                            dbclient.clientID = Client.clientID;
                            dbclient.clientName = Client.clientName;

                            clients.Insert(dbclient);
                            clients.EnsureIndex(x => x.clientID);

                        }

                        //never update the client ID or client name after the item has been created.
                        dbclient.EtsyID = Client.EtsyID;
                        dbclient.EtsyUserName = Client.EtsyUserName;
                        dbclient.AccessToken = Client.AccessToken;
                        dbclient.AccessSecretKey = Client.AccessSecretKey;
                        dbclient.ClientStyles = Client.ClientStyles;
                        dbclient.ClientDesigns = Client.ClientDesigns;
                        dbclient.EtsyShopIDs = Client.EtsyShopIDs;
                        clients.Update(dbclient);

                        return (true);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("An Error has happened in the GetInternalClientByID Method : {0}", ex.ToString());
                return (false);
            }
            return (false);
        }
        public static void UpdatInternalClientByParameter(InternalClientProperties Property, object Value, string ClientID)
        {
            InternalClient client = null;
            using (var db = new LiteDatabase(AppKeys.GetDataContextString()))
            {
                var clients = db.GetCollection<InternalClient>("clients");
                client = clients.Find(x => x.clientID == ClientID).FirstOrDefault();
                if (client != null)
                {
                    var value = new object();
                    if (Property == InternalClientProperties.ClientStyles)
                    {
                        value = (List<InternalClientStyle>)Value;
                    }
                    else
                    {
                        value = Value.ToString();
                    }

                    client.GetType().GetProperty(Property.ToString()).SetValue(client, value);
                    clients.Update(client);
                }
            }

        }
        #endregion

        #region DELETE
        #endregion
    }
}
