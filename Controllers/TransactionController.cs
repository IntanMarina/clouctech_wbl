using clouctech_wbl.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace cloudtech.Controllers
{

    public class TransactionController : Controller
    {
        db_isEntities db = new db_isEntities();
        // GET: Transaction
        public ActionResult Index()
        {
            return View();
        }


        [HttpPost]
        public ActionResult Save([Bind(Include = "s_id,t_qttyjual,t_topup,t_untung,t_tunaislot")] tb_transaction transaction)
        {
            if (ModelState.IsValid)
            {
                db.tb_transaction.Add(transaction);
                db.SaveChanges();
                return RedirectToAction("Index", "eftransaction/Index");
            }
            return View(transaction);

        }

        [HttpGet]
        public ActionResult getstock()
        {
            db.Configuration.ProxyCreationEnabled = false;
            var car = db.tb_stock.ToList();
            return Json(car, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult getsid(string id)
        {
            db.Configuration.ProxyCreationEnabled = false;
            var customer = (from s in db.tb_stock where s.s_name == id select s.s_id).ToList();
            return Json(customer, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult getprofit(int id)
        {
            db.Configuration.ProxyCreationEnabled = false;
            var customer = (from s in db.tb_stock where s.s_id == id select s.s_untungtin).ToList();
            return Json(customer, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult gettunaislot(int id)
        {
            db.Configuration.ProxyCreationEnabled = false;
            var customer = (from s in db.tb_stock where s.s_id == id select s.s_hargatin).ToList();
            return Json(customer, JsonRequestBehavior.AllowGet);
        }
    }
}