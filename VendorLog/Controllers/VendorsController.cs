using Microsoft.AspNetCore.Mvc;
using VendorLog.Models;
using System;
using System.Collections.Generic;

namespace MusicOrganizer.Controllers
{
  public class VendorsController : Controller
  {
    [HttpGet("/vendors")]
    public ActionResult Index()
    {
      List<Vendor> vendorList = Vendor.GetAll();
      return View(vendorList);
    }

    [HttpGet("/vendors/new")]
    public ActionResult New()
    {
      return View();
    }

    [HttpPost("/vendors")]
    public ActionResult Create(string name, string description)
    {
      if (String.IsNullOrWhiteSpace(description))
      {
        description = "No Description Set";
      }

      if (!(String.IsNullOrWhiteSpace(name)))
      {
        Vendor newVendor = new Vendor(name, description);
      }

      return RedirectToAction("Index");
    }

    [HttpGet("/vendors/{id}")]
    public ActionResult Show(int id)
    {
      Vendor foundVendor = Vendor.Find(id);
      return View(foundVendor);
    }
  }
}