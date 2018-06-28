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
    public class RatingService : DbService
    {
        public IMongoCollection<BsonDocument> Collection { get; private set; }

        public RatingService()
        {
            Collection = db.GetCollection<BsonDocument>("rating");
        }

        public Rating GetRating(string set)
        {
            var builder = Builders<BsonDocument>.Filter;
            var filter = builder.Eq("set", set);
            var rating = Collection.Find(filter).Single();

            return BsonSerializer.Deserialize<Rating>(rating);
        }
    }
}
