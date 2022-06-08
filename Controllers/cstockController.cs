using clouctech_wbl.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace projectwbl.Controllers
{
    public class cstockController : Controller
    {

        db_isEntities db = new db_isEntities();
        // GET: cStock
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Save([Bind(Include = "s_name,s_qtty,s_modal,s_hargatin,s_vending,s_untungtin")] tb_stock stock)
        {
            if (ModelState.IsValid)
            {
                db.tb_stock.Add(stock);
                db.SaveChanges();
                return RedirectToAction("Index", "stock/Index");
            }
            return View(stock);
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