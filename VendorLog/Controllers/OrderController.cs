using Microsoft.AspNetCore.Mvc;
using VendorLog.Models;
using System;
using System.Collections.Generic;

namespace MusicOrganizer.Controllers
{
  public class OrderController : Controller
  {
    [HttpGet("/vendor/{vendorId}/order/new")]
    public ActionResult New(int vendorId)
    {
      Vendor foundVendor = Vendor.Find(vendorId);
      return View(foundVendor);
    }

    [HttpPost("/vendor/{routeId}/order")]
    public ActionResult Create(int routeId, int vendorId, string title, string description, double price, string date)
    {
      if (String.IsNullOrWhiteSpace(description))
      {
        description = "No Description Set";
      }

      if (!String.IsNullOrWhiteSpace(title) && !String.IsNullOrWhiteSpace(date))
      {
        Order newOrder = new Order(title, description, price, date);
        Vendor foundVendor = Vendor.Find(vendorId);
        foundVendor.AddOrder(newOrder);
      }

      return RedirectToAction("Index", "Vendor");
    }

    [HttpGet("/vendor/{vendorId}/order/{orderId}")]
    public ActionResult Show(int vendorId, int orderId)
    {
      Vendor foundVendor = Vendor.Find(vendorId);
      Order foundOrder = Order.Find(orderId);
      Dictionary<string, object> model = new Dictionary<string, object>();
      model.Add("vendor", foundVendor);
      model.Add("order", foundOrder);
      return View(model);
    }
  }
}