using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Admin.Data;
using Admin.Model.Models;

namespace Admin.Web.Areas.Administrator.Controllers
{
    public class ProductRangesController : Controller
    {
        private AdminDbContext db = new AdminDbContext();

        // GET: Administrator/ProductRanges
        public ActionResult Index()
        {
            var productRanges = db.ProductRanges.Include(p => p.Product);
            return View(productRanges.ToList());
        }

        // GET: Administrator/ProductRanges/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProductRange productRange = db.ProductRanges.Find(id);
            if (productRange == null)
            {
                return HttpNotFound();
            }
            return View(productRange);
        }

        // GET: Administrator/ProductRanges/Create
        public ActionResult Create()
        {
            ViewBag.ProductID = new SelectList(db.Products, "ID", "Name");
            return View();
        }

        // POST: Administrator/ProductRanges/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,ParcelID,ProductID,Code,IsSell,IsWarranty,Warranty,ProduceDate,Description,Quantity,CreatedDate,CreatedBy,UpdatedDate,UpdatedBy")] ProductRange productRange)
        {
            if (ModelState.IsValid)
            {
                db.ProductRanges.Add(productRange);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ProductID = new SelectList(db.Products, "ID", "Name", productRange.ProductID);
            return View(productRange);
        }

        // GET: Administrator/ProductRanges/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProductRange productRange = db.ProductRanges.Find(id);
            if (productRange == null)
            {
                return HttpNotFound();
            }
            ViewBag.ProductID = new SelectList(db.Products, "ID", "Name", productRange.ProductID);
            return View(productRange);
        }

        // POST: Administrator/ProductRanges/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,ParcelID,ProductID,Code,IsSell,IsWarranty,Warranty,ProduceDate,Description,Quantity,CreatedDate,CreatedBy,UpdatedDate,UpdatedBy")] ProductRange productRange)
        {
            if (ModelState.IsValid)
            {
                db.Entry(productRange).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ProductID = new SelectList(db.Products, "ID", "Name", productRange.ProductID);
            return View(productRange);
        }

        // GET: Administrator/ProductRanges/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProductRange productRange = db.ProductRanges.Find(id);
            if (productRange == null)
            {
                return HttpNotFound();
            }
            return View(productRange);
        }

        // POST: Administrator/ProductRanges/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ProductRange productRange = db.ProductRanges.Find(id);
            db.ProductRanges.Remove(productRange);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
