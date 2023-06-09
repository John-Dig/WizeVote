using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using Vote.Models;
using System.Collections.Generic;
using System.Linq;
using System;

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

    // public ActionResult Details(int id)
    // {
    //   ViewBag.UserId = new SelectList(_db.Users, "UserId", "Name");
    //   Topic thisTopic = _db.Topics
    //     .Include(Topic => Topic.Choices)
    //     .ThenInclude(choice => choice.UserVotes)
    //     .FirstOrDefault(Topic => Topic.TopicId == id);
    //   return View(thisTopic);
    // }

    // [HttpPost]
    // public ActionResult Details(int ChoiceId, int UserId)
    // {
    //   User user = _db.Users
    //     .FirstOrDefault(user => user.UserId == UserId);
    //      Choice choice = _db.Choices
    //     .Include(choice => choice.UserVotes)
    //     .FirstOrDefault(Choice => Choice.ChoiceId == ChoiceId);
    //   choice.UserVotes.Add(user);
    //   _db.SaveChanges();
    //   return RedirectToAction("Details");
    // }

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