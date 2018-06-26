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
    public class SurveyService : DbService
    {
        public IMongoCollection<BsonDocument> Collection { get; private set; }

        public SurveyService()
        {
            Collection = db.GetCollection<BsonDocument>("survey");
        }

        public List<Survey> GetSurveys()
        {
            FilterDefinition<BsonDocument> filter = FilterDefinition<BsonDocument>.Empty;
            var surveys = Collection.Find(filter).ToList();

            return surveys.Select(b => BsonSerializer.Deserialize<Survey>(b)).ToList();
        }

        public Survey GetSurvey(string no)
        {
            var builder = Builders<BsonDocument>.Filter;
            var filter = builder.Eq("no", no);
            var survey = Collection.Find(filter).Single();

            return BsonSerializer.Deserialize<Survey>(survey);
        }
    }
}
