using Microsoft.AspNetCore.Mvc;
using BakeryVendor.Models;
using System.Collections.Generic;

namespace BakeryVendor.Controllers
{
    public class VendorController : Controller
    {
      [HttpGet("/vendors")]
      public ActionResult Index()
      {
        List<Vendor> vendors = Vendor.GetAll();
        return View(vendors);
      }

      [HttpGet("/vendors/new")]
      public ActionResult New()
      {
        return View();
      }

      [HttpPost("/vendors")]
      public ActionResult Create(string vendorName, string vendorDescription)
      {
        Vendor vendor = new Vendor(vendorName, vendorDescription);
        return RedirectToAction("Index");
      }

      [HttpGet("/vendors/{id}")]
      public ActionResult Show(int id)
      {
        Vendor vendor = Vendor.Find(id);
        return View(vendor);
      }
    }
}