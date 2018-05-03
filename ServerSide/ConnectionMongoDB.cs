using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Driver;
using MongoDB.Driver.Builders;
using MongoDB.Driver.GridFS;
using MongoDB.Driver.Linq;
using ServerSide.Data;

namespace ServerSide
{
    public class ConnectionMongoDB
    {
        #region Consts

        //private const string URL = "mongodb://localhost";
        //public const string URL = "mongodb://localhost:27017";
        public const string URL = "mongodb://11:22@193.106.55.172:8888/test";
        public const string PRODUCT_NAME_COLLECTION = "product";
        public const string GENDER_NAME_COLLECTION = "gender";

        #endregion

        #region C'Tors

        public ConnectionMongoDB()
        {
        }

        #endregion

        #region Properties

        public MongoClient client { get; set; }
        public MongoServer server { get; set; }
        public MongoDatabase database { get; set; }
        public MongoCollection genderCollection { get; set; }
        public MongoCollection productCollection { get; set; }



        #endregion

        #region Methods

        public void InitMongoClient(string connectionString)
        {
            this.client = new MongoClient(connectionString);
            this.server = client.GetServer();
            this.database = server.GetDatabase("test");
        }
        public void GetCollectionsValues()
        {
            this.genderCollection = database.GetCollection<Gender>(GENDER_NAME_COLLECTION);
            this.productCollection = database.GetCollection<Product>(PRODUCT_NAME_COLLECTION);
        }
        public void queryOnProduct()
        {
            //var dataGender = genderCollection.GetCollection<Gender>();
            //var doc = dataGender.FindAllAs<Gender>(); // exception
            //List<Gender> dataGender = genderCollection.AsQueryable<Gender>().ToList();
            List<Product> dataProduct = productCollection.AsQueryable<Product>().ToList();
        }

        #endregion
    }
}
