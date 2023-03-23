using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using Vote.Models;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity; //for UserManager and other tools
using System.Threading.Tasks; //for async methods
using System.Security.Claims; //for identifying a user through a "claim" (a claim states who a user is )


namespace Vote.Controllers
{
  [Authorize] // specifies what needs authorization
  public class ChoicesController : Controller
  {
    private readonly VoteContext _db;
    private readonly UserManager<ApplicationUser> _userManager;
    public ChoicesController(VoteContext db)
    {
      _db = db;
    }

    public async Task<ActionResult> Index() //probably change this for desired voting system
    {
      string userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value; //the ? is a "existential operator", only call the property after the ? if method to the left is not null
      ApplicationUser currentUser = await _userManager.FindByIdAsync(userId);
      List<Choice> userChoices = _db.Choices
                          .Where(entry => entry.User.Id == currentUser.Id) //where is a LINQ method echoing an SQL command
                          .Include(choice => choice.Topic)
                          .ToList();
      return View(userChoices);
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
      return View();

    }

    [HttpPost]
    public ActionResult Create(Choice Choice, int TopicId)
    {
      Choice.TopicId = TopicId;
      _db.Choices.Add(Choice);
      _db.SaveChanges();
      return RedirectToAction("Details", "Topics", new { id = Choice.TopicId });
    }



  }
}
