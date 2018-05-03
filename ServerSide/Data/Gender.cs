using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace ServerSide.Data
{
    public class Gender
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
