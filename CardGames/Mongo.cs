using CardGames.Properties;
using MongoDB.Driver;

namespace CardGames
{
    class Mongo
    {
        public MongoDatabase Database;
        public Mongo()
        {
            var client = new MongoClient(Settings.Default.MongoDBConn);
            var server = client.GetServer();
            Database = server.GetDatabase(Settings.Default.TexasHoldem);
        }
    }
}
