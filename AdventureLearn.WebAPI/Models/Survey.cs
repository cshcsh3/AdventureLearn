using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdventureLearn.WebAPI.Models
{
    public class Survey
    {
        public ObjectId Id { get; set; }
        
        [BsonElement("no")]
        public string No { get; set; }

        [BsonElement("type")]
        public string Type { get; set; }

        [BsonElement("title")]
        public string Title { get; set; }

        [BsonElement("set")]
        public string Set { get; set; }

        [BsonElement("questions")]
        public Question[] Questions { get; set; }
    }
}
