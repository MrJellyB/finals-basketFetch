using System;
using System.Collections.Generic;
using Basket.Common.Data;

namespace Basket.ServerSide
{
    class Program
    {
        static void Main(string[] args)
        {
            ConnectionMongoDB db = new ConnectionMongoDB();
            db.InitMongoClient(ConnectionMongoDB.URL);
            List<GenderDTO> genders = db.GetAllGenders();
            ProductDTO currProduct2 = db.GetProductDTOByProductId(25675120020);
            ProductDTO currProduct = db.GetProductDTOByProductId(34000196173);
            List<ProductDTO> products = db.GetAllProductDTO();
            List<CategoryDTO> category = db.GetAllCategoriesDTO();
            List<BasketDTO> baskets = db.GetAllBasketsDTO();
            List<CityDTO> cities = db.GetAllCitiesDTO();
        }
    }
}
