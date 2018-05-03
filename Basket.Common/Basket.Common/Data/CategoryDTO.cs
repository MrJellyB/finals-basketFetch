using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Basket.Common.Data
{
    public class CategoryDTO
    {
        [BsonId]
        //[BsonRepresentation(BsonType.ObjectId)]
        [Display(Name = "_id")]
        public int _id { get; set; }

        [BsonElement]
        [Display(Name = "name")]
        public string name { get; set; }

        [BsonElement]
        [Display(Name = "id")]
        public int id { get; set; }
    }
}
