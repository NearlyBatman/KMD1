using Microsoft.AspNetCore.Mvc;
using KMD1.Models;
using KMD1.CRUD;


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
