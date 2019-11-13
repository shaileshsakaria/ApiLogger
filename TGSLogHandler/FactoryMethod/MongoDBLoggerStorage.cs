using System.Configuration;
using MongoDB.Driver;
using MongoDB.Bson;
using TGSLogHandler.ViewModel;

namespace TGSLogHandler.FactoryMethod
{
    public class MongoDBLoggerStorage : ILoggerStorage
    {
        IMongoDatabase db;
        public MongoDBLoggerStorage()
        {
            string LoggerConnectionString = ConfigurationManager.AppSettings["LoggerConnectionString"];
            string ConnectionString = ConfigurationManager.ConnectionStrings[LoggerConnectionString].ToString();
            string DatabaseName = ConfigurationManager.AppSettings["MongoDBName"];

            var client = new MongoClient(ConnectionString);
            db = client.GetDatabase(DatabaseName);
        }

        public void LoggerDetail(ApiLoggerVM model)
        {
            string LoggerApplicationName = ConfigurationManager.AppSettings["LoggerApplicationName"];
            var collection = db.GetCollection<BsonDocument>("ApiLogger");
            BsonDocument logDetails = new BsonDocument
                {
                    { "application" , new BsonString(LoggerApplicationName??string.Empty) },
                    { "applicaionUser" , new BsonString(model.applicaionUser??string.Empty) },
                    { "machine" , new BsonString(model.machine??string.Empty) },
                    { "requestIpAddress" , new BsonString(model.requestIpAddress??string.Empty) },
                    { "requestTimestamp" , new BsonDateTime(model.requestTimestamp ?? BsonNull.Value.ToUniversalTime()) },
                    { "requestContentType" , new BsonString(model.requestContentType??string.Empty) },
                    { "requestContentBody" , new BsonString(model.requestContentBody??string.Empty) },
                    { "requestUri" , new BsonString(model.requestUri??string.Empty) },
                    { "requestMethod" , new BsonString(model.requestMethod??string.Empty) },
                    { "requestHeaders" , new BsonString(model.requestHeaders??string.Empty) },
                    { "responseTimestamp" , new BsonDateTime(model.responseTimestamp ?? BsonNull.Value.ToUniversalTime()) },
                    { "responseContentType" , new BsonString(model.responseContentType??string.Empty) },
                    { "responseContentBody" , new BsonString(model.responseContentBody??string.Empty) },
                    { "responseStatusCode" , new BsonInt32(model.responseStatusCode??0) },
                    { "responseHeaders" , new BsonString(model.responseHeaders??string.Empty) },
                };
            collection.InsertOne(logDetails);

        }
    }
}
