using Microsoft.VisualStudio.TestTools.UnitTesting;
using BakeryVendor.Models;
using System.Collections.Generic;
using System;

namespace BakeryVendor.Tests
{
  [TestClass]
  public class VendorTests : IDisposable
  {
    public void Dispose()
    {
      Vendor.ClearAll();
    }

    [TestMethod]
    public void VendorConstructor_CreatesInstanceOfAVendor_Vendor()
    {
      Vendor vendor = new Vendor("James", "Aerospace");
      Assert.AreEqual(typeof(Vendor), vendor.GetType());
    }
    [TestMethod]
    public void VendorConstructor_CreatesIdCorrectly_int()
    {
      Vendor vendor = new Vendor("James", "Aerospace");
      Vendor vendor2 = new Vendor("Jake", "State Farm");
      Assert.AreEqual(2, vendor2.Id);
      Assert.AreEqual(1, vendor.Id);
    }
    [TestMethod]
    public void VendorConstructor_UpdatesVendorList_int()
    {
      Vendor vendor = new Vendor("James", "Aerospace");
      Vendor vendor2 = new Vendor("Jake", "State Farm");
      Vendor vendor3 = new Vendor("Darth Vader", "Space Stuff");
      List<Vendor> vendorList = Vendor.GetAll();
      Assert.AreEqual(3, vendorList.Count);
    }
    [TestMethod]
    public void CalculateTotalCost_ReturnesTotalCostOfOrders_int()
    {
      Vendor vendor = new Vendor("James", "Aerospace");
      Order order = new Order(vendor, "Order#1", 250);
      Order order2 = new Order(vendor, "Order#2", 275);
      int totalCost = vendor.CalculateTotalCost();
      Assert.AreEqual(525, totalCost);
    }
  }
}