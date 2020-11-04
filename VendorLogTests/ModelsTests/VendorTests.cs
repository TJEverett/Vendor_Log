using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using VendorLog.Models;

namespace VendorLogTests
{
  [TestClass]
  public class VendorTests : IDisposable
  {
    public void Dispose()
    {
      Vendor.ClearAll();
    }

    [TestMethod]
    public void VendorConstructor_CreateVendorInstance_Vendor()
    {
      Vendor newVendor = new Vendor("Name", "Description");
      Assert.AreEqual(typeof(Vendor), newVendor.GetType());
    }

    [TestMethod]
    public void VendorProperties_ReturnsProperties_True()
    {
      Vendor newVendor = new Vendor("Name", "Description");
      Assert.AreEqual("Name", newVendor.Name);
      Assert.AreEqual("Description", newVendor.Description);
    }

    [TestMethod]
    public void VendorProperties_SetProperties_True()
    {
      Vendor newVendor = new Vendor("Name", "Description");
      newVendor.Name = "Walmart";
      newVendor.Description = "site A";
      Assert.AreEqual("Walmart", newVendor.Name);
      Assert.AreEqual("site A", newVendor.Description);
    }

    [TestMethod]
    public void GetAll_ReturnEmptyList_List()
    {
      List<Vendor> emptyList = new List<Vendor>();
      List<Vendor> returnList = Vendor.GetAll();
      CollectionAssert.AreEqual(emptyList, returnList);
    }

    [TestMethod]
    public void GetAll_ReturnList_List()
    {
      Vendor vendorOne = new Vendor("Name", "Description");
      Vendor vendorTwo = new Vendor("Walmart", "site A");
      List<Vendor> newList = new List<Vendor>() { vendorOne, vendorTwo };
      List<Vendor> returnList = Vendor.GetAll();
      CollectionAssert.AreEqual(newList, returnList);
    }

    [TestMethod]
    public void Find_ReturnRightVendor_Vendor()
    {
      Vendor vendorOne = new Vendor("Name", "Description");
      Vendor vendorTwo = new Vendor("Walmart", "site A");
      Vendor foundVendor = Vendor.Find(1);
      Assert.AreEqual(vendorOne, foundVendor);
    }

    [TestMethod]
    public void AddOrder_AddsOrderToVendor_True()
    {
      Order newOrder = new Order("Order Two", "one dozen loafs of banana bread", 9.99, "2020-12-25");
      Vendor newVendor = new Vendor("Walmart", "site A");
      newVendor.AddOrder(newOrder);
      List<Order> newList = new List<Order>() { newOrder };
      CollectionAssert.AreEqual(newList, newVendor.Orders);
    }
  }
}