using MongoDB.Driver;
using Microsoft.Extensions.Configuration;
using KMD1.Models;

namespace KMD1.CRUD
{
    public class TestCrud
    {
        private readonly IMongoCollection<ApplicationUser> meetings;

        public TestCrud(IConfiguration config)
        {
            MongoClient client = new MongoClient(config.GetConnectionString("MeetingDb"));
            IMongoDatabase database = client.GetDatabase("Users");
            meetings = database.GetCollection<ApplicationUser>("Users");
        }

        public List<Meeting> Get(string id)
        {
            var kek = Guid.Parse(id);
            var test = meetings.Find(rec => rec.Id == kek).FirstOrDefault().meet;

            return test;
        }

        public Meeting Get(string id, string meetId)
        {
            var meh = Guid.Parse(id);
            var kek = Guid.Parse(meetId);
            var test = meetings.Find(rec => rec.Id == meh).FirstOrDefault().meet;
            foreach(var item in test)
            {
                if(item.Id == kek)
                {
                    return item;
                }
            }
            return null;

        }
        public Meeting Create(string id, Meeting meeting)
        {
            var userId = Guid.Parse(id);
            var test = meetings.Find(rec => rec.Id == userId).FirstOrDefault();
            test.meet.Add(meeting);

            return meeting;
        }
        public async Task Add(string id, Meeting meeting)
        {
            var userId = Guid.Parse(id);
            var filter = Builders<ApplicationUser>.Filter.Eq(x => x.Id, userId);

            var update = Builders<ApplicationUser>.Update.Push("meet", meeting);
            await meetings.FindOneAndUpdateAsync(filter, update);
        }
        /*
                public List<Meeting> Get(string id)
                {

                    return meetings.Find(user => user. == id).ToList();
                }

                public Meeting Create(Meeting meet)
                {
                    meetings.InsertOne(meet);
                    return meet;
                }
                */
    }
}
