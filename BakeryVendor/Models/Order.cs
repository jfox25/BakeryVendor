using System;
using System.Collections.Generic;

namespace BakeryVendor.Models
{
  public class Order
  {
    private static List<Order> _orders = new List<Order>{};
    public Vendor Vendor { get; set; }
    public int Id { get; }
    public string Title { get; set; }
    public int Cost { get; set; }
    public DateTime DateCreated { get; set; }

    public Order(Vendor vendor, string title, int cost)
    {
      _orders.Add(this);
      Vendor = vendor;
      Id = _orders.Count;
      Title = title;
      Cost = cost;
      DateCreated = DateTime.Now;
    }

    public static List<Order> GetAll()
    {
      return _orders;
    }

    public static void ClearAll()
    {
      _orders.Clear();
    }
    public static Order Find(int searchId)
    {
      return _orders[searchId-1];
    }
  }
}