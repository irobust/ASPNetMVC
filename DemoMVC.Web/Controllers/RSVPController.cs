using Microsoft.AspNetCore.Mvc;
using DemoMVC.Web.Models;

namespace DemoMVC.Web.Controllers
{
    public class RSVPController : Controller
    {
        [HttpGet]
        public IActionResult RSVPForm()
        {
            return View();
        }

        [HttpPost]
        public IActionResult RSVPForm(GuestResponse guestResponse)
        {
            if (ModelState.IsValid)
            {
                return View("Thanks", guestResponse);
            }
            return View();
            
        }
    }
}
