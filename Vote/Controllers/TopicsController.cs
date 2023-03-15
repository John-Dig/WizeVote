using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using Vote.Models;
using System.Collections.Generic;
using System.Linq;

namespace Vote.Controllers
{
    public class TopicsController : Controller
    {
      private readonly VoteContext _db;

      public TopicsController(VoteContext db)
      {
        _db = db;
      }

      public ActionResult Index()
      {
        List<Topic> topics = _db.Topics
          .Include(topic => topic.Choices)
          .ToList();
        return View(topics);
      }

      public ActionResult Details()
      {
        return View();
      }

      public ActionResult Create()
      {
        return View();
      }

      [HttpPost]
      public ActionResult Create(Topic Topic)
      {
        _db.Topics.Add(Topic);
        _db.SaveChanges();
        return RedirectToAction("Index");
      }

      

    }
}