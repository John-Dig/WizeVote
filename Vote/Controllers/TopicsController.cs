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

      public ActionResult Details(int id)
      {
        Topic thisTopic = _db.Topics
          .Include(Topic => Topic.Choices)
          .ThenInclude(User => User.JoinEntities)
          .ThenInclude(join => join.User)
          .FirstOrDefault(Topic => Topic.TopicId == id);
        return View(thisTopic);
      
      //       Category thisCategory = _db.Categories
      //                           .Include(cat => cat.Items)
      //                           .ThenInclude(item => item.JoinEntities)
      //                           .ThenInclude(join => join.Tag)
      //                           .FirstOrDefault(category => category.CategoryId == id);
      // return View(thisCategory);

      }
      
      [HttpPost]
      public ActionResult Details(int id, int value)
      {
        //  dynamc TestObj = new { TestId = value };
        return RedirectToAction("Result", value);
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