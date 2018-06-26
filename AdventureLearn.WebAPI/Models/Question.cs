using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdventureLearn.WebAPI.Models
{
    public class Question
    {
        [BsonElement("qns")]
        public string Qns { get; set; }

        [BsonElement("options")]
        public string[] Options { get; set; }
    }
}
