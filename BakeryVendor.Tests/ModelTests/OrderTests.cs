using Microsoft.VisualStudio.TestTools.UnitTesting;
using BakeryVendor.Models;
using System.Collections.Generic;
using System;

namespace BakeryVendor.Tests
{
  [TestClass]
  public class OrderTests : IDisposable
  {
    public void Dispose()
    {
      Order.ClearAll();
    }

    [TestMethod]
    public void OrderConstructor_CreatesInstanceOfAnOrder_Order()
    {
      Vendor vendor = new Vendor("James", "Website");
      Order order = new Order(vendor, "Order#1", 250);
      Assert.AreEqual(typeof(Order), order.GetType());
    }
    [TestMethod]
    public void OrderConstructor_CreatesIdCorrectly_int()
    {
      Vendor vendor = new Vendor("James", "Aerospace");
      Order order = new Order(vendor, "Order#1", 250);
      Order order2 = new Order(vendor, "Order#2", 275);
      Assert.AreEqual(2, order2.Id);
      Assert.AreEqual(1, order.Id);
    }
  }
}