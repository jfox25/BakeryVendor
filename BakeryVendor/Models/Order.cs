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
    public bool IsPaid { get; set; }
    private static int _idCount = 0;

    public Order(Vendor vendor, string title, int cost)
    {
      _idCount++;
      _orders.Add(this);
      vendor.Orders.Add(this);
      Vendor = vendor;
      Id = _idCount;
      Title = title;
      Cost = cost;
      DateCreated = DateTime.Now;
      IsPaid = false;
    }

    public static List<Order> GetAll()
    {
      return _orders;
    }

    public static void RemoveOrder(Order order)
    {
      _orders.Remove(order);
    }

    public static void ClearAll()
    {
      _idCount = 0;
      _orders.Clear();
    }
    public static Order Find(int searchId)
    {
      foreach (Order order in _orders)
      {
        if(order.Id == searchId)
        {
          return order;
        }
      }
      return null;
    }
  }
}