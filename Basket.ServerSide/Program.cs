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
            List<ProductDTO> products = db.GetAllProductDTO();
            ProductDTO currProduct = db.GetProductDTOByProductId(34000196173);
            List<CategoryDTO> category = db.GetAllCategoriesDTO();
        }
    }
}
