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

namespace ServerSide
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
