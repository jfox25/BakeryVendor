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
        return View(orders);
      }

      [HttpGet("/orders/new")]
      public ActionResult New()
      {
        List<Vendor> vendors = Vendor.GetAll();
        return View(vendors);
      }

      [HttpPost("/orders")]
      public ActionResult Create(int orderVendor, string orderTitle, string orderCost)
      {
        Vendor vendor = Vendor.Find(orderVendor);
        Order order = new Order(vendor, orderTitle, int.Parse(orderCost));
        return Redirect($"/vendors/{vendor.Id}");
      }

      [HttpGet("/orders/{id}")]
      public ActionResult Show(int id)
      {
        Order order = Order.Find(id);
        return View(order);
      }
    }
}