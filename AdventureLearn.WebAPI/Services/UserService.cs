using AdventureLearn.WebAPI.Models;
using MongoDB.Bson;
using MongoDB.Bson.Serialization;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdventureLearn.WebAPI.Services
{
    public class UserService : DbService
    {
        public IMongoCollection<BsonDocument> Collection { get; private set; }

        public UserService()
        {
            Collection = db.GetCollection<BsonDocument>("user");
        }

        public User GetUser(string email)
        {
            var builder = Builders<BsonDocument>.Filter;
            var filter = builder.Eq("email", email);
            var user = Collection.Find(filter).Single();

            return BsonSerializer.Deserialize<User>(user);
        }
    }
}
