using Microsoft.AspNetCore.Mvc;
using MvcDataViews.Models;

namespace MvcDataViews.Controllers
{
    public class PersonController : Controller
    {
        static List<Person> people = new List<Person>();
        public IActionResult Index()
        {
            return View(people);
        }
    }
}
