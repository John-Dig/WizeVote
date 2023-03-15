using Microsoft.AspNetCore.Mvc;

namespace Vote.Controllers
{
    public class HomeController : Controller
    {

      [HttpGet("/")]
      public ActionResult Index()
      {
        return View();
      }

    }
}