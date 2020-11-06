using Microsoft.AspNetCore.Mvc;
using VendorLog.Models;
using System;
using System.Collections.Generic;

namespace MusicOrganizer.Controllers
{
  public class VendorController : Controller
  {
    [HttpGet("/vendor")]
    public ActionResult Index()
    {
      List<Vendor> vendorList = Vendor.GetAll();
      return View();
    }

    [HttpGet("/vendor/new")]
    public ActionResult New()
    {
      return View();
    }
  }
}