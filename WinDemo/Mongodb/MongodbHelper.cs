using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.SessionState;
using System.IO;
using MongoDB.Driver.Builders;

namespace WinDemo.Mongodb
{
    public  class MongodbHelper
    {
        private string connString = string.Empty;
        private string databaseName = string.Empty;

        public MongodbHelper(string connStr,string dbName)
        {
            connString = connStr;
            databaseName = dbName;
        }

        public string ConnectionString
        {
            get
            {
                return connString;
            }
        }

        public string DatabaseName
        {
            get
            {
                return databaseName;
            }
        }

        public MongoCollection<BsonDocument> GetCollection(string collectionName = "Sessions")
        {

            var client = new MongoClient(ConnectionString);
            var db = client.GetServer().GetDatabase(DatabaseName);
            //MongoCollectionSettings<BsonDocument> collectionSetting = new MongoCollectionSettings<BsonDocument>(db, collectionName);
            //collectionSetting.ReadPreference = ReadPreference.PrimaryPreferred;
            //collectionSetting.WriteConcern = WriteConcern.Acknowledged;

            return db.GetCollection(collectionName);
        }

        public void InsertDoc(MongoSessionDocument item)
        {
            var timeToLive = DateTime.UtcNow.AddMinutes(item.Timeout);
            var sessItem = Serialize(item.SessionItems);

            var coll = GetCollection();
            var idxOptions = IndexOptions.SetTimeToLive(TimeSpan.FromMinutes(item.Timeout));
            coll.CreateIndex(new IndexKeysBuilder().Ascending("Expires"), idxOptions);

            BsonDocument insertDoc = new BsonDocument();
            insertDoc.Add("_id", item.ID);
            insertDoc.Add("ApplicationName", item.ApplicationName);
            insertDoc.Add("Created", item.Created);
            insertDoc.Add("Expires", timeToLive);
            insertDoc.Add("LockDate", item.LockDate);
            insertDoc.Add("LockId", item.LockId);
            insertDoc.Add("Timeout", item.Timeout);
            insertDoc.Add("Locked", item.Locked);
            insertDoc.Add("SessionItems", sessItem);
            insertDoc.Add("Flags", item.Flags);
            insertDoc.Add("User", item.User);

            var ret= coll.Save(insertDoc);

        }

        public void UpdateDoc(MongoSessionDocument item)
        {
            var coll = GetCollection();

            var sessItem = Serialize(item.SessionItems);
            var query = Query.And(Query.EQ("_id", item.ID), Query.EQ("LockId", item.LockId));
            var update = Update.Set("Expires", DateTime.UtcNow.AddMinutes(item.Timeout));
            update.Set("SessionItems", sessItem);
            update.Set("Locked", false);
            update.Set("User", item.User);

            coll.Update(query,update);
        }

        public void InsertAndUpdate(MongoSessionDocument item)
        {
            InsertDoc(item);
            UpdateDoc(item);
        }

        public void GetAndUpdate(string id)
        {

            var coll = GetCollection();

            var lockQuery = Query.And(Query.EQ("_id", id), Query.EQ("Locked", false), Query.GT("Expires", DateTime.UtcNow));
            var lockUpdate = Update.Set("Locked", true);
            lockUpdate.Set("LockDate", DateTime.UtcNow);
            coll.Update(lockQuery, lockUpdate);

            
            var query = Query.And(Query.EQ("_id",id));
            var results = coll.FindOneAs<BsonDocument>(query);
            query = Query.And(Query.EQ("_id",id));
            var update = Update.Set("LockId", 0);
            update.Set("Flags", 0);
            coll.Update(query, update);
        }

        private string Serialize(SessionStateItemCollection items)
        {
            //using (var ms = new MemoryStream() )
            //{
            //    using (var br = new BinaryWriter(ms))
            //    {
            //        if (items!=null)
            //        {
            //            items.Serialize(br);
            //        }
            //        return Convert.ToBase64String(ms.ToArray());
            //    }
            //}

            return "AAAsdfasfasdfasdfasdfasdfasdfasdfasdfaaaaaaaaaaaaffffffasdfsdafklldksjfldksjfsdhofhosdfhosdfusdaofasBBB";
        }
    }
}
