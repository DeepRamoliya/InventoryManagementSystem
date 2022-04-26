using InventoryManagementSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace InventoryManagementSystem.Controllers
{
    public class ProductController : Controller
    {
        Inventory_ManagementEntities db = new Inventory_ManagementEntities();
        // GET: Product
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult DisplayProduct()
        {
            List<Product> list = db.Products.OrderByDescending(x => x.id).ToList();
            return View(list);
        }


        [HttpGet]
        public ActionResult CreateProduct()
        {
            return View();
        }
        [HttpPost]
        public ActionResult CreateProduct(Product pro)
        {
            db.Products.Add(pro);
            db.SaveChanges();
            return RedirectToAction("DisplayProduct");
        }

        [HttpGet]
        public ActionResult UpdateProduct(int id)
        {
            Product pr = db.Products.Where(x => x.id == id).SingleOrDefault();
            return View(pr);
        }
        [HttpPost]
        public ActionResult UpdateProduct(int id, Product pro)
        {
            Product pr = db.Products.Where(x => x.id == id).SingleOrDefault();
            pr.Product_Name = pro.Product_Name;
            pr.Product_Quntity = pro.Product_Quntity;
            db.SaveChanges();
            return RedirectToAction("DisplayProduct");

        }
        [HttpGet]
        public ActionResult ProductDetail(int id)
        {
            Product pro = db.Products.Where(x => x.id == id).SingleOrDefault();
            return View(pro);
        }
       
        public ActionResult DeleteProduct(int id)
        {
            Product pro = db.Products.Where(x => x.id == id).SingleOrDefault();
            return View(pro);
        }
        [HttpPost]
        public ActionResult DeleteProduct(int id,Product pro)
        {
            Product p = db.Products.Where(x => x.id == id).SingleOrDefault();
            db.Products.Remove(p);
            db.SaveChanges();
            return RedirectToAction("DisplayProduct");
        }


    }
}