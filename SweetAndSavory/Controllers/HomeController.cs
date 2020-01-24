using Microsoft.AspNetCore.Mvc;
using SweetAndSavory.Models;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;


namespace SweetAndSavory.Controllers
{
  public class HomeController : Controller
  {
    [Route("/")]
    public ActionResult Index()
      { 
        return View(); 
      }
  }
}