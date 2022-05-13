using Microsoft.AspNetCore.Mvc;
using BakeryVendor.Models;
using System;
using System.Collections.Generic;

namespace BakeryVendor.Controllers
{
    public class OrderController : Controller
    {
      [HttpGet("/orders")]
      public ActionResult Index()
      {
        List<Order> orders = Order.GetAll();
        ViewBag.vendors = Vendor.GetAll();
        ViewBag.VendorId = 0;
        return View(orders);
      }
      [HttpPost("/orders/filter")]
      public ActionResult FilterOrders(int vendorId)
      {
        if(vendorId == 0)
        {
          return RedirectToAction("Index");
        }
        List<Order> orders = Order.FilterOrders(vendorId);
        ViewBag.vendors = Vendor.GetAll();
        ViewBag.VendorId = vendorId;
        return View("Index", orders);
      }

      [HttpGet("/orders/new/{id}")]
      public ActionResult New(int id)
      {
        List<Vendor> vendors = Vendor.GetAll();
        ViewBag.VendorId = id;
        return View(vendors);
      }

      [HttpPost("/orders")]
      public ActionResult Create(int orderVendor, string orderTitle, string orderCost, string returnToVendor = "false")
      {
        Vendor vendor = Vendor.Find(orderVendor);
        Order order = new Order(vendor, orderTitle, int.Parse(orderCost));
        if(returnToVendor == "true")
        {
          return Redirect($"/vendors/{vendor.Id}");
        }
        return RedirectToAction("Index");
      }

      [HttpGet("/orders/show/{id}")]
      public ActionResult Show(int id)
      {
        Order order = Order.Find(id);
        return View(order);
      }

      [HttpPost("/orders/update/{id}")]
      public ActionResult Update(int id)
      {
        Order order = Order.Find(id);
        order.IsPaid = true;
        return Redirect($"/orders/show/{order.Id}");
      }
    }
}