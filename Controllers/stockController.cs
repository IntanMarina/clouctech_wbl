using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using clouctech_wbl.Models;

namespace cloudtech.Controllers
{
    public class stockController : Controller
    {
        private db_isEntities db = new db_isEntities();

        // GET: stock
        public ActionResult Index()
        {
            return View(db.tb_stock.ToList());
        }

        // GET: stock/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tb_stock tb_stock = db.tb_stock.Find(id);
            if (tb_stock == null)
            {
                return HttpNotFound();
            }
            return View(tb_stock);
        }

        // GET: stock/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: stock/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "s_id,s_name,s_qtty,s_modal,s_hargatin,s_vending,s_untungtin")] tb_stock tb_stock)
        {
            if (ModelState.IsValid)
            {
                db.tb_stock.Add(tb_stock);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tb_stock);
        }

        // GET: stock/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tb_stock tb_stock = db.tb_stock.Find(id);
            if (tb_stock == null)
            {
                return HttpNotFound();
            }
            return View(tb_stock);
        }

        // POST: stock/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "s_id,s_name,s_qtty,s_modal,s_hargatin,s_vending,s_untungtin")] tb_stock tb_stock)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tb_stock).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tb_stock);
        }

        // GET: stock/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tb_stock tb_stock = db.tb_stock.Find(id);
            if (tb_stock == null)
            {
                return HttpNotFound();
            }
            return View(tb_stock);
        }

        // POST: stock/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tb_stock tb_stock = db.tb_stock.Find(id);
            db.tb_stock.Remove(tb_stock);
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

        [HttpPost]
        public ActionResult getUntungtin()
        {
            db.Configuration.ProxyCreationEnabled = false;
            var car = db.tb_stock.ToList();
            return Json(car, JsonRequestBehavior.AllowGet);
        }
    }
}
