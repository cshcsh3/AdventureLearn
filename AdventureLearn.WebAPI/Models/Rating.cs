using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdventureLearn.WebAPI.Models
{
    public class Rating
    {
        public ObjectId Id { get; set; }

        [BsonElement("set")]
        public string Set { get; set; }

        [BsonElement("rate")]
        public string[] Rate { get; set; }
    }
}
