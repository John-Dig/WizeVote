using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using Vote.Models;
using System.Collections.Generic;
using System.Linq;

namespace Vote.Controllers
{
    public class UsersController : Controller
    {

      private readonly VoteContext _db;

      public UsersController(VoteContext db)
      {
        _db = db;
      }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(User inputUser)
        {
            _db.Users.Add(inputUser);
            _db.SaveChanges();
            return RedirectToAction("Index","Home");
        }

    }
}