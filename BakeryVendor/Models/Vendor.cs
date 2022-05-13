using System.Collections.Generic;
namespace BakeryVendor.Models
{
  public class Vendor
  {
    private static List<Vendor> _vendors = new List<Vendor>{};
    public int Id { get;}
    public string Name { get; set; }
    public string Description { get; set; }
    public List<Order> Orders { get; set; }

    private static int _idCount = 0;
    public Vendor(string name, string description)
    {
      _idCount++;
      _vendors.Add(this);
      Id = _idCount;
      Name = name;
      Description = description;
      Orders = new List<Order>{};
    }

    public static void ClearAll()
    {
      _vendors.Clear();
      _idCount = 0;
    }

    public static List<Vendor> GetAll()
    {
      return _vendors;
    }

    public static Vendor Find(int searchId)
    {
      foreach (Vendor vendor in _vendors)
      {
        if(vendor.Id == searchId)
        {
          return vendor;
        }
      }
      return null;
    }
    public static void RemoveVendor(Vendor vendor)
    {
      _vendors.Remove(vendor);
      foreach (Order order in vendor.Orders)
      {
        Order.RemoveOrder(order);
      }
    }
    public void AddOrder(Order order)
    {
      Orders.Add(order);
    }
    
    public int CalculateTotalCost()
    {
      int total = 0;
      foreach (Order order in Orders)
      {
        total += order.Cost;
      }
      return total;
    }
  }
}