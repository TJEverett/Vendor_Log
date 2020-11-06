using Microsoft.AspNetCore.Mvc;
using System;

namespace MusicOrganizer.Controllers
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