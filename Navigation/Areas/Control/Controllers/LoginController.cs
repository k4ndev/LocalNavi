﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;
using Navigation.DAL;
using Navigation.Models;

namespace Navigation.Areas.Control.Controllers
{
    public class LoginController : Controller
    {
        private  readonly  NaviContext db = new NaviContext();
        // GET: Control/Login
        public ActionResult Index()
        {

            return View();
        }

        public ActionResult Login(Admin admin)
        {
            if (string.IsNullOrEmpty(admin.Email) || string.IsNullOrEmpty(admin.Password))
            {
                Session["LoginError"] = "Xananı boş buraxmayın";
                return RedirectToAction("Index");
            }

            Admin adm = db.Admins.FirstOrDefault(x => x.Email == admin.Email);

            if (adm != null)
            {
                if (Crypto.VerifyHashedPassword(adm.Password, admin.Password))
                {
                    Session["admin"] = true;
                    return RedirectToAction("Index", "Dashboard");
                }
            }


            Session["LoginError"] = "Email və ya şifrə səhvdir";
            return RedirectToAction("Index");

            
        }
        public ActionResult Logout()
        {
            Session["admin"] = null;
            return RedirectToAction("Index", "Login");
        }
    }
}