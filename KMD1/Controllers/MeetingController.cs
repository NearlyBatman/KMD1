using Microsoft.AspNetCore.Mvc;
using KMD1.Models;
using KMD1.CRUD;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;

namespace KMD1.Controllers
{
    public class MeetingController : Controller
    {
        private readonly MeetingCrud mCrud;
        //Mangler [Authorize], da jeg ikke kan få den til at fungere
        public MeetingController(MeetingCrud mCrud)
        {
            this.mCrud = mCrud;
        }
        public IActionResult Index()
        {
            return View();
        }
        
        [HttpPost]
        public IActionResult AddMeeting()
        {
            return View();
        }
        public IActionResult ViewMeetings()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            
            return View(mCrud.Get(userId));
        }

        [HttpPost]
        public async Task<IActionResult> NewMeeting(Meeting newMeet)
        {
            if(ModelState.IsValid)
            {

                if (newMeet.ParCheck(newMeet.Participants))
                {
                    newMeet.Id = Guid.NewGuid();
                    var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
                    await mCrud.AddMeeting(userId, newMeet);
                }
                else
                {
                    ViewBag.Message = "Participants must be between 0 and 100";
                }

            }
            return View("AddMeeting", newMeet);
        }

        [HttpPost]
        public IActionResult ViewMeetingRoom(IFormCollection form)
        {
            // En meget hacky løsning
            var meeting = new Meeting(form["name"], form["time"], form["location"], Int32.Parse(form["participants"]));
            meeting.Id = Guid.Parse(form["id"]);
            return View(meeting);
        }
    }
}
