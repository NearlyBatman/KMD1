using MongoDB.Driver;
using Microsoft.Extensions.Configuration;
using KMD1.Models;

namespace KMD1.CRUD
{
    public class MeetingCrud
    {
        private readonly IMongoCollection<ApplicationUser> meetings;

        public MeetingCrud(IConfiguration config)
        {
            MongoClient client = new MongoClient(config.GetConnectionString("MeetingDb"));
            IMongoDatabase database = client.GetDatabase("Users");
            meetings = database.GetCollection<ApplicationUser>("Users");
        }

        // Finder alle møder brugeren har og laver dem til en liste
        public List<Meeting> Get(string id)
        {
            var userId = Guid.Parse(id);
            var meetingList = meetings.Find(rec => rec.Id == userId).FirstOrDefault().meet;

            return meetingList;
        }

        // Tilføjer møder til brugeren
        public async Task AddMeeting(string id, Meeting meeting)
        {
            var userId = Guid.Parse(id);
            var filter = Builders<ApplicationUser>.Filter.Eq(x => x.Id, userId);

            var update = Builders<ApplicationUser>.Update.Push("meet", meeting);
            await meetings.FindOneAndUpdateAsync(filter, update);
        }

    }
}
