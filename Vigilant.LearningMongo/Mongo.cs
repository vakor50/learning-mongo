using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Driver;

namespace Vigilant.LearningMongo
{
    public static class Mongo
    {
        private static MongoServer _server;
        private static MongoClient _client;

        private static MongoDatabase _db { get { return Server.GetDatabase(MongoConfig.DATABASE_NAME); } }

        private static MongoServer Server
        {
            get
            {
                if(_server == null)
                {
                    _client = new MongoClient(MongoConfig.CONNECTION_STRING_URI);
                    _server = _client.GetServer();
                }
                return _server;
            }
        }

        public static MongoCollection<T> Database<T>()
        {
            var name = typeof(T).Name;
            return _db.GetCollection<T>(name);
        }
    }

    public static class MongoConfig
    {
        public static readonly string CONNECTION_STRING_URI = "mongodb://<user>:<password>@kahana.mongohq.com:10098/tutorial";
        public static readonly string DATABASE_NAME = "tutorial";
    }
}
