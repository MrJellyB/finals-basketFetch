﻿using Basket.Common.Data;
using MongoDB.Driver;
using MongoDB.Driver.Linq;
using System.Collections.Generic;
using System.Linq;
using System;

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
        public const string STORE_NAME_COLLECTION = "store";

        #endregion

        #region C'Tors

        public ConnectionMongoDB()
        {
        }

        #endregion

        #region Properties
        private static readonly Random getrandom = new Random();
        public MongoClient client { get; set; }
        public MongoServer server { get; set; }
        public MongoDatabase database { get; set; }
        public MongoCollection<GenderDTO> genderCollection { get; set; }
        public MongoCollection<ProductDTO> productCollection { get; set; }

        public MongoCollection<CategoryDTO> categoryCollection { get; set; }

        public MongoCollection<BasketDTO> basketCollection { get; set; }

        public MongoCollection<CityDTO> cityCollection { get; set; }

        public MongoCollection<UserDTO> userCollection { get; set; }

        public MongoCollection<StoreDTO> storeCollection { get; set; }

        public List<ProductDTO> Products { get; set; }

        public List<StoreDTO> Stores { get; set; }


        #endregion

        #region Methods

        public void InitMongoClient(string connectionString)
        {
            this.client = new MongoClient(connectionString);
            this.server = client.GetServer();
            this.database = server.GetDatabase("test");

            // define the collections
            this.GetCollectionsValues();

            // get collection values
            this.GetData();
        }
        public void GetCollectionsValues()
        {
            this.genderCollection = database.GetCollection<GenderDTO>(GENDER_NAME_COLLECTION);
            this.productCollection = database.GetCollection<ProductDTO>(PRODUCT_NAME_COLLECTION);
            this.categoryCollection = database.GetCollection<CategoryDTO>(CATEGORY_NAME_COLLECTION);
            this.basketCollection = database.GetCollection<BasketDTO>(BASKET_NAME_COLLECTION);
            this.cityCollection = database.GetCollection<CityDTO>(CITY_NAME_COLLECTION);
            this.userCollection = database.GetCollection<UserDTO>(USERS_NAME_COLLECTION);
            this.storeCollection = database.GetCollection<StoreDTO>(STORE_NAME_COLLECTION);
        }

        public void GetData()
        {
            if (this.Products == null)
            {
                this.Products = this.GetAllProductDTO();
            }

            if(this.Stores == null)
            {
                this.Stores = this.GetAllStores();
            }
        }
        public void queryOnProduct()
        {
            List<GenderDTO> dataGender = genderCollection.AsQueryable<GenderDTO>().ToList();
            List<ProductDTO> dataProduct = productCollection.AsQueryable<ProductDTO>().ToList();
        }

        public ProductDTO GetProductByIdFromList(long p_lProductId)
        {
            return this.Products.Where(x => x.id == p_lProductId).FirstOrDefault();
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

        public List<StoreDTO> GetAllStores()
        {
            List<StoreDTO> data = storeCollection.AsQueryable<StoreDTO>().ToList();
            return data;
        }


        public List<BasketDTO> GenerateRandomBasket(int p_nNumberOfBasket, int p_nFromNumberOfProduct, int p_nToNumberOfProducts)
        {
            List<BasketDTO> basketList = new List<BasketDTO>();
            float fTotalPrice = 0;
            for (int nIndex = 0; nIndex < p_nNumberOfBasket; nIndex++)
            {
                fTotalPrice = 0;
                BasketDTO basket = new BasketDTO();
                basket.basketItems = new List<BasketItemsDTO>();
                basket.id = 0;

                int nCountOfProducts = this.GetRandomNumber(p_nFromNumberOfProduct, p_nToNumberOfProducts);

                for (int jIndex = 0; jIndex < nCountOfProducts; jIndex++)
                {
                    int nProductIndex = this.GetRandomNumber(0, this.Products.Count - 1);
                    ProductDTO currProduct = this.Products[nProductIndex];
                    BasketItemsDTO item = new BasketItemsDTO();
                    item.id = currProduct.id;
                    item.image = "";
                    item.name = currProduct.name;
                    item.price = currProduct.price;
                    item.amount = this.GetRandomNumber(1, 3);
                    fTotalPrice = fTotalPrice + (item.price * item.amount);
                    basket.basketItems.Add(item);
                }

                basket.totalPrice = fTotalPrice;
                StoreDTO store = this.Stores[this.GetRandomNumber(0, this.Stores.Count - 1)];
                basket.streetName = store.Address + " " + store.City;

                basketList.Add(basket);
            }

            return basketList;
        }

        public int GetRandomNumber(int min, int max)
        {
            lock (getrandom) // synchronize
            {
                return getrandom.Next(min, max);
            }
        }

        #endregion
    }
}
