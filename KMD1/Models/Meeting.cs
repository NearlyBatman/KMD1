using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System.ComponentModel.DataAnnotations;

namespace KMD1.Models
{
    public class Meeting
    {
       // public Guid id;
       [BsonId]
       [BsonRepresentation(BsonType.ObjectId)]
       public string? Id { get; set; }
        [BsonElement("Name")]
        [Display(Name = "Name")]
        public string? name { get; set; }
        [BsonElement("Time")]
        [Display(Name = "Time")]
        public string? time { get; set; }
        [BsonElement("Location")]
        [Display(Name = "Location")]
        public string? location { get; set; }
       // public List<Participant> participants = new List<Participant>();
       public Meeting()
        {

        }
        public Meeting(string name, string time, string location)
        {
            this.name=name;
            this.time = time;
            this.location = location;
        }

        /*
        public Meeting(Guid id, string name, string time, string location, List<Participant> participants)
        {
            this.id = id;
            this.name = name;
            this.time = time;
            this.location = location;
            this.participants = participants;
        }
        */

    }
}
