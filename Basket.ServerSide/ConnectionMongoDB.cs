using Basket.Common.Data;
using MongoDB.Driver;
using MongoDB.Driver.Linq;
using System.Collections.Generic;
using System.Linq;

namespace Basket.ServerSide
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
        public MongoCollection<GenderDTO> genderCollection { get; set; }
        public MongoCollection<ProductDTO> productCollection { get; set; }



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
            this.genderCollection = database.GetCollection<GenderDTO>(GENDER_NAME_COLLECTION);
            this.productCollection = database.GetCollection<ProductDTO>(PRODUCT_NAME_COLLECTION);
        }
        public void queryOnProduct()
        {
            //var dataGender = genderCollection.GetCollection<Gender>();
            //var doc = dataGender.FindAllAs<Gender>(); // exception
            List<GenderDTO> dataGender = genderCollection.AsQueryable<GenderDTO>().ToList();
            List<ProductDTO> dataProduct = productCollection.AsQueryable<ProductDTO>().ToList();
        }

        #endregion
    }
}
