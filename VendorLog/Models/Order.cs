using System;
using System.Collections.Generic;
using System.Globalization;

namespace VendorLog.Models
{
  public class Order
  {
    public string Title { get; set; }
    public string Description { get; set; }
    public double Price { get; set; }
    public int Id { get; }
    private DateTime _date;
    private static List<Order> _instances = new List<Order>();

    public Order( string title, string description, double price, string date)
    {
      Title = title;
      Description = description;
      Price = price;
      _date = DateTime.Parse(date);
      _instances.Add(this);
      Id = _instances.Count;
    }

    public string GetDate()
    {
      return _date.ToString("d", CultureInfo.CreateSpecificCulture("en-US"));
    }

    public static List<Order> GetAll()
    {
      return _instances;
    }

    public static void ClearAll()
    {
      _instances.Clear();
    }

    public static Order Find(int id)
    {
      return _instances[id - 1];
    }
  }
}