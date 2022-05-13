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

    public Vendor(string name, string description)
    {
      _vendors.Add(this);
      Id = _vendors.Count;
      Name = name;
      Description = description;
      Orders = new List<Order>{};
    }

    public static void ClearAll()
    {
      _vendors.Clear();
    }

    public static List<Vendor> GetAll()
    {
      return _vendors;
    }

    public static Vendor Find(int searchId)
    {
      return _vendors[searchId-1];
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