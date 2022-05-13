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
      Assert.AreEqual(1, order.Id);
      Assert.AreEqual(2, order2.Id);
    }
    [TestMethod]
    public void FilterOrders_returnesCorrectOrdersForVendor_Orders()
    {
      Vendor vendor = new Vendor("James", "Aerospace");
      Order order = new Order(vendor, "Order#1", 250);
      Order order2 = new Order(vendor, "Order#2", 275);
      Vendor vendor2 = new Vendor("Jake", "Statefarm");
      Order order3 = new Order(vendor2, "Order#3", 150);
      Order order4 = new Order(vendor2, "Order#4", 175);
      List<Order> filteredOrders = Order.FilterOrders(vendor2.Id);
      Assert.AreEqual(2, filteredOrders.Count);
    }
    [TestMethod]
    public void Find_ReturnesCorrectOrder_Order()
    {
      Vendor vendor = new Vendor("James", "Aerospace");
      Order order = new Order(vendor, "Order#1", 250);
      Order order2 = new Order(vendor, "Order#2", 275);
      Order order3 = new Order(vendor, "Order#3", 150);
      Order foundOrder = Order.Find(order2.Id);
      Assert.AreEqual("Order#2", foundOrder.Title);
    }
    [TestMethod]
    public void RemoveOrder_RemovesTheCorrectOrder_Order()
    {
      Vendor vendor = new Vendor("James", "Aerospace");
      Order order = new Order(vendor, "Order#1", 250);
      Order order2 = new Order(vendor, "Order#2", 275);
      Order order3 = new Order(vendor, "Order#3", 150);
      Order.RemoveOrder(order2);
      List<Order> orders = Order.GetAll();
      Assert.AreEqual(2, orders.Count);
    }
  }
}