using MongoDB.Driver;
using Microsoft.Extensions.Configuration;
using KMD1.Models;

namespace KMD1.CRUD
{
    public class TestCrud
    {
        private readonly IMongoCollection<Meeting> meetings;

        public TestCrud(IConfiguration config)
        {
            MongoClient client = new MongoClient(config.GetConnectionString("MeetingDb"));
            IMongoDatabase database = client.GetDatabase("MeetingDb");
            meetings = database.GetCollection<Meeting>("Meetings");
        }

        public List<Meeting> Get()
        {
            return meetings.Find(rec => true).ToList();
        }

        public Meeting Create(Meeting meet)
        {
            meetings.InsertOne(meet);
            return meet;
        }
    }
}
