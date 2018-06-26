using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdventureLearn.WebAPI.Services
{
    public class DbService
    {
        public IMongoDatabase db { get; set; }

        public DbService()
        {
            var client = new MongoClient("mongodb://localhost:27017");
            db = client.GetDatabase("testapp");
        }
    }
}
