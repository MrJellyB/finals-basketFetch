using System;

namespace Basket.ServerSide
{
    class Program
    {
        static void Main(string[] args)
        {
            ConnectionMongoDB db = new ConnectionMongoDB();
            db.InitMongoClient(ConnectionMongoDB.URL);
            db.GetCollectionsValues();
            db.queryOnProduct();
        }
    }
}
