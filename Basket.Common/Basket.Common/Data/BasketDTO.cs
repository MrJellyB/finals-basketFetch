using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Basket.Common.Data
{
    [KnownType(typeof(BasketItemsDTO))]
    public class BasketDTO
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string _id { get; set; }

        [BsonElement]
        List<BasketItemsDTO> basketItems { get; set; }
    }

    public class BasketItemsDTO
    {
        [BsonElement]
        public long id { get; set; }
        
        public string name { get; set; }
        
        public string image { get; set; }
        
        [BsonRepresentation(BsonType.Double, AllowTruncation = true)]
        public float price { get; set; }
        
        public int amount { get; set; }
    }
}
