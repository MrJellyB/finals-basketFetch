using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Basket.Common.Data
{
    public class GenderDTO
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string _id { get; set; }

        [BsonElement]
        [Display(Name = "value")]
        public string value { get; set; }

        [BsonElement]
        [Display(Name = "id")]
        public int id { get; set; }
    }
}
