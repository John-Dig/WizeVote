using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using Vote.Models;
using System.Collections.Generic;
using System.Linq;

namespace Vote.Controllers
{
    public class ChoicesController : Controller
    {
      private readonly VoteContext _db;

      public ChoicesController(VoteContext db)
      {
        _db = db;
      }

      public ActionResult Index()
      {
        List<Choice> Choices = _db.Choices
          .ToList();
        return View(Choices);
      }

      public ActionResult Details(int id)
      {
        Choice thisChoice = _db.Choices
          .FirstOrDefault(Choice => Choice.ChoiceId == id);
        return View(thisChoice);
      }

      public ActionResult Create(int id)
      {
        ViewBag.TopicIdFromBag = id;

    //   Tag thisTag = _db.Tags.FirstOrDefault(tags => tags.TagId == id);
    //   ViewBag.ItemId = new SelectList(_db.Items, "ItemId", "Description");
      return View(TopicId);

      }

      [HttpPost]
      public ActionResult Create(Choice Choice)
      {
        _db.Choices.Add(Choice);
        _db.SaveChanges();
        return RedirectToAction("Index");
      }

      

    }
}