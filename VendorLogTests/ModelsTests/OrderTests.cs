using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using VendorLog.Models;

namespace VendorLogTests
{
  [TestClass]
  public class OrderTests : IDisposable
  {
    public void Dispose()
    {
      Order.ClearAll();
    }

    [TestMethod]
    public void OrderConstructor_CreateOrderInstance_Order()
    {
      Order newOrder = new Order("Title", "Description", 1.99, "2020-12-25");
      Assert.AreEqual(typeof(Order), newOrder.GetType());
    }

    [TestMethod]
    public void OrderProperties_ReturnsProperties_True()
    {
      Order newOrder = new Order("Title", "Description", 1.99, "2020-12-25");
      Assert.AreEqual("Title", newOrder.Title);
      Assert.AreEqual("Description", newOrder.Description);
      Assert.AreEqual(1.99, newOrder.Price);
    }

    [TestMethod]
    public void GetDate_ReturnsDate_True()
    {
      Order newOrder = new Order("Title", "Description", 1.99, "2020-12-25");
      string response = newOrder.GetDate();
      Assert.AreEqual("12/25/2020", response);
    }

    [TestMethod]
    public void OrderProperties_ReassignProperties_True()
    {
      Order newOrder = new Order("Title", "Description", 1.99, "2020-12-25");
      newOrder.Title = "Order Three";
      newOrder.Description = "one dozen loafs of banana bread";
      newOrder.Price = 9.99;
      Assert.AreEqual("Order Three", newOrder.Title);
      Assert.AreEqual("one dozen loafs of banana bread", newOrder.Description);
      Assert.AreEqual(9.99, newOrder.Price);
    }

    [TestMethod]
    public void GetAll_ReturnEmptyList_List()
    {
      List<Order> emptyList = new List<Order>();
      List<Order> resultList = Order.GetAll();
      CollectionAssert.AreEqual(emptyList, resultList);
    }

    [TestMethod]
    public void GetAll_ReturnList_List()
    {
      Order orderOne = new Order("Title", "Description", 1.99, "2020-12-25");
      Order orderTwo = new Order("Order Two", "one dozen loafs of banana bread", 9.99, "2020-12-25");
      List<Order> newList = new List<Order>() { orderOne, orderTwo };
      List<Order> resultList = Order.GetAll();
      CollectionAssert.AreEqual(newList, resultList);
    }

    [TestMethod]
    public void Find_ReturnCorrectOrder_Order()
    {
      Order orderOne = new Order("Title", "Description", 1.99, "2020-12-25");
      Order orderTwo = new Order("Order Two", "one dozen loafs of banana bread", 9.99, "2020-12-25");
      Order foundOrder = Order.Find(2);
      Assert.AreEqual(orderTwo, foundOrder);
    }
  }
}