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

        // private const string URL = "mongodb://localhost";
        // private const string URL = "mongodb://localhost:27017";
        public const string URL = "mongodb://11:22@193.106.55.172:8888/test";
        public const string PRODUCT_NAME_COLLECTION = "product";
        public const string GENDER_NAME_COLLECTION = "gender";
        public const string CATEGORY_NAME_COLLECTION = "category";
        public const string BASKET_NAME_COLLECTION = "basket";
        public const string CITY_NAME_COLLECTION = "city";
        public const string USERS_NAME_COLLECTION = "users";

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

        public MongoCollection<CategoryDTO> categoryCollection { get; set; }

        public MongoCollection<BasketDTO> basketCollection { get; set; }

        public MongoCollection<CityDTO> cityCollection { get; set; }

        public MongoCollection<UserDTO> userCollection { get; set; }

        #endregion

        #region Methods

        public void InitMongoClient(string connectionString)
        {
            this.client = new MongoClient(connectionString);
            this.server = client.GetServer();
            this.database = server.GetDatabase("test");

            // define the collections
            this.GetCollectionsValues();
        }
        public void GetCollectionsValues()
        {
            this.genderCollection = database.GetCollection<GenderDTO>(GENDER_NAME_COLLECTION);
            this.productCollection = database.GetCollection<ProductDTO>(PRODUCT_NAME_COLLECTION);
            this.categoryCollection = database.GetCollection<CategoryDTO>(CATEGORY_NAME_COLLECTION);
            this.basketCollection = database.GetCollection<BasketDTO>(BASKET_NAME_COLLECTION);
            this.cityCollection = database.GetCollection<CityDTO>(CITY_NAME_COLLECTION);
            this.userCollection = database.GetCollection<UserDTO>(USERS_NAME_COLLECTION);
        }
        public void queryOnProduct()
        {
            List<GenderDTO> dataGender = genderCollection.AsQueryable<GenderDTO>().ToList();
            List<ProductDTO> dataProduct = productCollection.AsQueryable<ProductDTO>().ToList();
        }

        public List<ProductDTO> GetAllProductDTO()
        {
            List<ProductDTO> dataProduct = productCollection.AsQueryable<ProductDTO>().ToList();
            return dataProduct;
        }
        public ProductDTO GetProductDTOByProductId(long p_productId)
        {
            ProductDTO dataProduct = productCollection.AsQueryable<ProductDTO>().Where(x => x.id == p_productId).FirstOrDefault();
            return dataProduct;
        }

        public List<GenderDTO> GetAllGenders()
        {
            List<GenderDTO> data = genderCollection.AsQueryable<GenderDTO>().ToList();
            return data;
        }

        public GenderDTO GetGenderDTOByProductId(long p_genderId)
        {
            GenderDTO dataProduct = genderCollection.AsQueryable<GenderDTO>().Where(x => x.id == p_genderId).FirstOrDefault();
            return dataProduct;
        }

        public CategoryDTO GetCategoryDTOById(long p_category)
        {
            CategoryDTO category = categoryCollection.AsQueryable<CategoryDTO>().Where(x => x.id == p_category).FirstOrDefault();
            return category;
        }

        public List<CategoryDTO> GetAllCategoriesDTO()
        {
            List<CategoryDTO> data = categoryCollection.AsQueryable<CategoryDTO>().ToList();
            return data;
        }

        public List<BasketDTO> GetAllBasketsDTO()
        {
            List<BasketDTO> data = basketCollection.AsQueryable<BasketDTO>().ToList();
            return data;
        }
        public List<CityDTO> GetAllCitiesDTO()
        {
            List<CityDTO> data = cityCollection.AsQueryable<CityDTO>().ToList();
            return data;
        }

        public List<UserDTO> GetAllUsersDTO()
        {
            List<UserDTO> data = userCollection.AsQueryable<UserDTO>().ToList();
            return data;
        }

        public UserDTO GetUserDTOByUserName(string strUserName)
        {
            UserDTO data = userCollection.AsQueryable<UserDTO>().Where(x => x.userName == strUserName).FirstOrDefault();
            return data;
        }

        #endregion
    }
}
