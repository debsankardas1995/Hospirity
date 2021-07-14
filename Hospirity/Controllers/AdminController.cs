using Hospirity.Helpers;
using Hospirity.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Hospirity.Controllers
{
    public class AdminController : Controller
    {
        DLayer dl = new DLayer();

        // GET: Admin
        public ActionResult Index()
        {
            return View();
        }

        #region Contact Us
        public ActionResult ContactUs()
        {
            List<ContactUs> CList = new List<ContactUs>();

            Property p = new Property();
            DataSet ds = new DataSet();

            p.OnTable = "FetchContactUs";

            ds = dl.FetchContactUs_sp(p);

            try
            {
                foreach (DataRow item in ds.Tables[0].Rows)
                {
                    ContactUs m = new ContactUs();

                    m.ContactId = item["ContactId"].ToString();
                    m.Name = item["Name"].ToString();
                    m.Email = item["Email"].ToString();
                    m.MobileNo = item["MobileNo"].ToString();
                    m.Message = item["Message"].ToString();
                    CList.Add(m);
                }
                ViewBag.ContactUsList = CList;
            }
            catch (Exception ex)
            {

            }
            return View();
        }
        public JsonResult DeleteContact(string id)
        {
            Property a = new Property();
            DataSet ds = new DataSet();
            a.Condition1 = id;
            a.OnTable = "DeleteContactUs";
            ds = dl.FetchContactUs_sp(a);
            return Json(1, JsonRequestBehavior.AllowGet);
        }
        #endregion

        #region About Us
        public ActionResult AboutUs()
        {
            List<AboutUs> AboutUsList = new List<AboutUs>();
            List<AboutUs2> AboutList = new List<AboutUs2>();

            Property p = new Property();
            DataSet ds = new DataSet();

            p.OnTable = "FetchAboutUs";

            ds = dl.FetchAboutus_sp(p);

            try
            {
                foreach (DataRow item in ds.Tables[0].Rows)
                {
                    AboutUs m = new AboutUs();

                    m.AboutId = item["AboutId"].ToString();
                    m.AboutTitle = item["AboutTitle"].ToString();
                    m.AboutDes = item["AboutDes"].ToString();
                    m.AboutImg = item["AboutImg"].ToString();
                    AboutUsList.Add(m);
                }
                ViewBag.AboutUsList = AboutUsList;
            }
            catch (Exception ex)
            {

            }

            try
            {
                foreach (DataRow item in ds.Tables[4].Rows)
                {
                    AboutUs2 m = new AboutUs2();

                    m.AboutId = item["AboutId"].ToString();
                    m.Title = item["Title"].ToString();
                    m.Des = item["Des"].ToString();
                    AboutList.Add(m);
                }
                ViewBag.AboutList = AboutList;
            }
            catch (Exception ex)
            {

            }

            //AboutUs1 info1 = new Hospirity.Models.AboutUs1();

            //try
            //{
            //    info1 = new Hospirity.Models.AboutUs1()
            //    {
            //        AboutId = ds.Tables[2].Rows[0]["AboutId"].ToString(),
            //        Title = ds.Tables[2].Rows[0]["Title"].ToString()
            //    };
            //}
            //catch(Exception ex)
            //{

            //}

            //ViewBag.AboutUs = info1;
            return View();
        }
        [ValidateInput(false)]
        [HttpPost]
        public ActionResult AboutUs(AboutUs c, List<HttpPostedFileBase> AboutImg)
        {
            string fileLocation = "";
            string ItemUploadFolderPath = "~/Content/Home/images/";

            try
            {
                try
                {
                    if (AboutImg.Count > 0)
                    {
                        foreach (HttpPostedFileBase file in AboutImg)
                        {
                            try
                            {
                                if (file.ContentLength == 0)
                                    continue;

                                if (file.ContentLength > 0)
                                {
                                    fileLocation = HelperFunctions.renameUploadFile(file, ItemUploadFolderPath);
                                    if (fileLocation == "")
                                    {
                                        fileLocation = "";
                                    }
                                }
                            }
                            catch (Exception ex)
                            {

                            }

                            if (fileLocation == "" || fileLocation == null)
                            {
                                c.AboutImg = c.AboutImg;
                            }
                            else
                            {
                                c.AboutImg = fileLocation;
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                }
            }
            catch (Exception ex)
            {

            }
            try
            {
                if (dl.InsertAboutus_Sp(c) > 0)
                {
                    TempData["CMSMSG1"] = "About Us Updated Successfully.";
                }
            }
            catch (Exception ex)
            {
                TempData["CMSMSG1"] = "Something went wrong.";
                return Redirect("/Admin/AboutUs");
            }
            
            return Redirect("/Admin/AboutUs");
        }
        [ValidateInput(false)]
        public ActionResult AboutUs1(AboutUs1 c)
        {
            try
            {
                if (dl.InsertAboutUs1_Sp(c) > 0)
                {
                    TempData["CMSMSG1"] = "About Us Updated Successfully.";
                }
            }
            catch (Exception ex)
            {
                TempData["CMSMSG1"] = "Something went wrong.";
                return Redirect("/Admin/AboutUs");
            }

            return Redirect("/Admin/AboutUs");
        }
        [ValidateInput(false)]
        public ActionResult AboutUs2(AboutUs2 c)
        {
            try
            {
                if (dl.InsertAboutUs2_Sp(c) > 0)
                {
                    TempData["CMSMSG1"] = "About Us Updated Successfully.";
                }
            }
            catch (Exception ex)
            {
                TempData["CMSMSG1"] = "Something went wrong.";
                return Redirect("/Admin/AboutUs");
            }

            return Redirect("/Admin/AboutUs");
        }
        public JsonResult getaboutus(string id)
        {
            Property p = new Property();
            DataSet ds = new DataSet();

            p.OnTable = "FetchAboutUs";

            if (id != null)
            {
                p.Condition1 = id;
            }

            ds = dl.FetchAboutus_sp(p);

            AboutUs info = new Hospirity.Models.AboutUs();

            try
            {
                info = new Hospirity.Models.AboutUs()
                {
                    AboutId = ds.Tables[1].Rows[0]["AboutId"].ToString(),
                    AboutTitle = ds.Tables[1].Rows[0]["AboutTitle"].ToString(),
                    AboutDes = ds.Tables[1].Rows[0]["AboutDes"].ToString(),
                    AboutImg = ds.Tables[1].Rows[0]["AboutImg"].ToString(),
                    IsActive = ds.Tables[1].Rows[0]["IsActive"].ToString()
                };
            }
            catch (Exception ex)
            {

            }
            return Json(info, JsonRequestBehavior.AllowGet);
        }
        public JsonResult getaboutus1(string id)
        {
            Property p = new Property();
            DataSet ds = new DataSet();

            p.OnTable = "FetchAboutUs";

            if (id != null)
            {
                p.Condition1 = id;
            }

            ds = dl.FetchAboutus_sp(p);

            AboutUs1 info = new Hospirity.Models.AboutUs1();

            try
            {
                info = new Hospirity.Models.AboutUs1()
                {
                    AboutId = ds.Tables[3].Rows[0]["AboutId"].ToString(),
                    Title = ds.Tables[3].Rows[0]["Title"].ToString(),
                    IsActive = ds.Tables[3].Rows[0]["IsActive"].ToString()
                };
            }
            catch (Exception ex)
            {

            }
            return Json(info, JsonRequestBehavior.AllowGet);
        }
        public JsonResult getaboutus2(string id)
        {
            Property p = new Property();
            DataSet ds = new DataSet();

            p.OnTable = "FetchAboutUs";

            if (id != null)
            {
                p.Condition1 = id;
            }

            ds = dl.FetchAboutus_sp(p);

            AboutUs2 info = new Hospirity.Models.AboutUs2();

            try
            {
                info = new Hospirity.Models.AboutUs2()
                {
                    AboutId = ds.Tables[5].Rows[0]["AboutId"].ToString(),
                    Title = ds.Tables[5].Rows[0]["Title"].ToString(),
                    Des = ds.Tables[5].Rows[0]["Des"].ToString(),
                    IsActive = ds.Tables[5].Rows[0]["IsActive"].ToString()
                };
            }
            catch (Exception ex)
            {

            }
            return Json(info, JsonRequestBehavior.AllowGet);
        }

      
        #endregion
    }
}