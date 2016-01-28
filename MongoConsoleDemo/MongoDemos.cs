using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Driver;
using MongoDB.Shared;

namespace MongoConsoleDemo
{
    public sealed class MongoDemos
    {
        private const string CONN_STRING = "mongodb://localhost:27017/?readpreference=primaryPreferred";

        public static void CollectionDemo()
        {
            var conn = new MongoClient(CONN_STRING);
            var db = conn.GetDatabase("ZYDB");
            var col = db.GetCollection<BsonDocument>("Col1");
            var doc = new BsonDocument { 
                {"Name" , "Zhaoy"},
                {"Age" , 100}
            };

            col.InsertOne(doc);


        }

    }//class
}
