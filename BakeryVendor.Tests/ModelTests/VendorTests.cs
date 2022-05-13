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
  }
}