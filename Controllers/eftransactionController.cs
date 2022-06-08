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
    public class eftransactionController : Controller
    {
        private db_isEntities db = new db_isEntities();

        // GET: eftransaction
        public ActionResult Index()
        {
            var tb_transaction = db.tb_transaction.Include(t => t.tb_stock);
            return View(tb_transaction.ToList());
        }

        // GET: eftransaction/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tb_transaction tb_transaction = db.tb_transaction.Find(id);
            if (tb_transaction == null)
            {
                return HttpNotFound();
            }
            return View(tb_transaction);
        }

        // GET: eftransaction/Create
        public ActionResult Create()
        {
            ViewBag.s_id = new SelectList(db.tb_stock, "s_id", "s_name");
            return View();
        }

        // POST: eftransaction/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "t_id,s_id,t_qttyjual,t_topup,t_untung,t_tunaislot")] tb_transaction tb_transaction)
        {
            if (ModelState.IsValid)
            {
                db.tb_transaction.Add(tb_transaction);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.s_id = new SelectList(db.tb_stock, "s_id", "s_name", tb_transaction.s_id);
            return View(tb_transaction);
        }

        // GET: eftransaction/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tb_transaction tb_transaction = db.tb_transaction.Find(id);
            if (tb_transaction == null)
            {
                return HttpNotFound();
            }
            ViewBag.s_id = new SelectList(db.tb_stock, "s_id", "s_name", tb_transaction.s_id);
            return View(tb_transaction);
        }

        // POST: eftransaction/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "t_id,s_id,t_qttyjual,t_topup,t_untung,t_tunaislot")] tb_transaction tb_transaction)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tb_transaction).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.s_id = new SelectList(db.tb_stock, "s_id", "s_name", tb_transaction.s_id);
            return View(tb_transaction);
        }

        // GET: eftransaction/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tb_transaction tb_transaction = db.tb_transaction.Find(id);
            if (tb_transaction == null)
            {
                return HttpNotFound();
            }
            return View(tb_transaction);
        }

        // POST: eftransaction/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tb_transaction tb_transaction = db.tb_transaction.Find(id);
            db.tb_transaction.Remove(tb_transaction);
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
