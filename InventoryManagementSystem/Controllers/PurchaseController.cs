using InventoryManagementSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace InventoryManagementSystem.Controllers
{
    public class PurchaseController : Controller
    {
        Inventory_ManagementEntities db = new Inventory_ManagementEntities();
        // GET: Purchase
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult DisplayPurchase()
        {
            List<Purchase> list = db.Purchases.OrderByDescending(x => x.id).ToList();
            return View(list);
        }

        public ActionResult PurchaseProduct()
        {
            List<string> list = db.Products.Select(x => x.Product_Name).ToList();
            ViewBag.ProductName = new SelectList(list);
            return View();
        }
        [HttpPost]
        public ActionResult PurchaseProduct(Purchase pur)
        {
            db.Purchases.Add(pur);
            db.SaveChanges();
            return RedirectToAction("DisplayPurchase");
        }


        public ActionResult Edit(int id)
        {
            Purchase p = db.Purchases.Where(x => x.id == id).SingleOrDefault();
            List<string> list = db.Products.Select(x => x.Product_Name).ToList();
            ViewBag.ProductName = new SelectList(list);
            return View(p);
        }

            [HttpPost]
        public ActionResult Edit(int id,Purchase pur)
        {
            Purchase p = db.Purchases.Where(x => x.id == id).SingleOrDefault();
            p.Purchase_date = pur.Purchase_date;
            p.Purchase_Product = pur.Purchase_Product;
            p.Purchase_Quntity = pur.Purchase_Quntity;
            db.SaveChanges();
            return RedirectToAction("DisplayPurchase");
        }
        public ActionResult PurchaseDetail(int id)
        {
            Purchase pro = db.Purchases.Where(x => x.id == id).SingleOrDefault();
            return View(pro);
        }

        public ActionResult Delete(int id)
        {
            Purchase pro = db.Purchases.Where(x => x.id == id).SingleOrDefault();
            return View(pro);
        }
        [HttpPost]
        public ActionResult Delete(int id, Purchase pur)
        {
            Purchase p = db.Purchases.Where(x => x.id == id).SingleOrDefault();
            db.Purchases.Remove(p);
            db.SaveChanges();
            return RedirectToAction("DisplayPurchase");
        }

    }
}