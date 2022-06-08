using clouctech_wbl.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MFA_Login.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Authorize(clouctech_wbl.Models.tb_user userModel)
        {
            using (db_isEntities db = new db_isEntities())
            {
                var userDetails = db.tb_user.Where(x => x.u_id == userModel.u_id && x.u_pwd == userModel.u_pwd).FirstOrDefault();
                if (userDetails == null)
                {
                    userModel.LoginErrorMessage = "Wrong User ID or Password.";
                    return View("Index", userModel);
                }
                else
                {
                    Session["userID"] = userDetails.u_id;
                    Session["userName"] = userDetails.u_name;

                    if (userDetails.u_type == 1)
                        return RedirectToAction("Index", "Home");

                    else
                        return RedirectToAction("Index", "HomeEmployee");
                }
            }
        }
        public ActionResult LogOut()
        {
            string userID = (string)Session["userID"];
            Session.Abandon();
            return RedirectToAction("Index", "Login");
        }

    }
}