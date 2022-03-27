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
        private readonly TestCrud tCrud;

        public MeetingController(TestCrud tCrud)
        {
            this.tCrud = tCrud;
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
            var test = User.FindFirstValue(ClaimTypes.NameIdentifier);
            
            return View(tCrud.Get(test));
        }

        [HttpPost]
        public IActionResult NewMeetings(Meeting newMeet)
        {
            //newMeet.
            if (ModelState.IsValid)
            {
                //tCrud.Create(newMeet);
                return RedirectToAction(nameof(Index));
            }

            return View("AddMeeting", newMeet);
        }
        /*
        [HttpPost]
        public IActionResult NewMeetingss(Meeting newMeet)
        {
            if (ModelState.IsValid)
            {
                newMeet.Id = Guid.NewGuid();
                var test = User.FindFirstValue(ClaimTypes.NameIdentifier);
                tCrud.Create(test, newMeet);
                return RedirectToAction(nameof(Index));
            }
            return View(newMeet);
        }
        */
        [HttpPost]
        public async Task<IActionResult> NewMeeting(Meeting newMeet)
        {
            if(ModelState.IsValid)
            {

                if (newMeet.ParCheck(newMeet.Participants))
                {
                    newMeet.Id = Guid.NewGuid();
                    var test = User.FindFirstValue(ClaimTypes.NameIdentifier);
                    await tCrud.Add(test, newMeet);
                }
                else
                {
                    ViewBag.Message = "Participants must be between 0 and 100";
                }

            }
            return View("AddMeeting", newMeet);
        }

        [HttpPost]
        public IActionResult ViewMeetingRoom(Meeting meeting)
        {
            return View(meeting);
        }
    }
}
