using Microsoft.AspNetCore.Mvc;
using KMD1.Models;
using KMD1.CRUD;
using Microsoft.AspNetCore.Authorization;

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
        [Authorize]
        [HttpPost]
        public IActionResult AddMeeting()
        {
            return View();
        }
        public IActionResult ViewMeetings()
        {
            return View(tCrud.Get());
        }

        [HttpPost]
        public IActionResult NewMeeting(Meeting newMeet)
        {
            if (ModelState.IsValid)
            {
                tCrud.Create(newMeet);
                return RedirectToAction(nameof(Index));
            }
            return View("AddMeeting", newMeet);
        }
    }
}
