using Microsoft.AspNetCore.Mvc;
using SweetAndSavory.Models;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace SweetAndSavory.Controllers
{
  public class FlavorsController : Controller
  {
    private readonly SweetAndSavoryContext _db;

    public FlavorsController(SweetAndSavoryContext db)
    {
      _db = db;
    }

    public ActionResult Index(string SearchFlavor)
    {
      List<Flavor> model = _db.Flavors.ToList();
      if(SearchFlavor!=null){
                model = _db.Flavors.Where(flavor => flavor.Name.Contains(SearchFlavor)).ToList();
            }
      return View(model);
    }

    public ActionResult Create()
    {
      return View();
    }

    [HttpPost]
    public ActionResult Create(Flavor flavor)f    {
      _db.Flavors.Add(flavor);
      _db.SaveChanges();
      return RedirectToAction("Index");
    }

    public ActionResult Details(int id)
    {
        var thisFlavor = _db.Flavors
            .Include(flavor => flavor.Treats)
            .ThenInclude(join => join.Treat)
            .FirstOrDefault(flavor => flavor.FlavorId == id);
        return View(thisFlavor);
    }

    public ActionResult Edit(int id)
    {
      var thisFlavor = _db.Flavors.FirstOrDefault(flavor => flavor.FlavorId == id);
      return View(thisFlavor);
    }

    [HttpPost]
    public ActionResult Edit(Flavor flavor)
    {
      _db.Entry(flavor).State = EntityState.Modified;
      _db.SaveChanges();
      return RedirectToAction("Index");
    }

    public ActionResult Delete(int id)
    {
      var thisFlavor = _db.Flavors.FirstOrDefault(flavor => flavor.FlavorId == id);
      return View(thisFlavor);
    }
    [HttpPost, ActionName("Delete")]
    public ActionResult DeleteConfirmed(int id)
    {
      var thisFlavor = _db.Flavors.FirstOrDefault(flavor => flavor.FlavorId == id);
      _db.Flavors.Remove(thisFlavor);
      _db.SaveChanges();
      return RedirectToAction("Index");
    }

    public ActionResult DeleteAll()
    {
      var allFlavors = _db.Flavors.ToList();
      return View();
    }

    [HttpPost, ActionName("DeleteAll")]
    public ActionResult DeleteAllConfirmed()
    {
      var allFlavors = _db.Flavors.ToList();

      foreach (var flavor in allFlavors)
      {
      _db.Flavors.Remove(flavor);
      }
      _db.SaveChanges();
      return RedirectToAction("Index");
    }
  }
}