﻿using Hospirity.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Hospirity.Controllers
{
    public class AdminLoginController : Controller
    {
        DLayer dl = new DLayer();

        // GET: AdminLogin
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Index(AdminLogin a)
        {

            Property p = new Property();
            DataSet ds = new DataSet();

            p.Condition3 = a.Email;
            p.Condition4 = a.Password;

            p.OnTable = "Checklogin";

            ds = dl.FetchAdminLogin_sp(p);

            try
            {
                if (ds.Tables[0].Rows.Count > 0)
                {
                    HttpCookie HospirityCookie = Request.Cookies["HospirityAdmin"];

                    String Status = ds.Tables[0].Rows[0]["IsActive"].ToString();

                    if (Status == "True")
                    {
                        HospirityCookie = new HttpCookie("HospirityAdmin");
                        HospirityCookie["AdminId"] = ds.Tables[0].Rows[0]["AdminId"].ToString();


                        HospirityCookie.Expires = DateTime.Now.AddDays(1);
                        Response.Cookies.Add(HospirityCookie);
                        return RedirectToAction("Index", "Admin");
                    }

                    else
                    {
                        TempData["MSGlogin"] = "Email-id / Password is incorrect";
                    }
                }
                else
                {
                    TempData["MSGlogin"] = "Email-id / Password is incorrect";
                }
            }
            catch (Exception ex)
            {
                TempData["MSGlogin"] = "Email-id / Password is incorrect or account not active!";
            }

            TempData["MSGlogin"] = "Email-id / Password is incorrect or account not active!";

            return RedirectToAction("Index", "AdminLogin");
        }
        public ActionResult Logout()
        {
            Session.Abandon();
            Session.Clear();

            HttpCookie HospirityCookie = Request.Cookies["HospirityAdmin"];

            if (HospirityCookie != null)
            {
                HospirityCookie.Expires = DateTime.Now.AddDays(-1);
                Response.Cookies.Add(HospirityCookie);
            }
            Response.Cache.SetCacheability(HttpCacheability.NoCache);
            Response.Cache.SetExpires(DateTime.UtcNow.AddHours(-1));
            Response.Cache.SetNoStore();
            return Redirect("/AdminLogin");
        }
    }
}