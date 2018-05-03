using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Basket.Common.Data
{
    public class ProductDTO
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string _id { get; set; }

        [BsonElement]
        [Display(Name = "PriceUpdateDate")]
        public string PriceUpdateDate { get; set; }

        [BsonElement]
        [Display(Name = "id")]
        public long id { get; set; }

        [BsonElement]
        [Display(Name = "ItemType")]
        public int ItemType { get; set; }

        [BsonElement]
        [Display(Name = "name")]
        public string name { get; set; }

        [BsonElement]
        [Display(Name = "company")]
        public string company { get; set; }



        [BsonElement]
        [Display(Name = "createCountry")]
        public string createCountry { get; set; }

        [BsonElement]
        [Display(Name = "ManufacturerItemDescription")]
        public string ManufacturerItemDescription { get; set; }

        [BsonElement]
        [Display(Name = "UnitQty")]
        public string UnitQty { get; set; }

        [BsonElement]
        [Display(Name = "Quantity")]
        [BsonRepresentation(BsonType.Double, AllowTruncation = true)]
        public float Quantity { get; set; }

        [BsonElement]
        [Display(Name = "bIsWeighted")]
        public int bIsWeighted { get; set; }

        [BsonElement]
        [Display(Name = "UnitOfMeasure")]
        public string UnitOfMeasure { get; set; }

        [BsonElement]
        [Display(Name = "QtyInPackage")]
        public int QtyInPackage { get; set; }

        [BsonElement]
        [Display(Name = "price")]
        [BsonRepresentation(BsonType.Double, AllowTruncation = true)]
        public float price { get; set; }

        [BsonElement]
        [Display(Name = "UnitOfMeasurePrice")]
        [BsonRepresentation(BsonType.Double, AllowTruncation = true)]
        public float UnitOfMeasurePrice { get; set; }

        [BsonElement]
        [Display(Name = "AllowDiscount")]
        public int AllowDiscount { get; set; }

        [BsonElement]
        [Display(Name = "ItemStatus")]
        public int ItemStatus { get; set; }

        [BsonElement]
        [Display(Name = "category")]
        public int category { get; set; }
    }
}
