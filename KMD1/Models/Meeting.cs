using MongoDB.Bson;
//using MongoDB.Bson.Serialization.Attributes;
using System.ComponentModel.DataAnnotations;

namespace KMD1.Models
{
    public class Meeting
    {
       public Guid? Id { get; set; }
        [Required(ErrorMessage = "Name of meeting is required")]
        public string? Name { get; set; }
        [Required(ErrorMessage = "A set time is required")]
        public string? Time { get; set; }
        [Required(ErrorMessage = "Name of a location is required")]
        public string? Location { get; set; }
        public int Participants { get; set; }
       public Meeting()
        {

        }

        public Meeting(string name, string time, string location, int participants)
        {
            this.Name=name;
            this.Time = time;
            this.Location = location;
            this.Participants = participants;
        }

        public bool ParCheck(int par)
        {
            if (Enumerable.Range(0, 100).Contains(par))
            {
                return true;
            }
            return false;
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
