using InventoryManagementSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace InventoryManagementSystem.Controllers
{
    public class SaleController : Controller
    {
        // GET: Sale
        Inventory_ManagementEntities db = new Inventory_ManagementEntities();
        // GET: Purchase
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult DisplaySale()
        {
            List<Sale> list = db.Sales.OrderByDescending(x => x.id).ToList();
            return View(list);
        }

        public ActionResult SaleProduct()
        {
            List<string> list = db.Products.Select(x => x.Product_Name).ToList();
            ViewBag.ProductName = new SelectList(list);
            return View();
        }
        [HttpPost]
        public ActionResult SaleProduct(Sale S)
        {
            db.Sales.Add(S);
            db.SaveChanges();
            return RedirectToAction("DisplaySale");
        }


        public ActionResult Edit(int id)
        {
            Sale p = db.Sales.Where(x => x.id == id).SingleOrDefault();
            List<string> list = db.Products.Select(x => x.Product_Name).ToList();
            ViewBag.ProductName = new SelectList(list);
            return View(p);
        }

        [HttpPost]
        public ActionResult Edit(int id, Sale S)
        {
            Sale sale = db.Sales.Where(x => x.id == id).SingleOrDefault();
            sale.Sale_date = S.Sale_date;
            sale.Sale_Product = S.Sale_Product;
            sale.Sale_Quntity = S.Sale_Quntity;
            db.SaveChanges();
            return RedirectToAction("DisplaySale");
        }
        public ActionResult SaleDetail(int id)
        {
            Sale sale = db.Sales.Where(x => x.id == id).SingleOrDefault();
            return View(sale);
        }

        public ActionResult Delete(int id)
        {
            Sale sale= db.Sales.Where(x => x.id == id).SingleOrDefault();
            return View(sale);
        }
        [HttpPost]
        public ActionResult Delete(int id, Sale S)
        {
            Sale sale = db.Sales.Where(x => x.id == id).SingleOrDefault();
            db.Sales.Remove(sale);
            db.SaveChanges();
            return RedirectToAction("DisplaySale");
        }
    }
}