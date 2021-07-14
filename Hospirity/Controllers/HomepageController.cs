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
    public class HomepageController : Controller
    {
        DLayer dl = new DLayer();

        // GET: Homepage
        public ActionResult Index()
        {
            return View();
        }
        #region Banner Images
        public ActionResult Banner()
        {
            List<BannerImage> BannerList = new List<BannerImage>();

            Property p = new Property();
            DataSet ds = new DataSet();

            p.OnTable = "FetchBannerImg";

            ds = dl.FetchBannerImg_sp(p);

            try
            {
                foreach (DataRow item in ds.Tables[0].Rows)
                {
                    BannerImage m = new BannerImage();

                    m.BannerId = item["BannerId"].ToString();
                    m.BannerImg = item["BannerImg"].ToString();
                    m.BannerTitle = item["BannerTitle"].ToString();
                    m.BannerDes = item["BannerDes"].ToString();
                    m.IsActive = item["IsActive"].ToString();
                    BannerList.Add(m);
                }
                ViewBag.BannerList = BannerList;
            }
            catch (Exception ex)
            {

            }
            return View();
        }

        [HttpPost]
        public ActionResult AddBanner(BannerImage c, List<HttpPostedFileBase> BannerImg)
        {
            string fileLocation = "";
            string ItemUploadFolderPath = "~/Content/Home/images/";

            try
            {
                try
                {
                    if (BannerImg.Count > 0)
                    {
                        foreach (HttpPostedFileBase file in BannerImg)
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
                                c.BannerImg = c.BannerImg;
                            }
                            else
                            {
                                c.BannerImg = fileLocation;
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
                if (dl.InsertBannerImg_Sp(c) > 0)
                {
                    TempData["CMSMSG1"] = "Banner Imaged Saved Successfully.";
                }
            }
            catch (Exception ex)
            {
                TempData["CMSMSG1"] = "Something went wrong.";
                return Redirect("/Homepage/Banner");
            }

            //TempData["CMSMSG1"] = "Image Saved Successfully.";
            return Redirect("/Homepage/Banner");
        }
        public JsonResult BannerStatus(string id, string status)
        {
            Property a = new Property();
            DataSet ds = new DataSet();
            if (status == "True")
            {
                a.Condition1 = "False";
            }
            else
            {
                a.Condition1 = "True";
            }
            a.Condition2 = id;
            a.OnTable = "ChangeBannerStatus";
            ds = dl.FetchBannerImg_sp(a);
            return Json(1, JsonRequestBehavior.AllowGet);
        }
        public JsonResult DeleteBanner(string id)
        {
            Property a = new Property();
            DataSet ds = new DataSet();
            a.Condition1 = id;
            a.OnTable = "DeleteBanner";
            ds = dl.FetchBannerImg_sp(a);
            return Json(1, JsonRequestBehavior.AllowGet);
        }
        public JsonResult getbanner(string id)
        {
            Property p = new Property();
            DataSet ds = new DataSet();

            p.OnTable = "FetchBannerImg";

            if (id != null)
            {
                p.Condition1 = id;
            }

            ds = dl.FetchBannerImg_sp(p);

            BannerImage info = new Hospirity.Models.BannerImage();

            try
            {
                info = new Hospirity.Models.BannerImage()
                {
                    BannerId = ds.Tables[1].Rows[0]["BannerId"].ToString(),
                    BannerTitle = ds.Tables[1].Rows[0]["BannerTitle"].ToString(),
                    BannerDes = ds.Tables[1].Rows[0]["BannerDes"].ToString(),
                    BannerImg = ds.Tables[1].Rows[0]["BannerImg"].ToString(),
                    IsActive = ds.Tables[1].Rows[0]["IsActive"].ToString()
                };
            }
            catch (Exception ex)
            {

            }
            return Json(info, JsonRequestBehavior.AllowGet);
        }
        #endregion

        #region Company Profile
        public ActionResult CompanyProfile()
        {
            Property p = new Property();
            DataSet ds = new DataSet();

            p.OnTable = "FetchCompanyProfile";

            ds = dl.FetchCompanyProfile_sp(p);

            CompanyProfile info = new Hospirity.Models.CompanyProfile();

            try
            {
                info = new Hospirity.Models.CompanyProfile()
                {
                    CId = ds.Tables[0].Rows[0]["CId"].ToString(),
                    Vision = ds.Tables[0].Rows[0]["Vision"].ToString(),
                    CValues = ds.Tables[0].Rows[0]["CValues"].ToString(),
                    Mission = ds.Tables[0].Rows[0]["Mission"].ToString()
                };
            }
            catch (Exception ex)
            {

            }
            return View(info);
        }
        [HttpPost]
        public ActionResult CompanyProfile(CompanyProfile c)
        {
            try
            {
                if (dl.InsertCompanyProfile_Sp(c) > 0)
                {
                    TempData["CompanyProfileMsg"] = "Company Profile Updated Successfully.";
                }
            }
            catch (Exception ex)
            {
                TempData["CompanyProfileMsg"] = "Something went wrong.";
                return Redirect("/Homepage/CompanyProfile");
            }
            return Redirect("/Homepage/CompanyProfile");
        }
        #endregion

        #region SERVICES
        public ActionResult Services()
        {
            List<Services> ServicesList = new List<Services>();

            Property p = new Property();
            DataSet ds = new DataSet();

            p.OnTable = "FetchServices";

            ds = dl.FetchServices_sp(p);

            try
            {
                foreach (DataRow item in ds.Tables[0].Rows)
                {
                    Services m = new Services();

                    m.ServicesId = item["ServicesId"].ToString();
                    m.Title = item["Title"].ToString();
                    m.SubTitle = item["SubTitle"].ToString();
                    m.Img = item["Img"].ToString();
                    m.IsActive = item["IsActive"].ToString();
                    ServicesList.Add(m);
                }
                ViewBag.ServiceList = ServicesList;
            }
            catch (Exception ex)
            {

            }
            return View();
        }
        [HttpPost]
        public ActionResult Services(Services c, List<HttpPostedFileBase> Img)
        {
            string fileLocation = "";
            string ItemUploadFolderPath = "~/Content/Home/images/";

            try
            {
                try
                {
                    if (Img.Count > 0)
                    {
                        foreach (HttpPostedFileBase file in Img)
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
                                c.Img = c.Img;
                            }
                            else
                            {
                                c.Img = fileLocation;
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
                if (dl.InsertServices_Sp(c) > 0)
                {
                    TempData["ServiceMsg"] = "Services Added Successfully.";
                }
            }
            catch (Exception ex)
            {
                TempData["ServiceMsg"] = "Something went wrong.";
                return Redirect("/Homepage/Services");
            }

            return Redirect("/Homepage/Services");
        }
        public JsonResult ServiceStatus(string id, string status)
        {
            Property a = new Property();
            DataSet ds = new DataSet();
            if (status == "True")
            {
                a.Condition1 = "False";
            }
            else
            {
                a.Condition1 = "True";
            }
            a.Condition2 = id;
            a.OnTable = "ChangeServiceStatus";
            ds = dl.FetchServices_sp(a);
            return Json(1, JsonRequestBehavior.AllowGet);
        }
        public JsonResult DeleteServices(string id)
        {
            Property a = new Property();
            DataSet ds = new DataSet();
            a.Condition1 = id;
            a.OnTable = "DeleteService";
            ds = dl.FetchServices_sp(a);
            return Json(1, JsonRequestBehavior.AllowGet);
        }
        public JsonResult getservices(string id)
        {
            Property p = new Property();
            DataSet ds = new DataSet();

            p.OnTable = "FetchServices";

            if (id != null)
            {
                p.Condition1 = id;
            }

            ds = dl.FetchServices_sp(p);

            Services info = new Hospirity.Models.Services();

            try
            {
                info = new Hospirity.Models.Services()
                {
                    ServicesId = ds.Tables[1].Rows[0]["ServicesId"].ToString(),
                    Title = ds.Tables[1].Rows[0]["Title"].ToString(),
                    SubTitle = ds.Tables[1].Rows[0]["SubTitle"].ToString(),
                    Img = ds.Tables[1].Rows[0]["Img"].ToString(),
                    IsActive = ds.Tables[1].Rows[0]["IsActive"].ToString()
                };
            }
            catch (Exception ex)
            {

            }
            return Json(info, JsonRequestBehavior.AllowGet);
        }
        #endregion

        #region Testimonial
        public ActionResult Testimonial()
        {
            List<Testimonial> TestimonialList = new List<Testimonial>();

            Property p = new Property();
            DataSet ds = new DataSet();

            p.OnTable = "FetchTestimonials";

            ds = dl.FetchTestimonial_sp(p);

            try
            {
                foreach (DataRow item in ds.Tables[0].Rows)
                {
                    Testimonial m = new Testimonial();

                    m.TestimonialId = item["TestimonialId"].ToString();
                    m.CName = item["CName"].ToString();
                    m.CDesignation = item["CDesignation"].ToString();
                    m.Testimonials = item["Testimonials"].ToString();
                    m.CImg = item["CImg"].ToString();
                    m.IsActive = item["IsActive"].ToString();
                    TestimonialList.Add(m);
                }
                ViewBag.TestimonialList = TestimonialList;
            }
            catch (Exception ex)
            {

            }
            return View();
        }
        [HttpPost]
        public ActionResult Testimonial(Testimonial c, List<HttpPostedFileBase> CImg)
        {
            string fileLocation = "";
            string ItemUploadFolderPath = "~/Content/Home/images/";

            try
            {
                try
                {
                    if (CImg.Count > 0)
                    {
                        foreach (HttpPostedFileBase file in CImg)
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
                                c.CImg = c.CImg;
                            }
                            else
                            {
                                c.CImg = fileLocation;
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
                if (dl.InsertTestimonial_Sp(c) > 0)
                {
                    TempData["TestimonialMsg"] = "Testimonial Added Successfully.";
                }
            }
            catch (Exception ex)
            {
                TempData["TestimonialMsg"] = "Something went wrong.";
                return Redirect("/Homepage/Testimonial");
            }

            return Redirect("/Homepage/Testimonial");
        }
        public JsonResult TestimonialStatus(string id, string status)
        {
            Property a = new Property();
            DataSet ds = new DataSet();
            if (status == "True")
            {
                a.Condition1 = "False";
            }
            else
            {
                a.Condition1 = "True";
            }
            a.Condition2 = id;
            a.OnTable = "ChangeTestimonialsStatus";
            ds = dl.FetchTestimonial_sp(a);
            return Json(1, JsonRequestBehavior.AllowGet);
        }
        public JsonResult DeleteTestimonial(string id)
        {
            Property a = new Property();
            DataSet ds = new DataSet();
            a.Condition1 = id;
            a.OnTable = "DeleteTestimonials";
            ds = dl.FetchTestimonial_sp(a);
            return Json(1, JsonRequestBehavior.AllowGet);
        }
        public JsonResult gettestimonial(string id)
        {
            Property p = new Property();
            DataSet ds = new DataSet();

            p.OnTable = "FetchTestimonials";

            if (id != null)
            {
                p.Condition1 = id;
            }

            ds = dl.FetchTestimonial_sp(p);

            Testimonial info = new Hospirity.Models.Testimonial();

            try
            {
                info = new Hospirity.Models.Testimonial()
                {
                    TestimonialId = ds.Tables[1].Rows[0]["TestimonialId"].ToString(),
                    CName = ds.Tables[1].Rows[0]["CName"].ToString(),
                    CDesignation = ds.Tables[1].Rows[0]["CDesignation"].ToString(),
                    Testimonials = ds.Tables[1].Rows[0]["Testimonials"].ToString(),
                    CImg = ds.Tables[1].Rows[0]["CImg"].ToString(),
                    IsActive = ds.Tables[1].Rows[0]["IsActive"].ToString()
                };
            }
            catch (Exception ex)
            {

            }
            return Json(info, JsonRequestBehavior.AllowGet);
        }
        #endregion

        #region Blog
        public ActionResult Blog()
        {
            List<Blog> BlogList = new List<Blog>();

            Property p = new Property();
            DataSet ds = new DataSet();

            p.OnTable = "FetchBlog";

            ds = dl.FetchBlog_sp(p);

            try
            {
                foreach (DataRow item in ds.Tables[0].Rows)
                {
                    Blog m = new Blog();

                    m.BlogId = item["BlogId"].ToString();
                    m.BlogTitle = item["BlogTitle"].ToString();
                    m.BlogDescription = item["BlogDescription"].ToString();
                    m.BlogImg = item["BlogImg"].ToString();
                    m.IsActive = item["IsActive"].ToString();
                    BlogList.Add(m);
                }
                ViewBag.BlogList = BlogList;
            }
            catch (Exception ex)
            {

            }
            return View();
        }
        [ValidateInput(false)]
        [HttpPost]
        public ActionResult Blog(Blog c, List<HttpPostedFileBase> BlogImg)
        {
            string fileLocation = "";
            string ItemUploadFolderPath = "~/Content/Home/images/";

            try
            {
                try
                {
                    if (BlogImg.Count > 0)
                    {
                        foreach (HttpPostedFileBase file in BlogImg)
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
                                c.BlogImg = c.BlogImg;
                            }
                            else
                            {
                                c.BlogImg = fileLocation;
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
                if (dl.InsertBlog_Sp(c) > 0)
                {
                    TempData["BlogMsg"] = "Blog Added Successfully.";
                }
            }
            catch (Exception ex)
            {
                TempData["BlogMsg"] = "Something went wrong.";
                return Redirect("/Homepage/Blog");
            }

            return Redirect("/Homepage/Blog");
        }
        public JsonResult BlogStatus(string id, string status)
        {
            Property a = new Property();
            DataSet ds = new DataSet();
            if (status == "True")
            {
                a.Condition1 = "False";
            }
            else
            {
                a.Condition1 = "True";
            }
            a.Condition2 = id;
            a.OnTable = "ChangeBlogStatus";
            ds = dl.FetchBlog_sp(a);
            return Json(1, JsonRequestBehavior.AllowGet);
        }
        public JsonResult DeleteBlog(string id)
        {
            Property a = new Property();
            DataSet ds = new DataSet();
            a.Condition1 = id;
            a.OnTable = "DeleteBlog";
            ds = dl.FetchBlog_sp(a);
            return Json(1, JsonRequestBehavior.AllowGet);
        }
        public JsonResult getblog(string id)
        {
            Property p = new Property();
            DataSet ds = new DataSet();

            p.OnTable = "FetchBlog";

            if (id != null)
            {
                p.Condition1 = id;
            }

            ds = dl.FetchBlog_sp(p);

            Blog info = new Hospirity.Models.Blog();

            try
            {
                info = new Hospirity.Models.Blog()
                {
                    BlogId = ds.Tables[1].Rows[0]["BlogId"].ToString(),
                    BlogTitle = ds.Tables[1].Rows[0]["BlogTitle"].ToString(),
                    SmallDescription = ds.Tables[1].Rows[0]["SmallDescription"].ToString(),
                    BlogDescription = ds.Tables[1].Rows[0]["BlogDescription"].ToString(),
                    BlogImg = ds.Tables[1].Rows[0]["BlogImg"].ToString(),
                    IsActive = ds.Tables[1].Rows[0]["IsActive"].ToString()
                };
            }
            catch (Exception ex)
            {

            }
            return Json(info, JsonRequestBehavior.AllowGet);
        }
        #endregion

        #region Career
        public ActionResult Career()
        {
            List<Career> CareerList = new List<Career>();

            Property p = new Property();
            DataSet ds = new DataSet();

            p.OnTable = "FetchCareer";

            ds = dl.FetchCareer_sp(p);

            try
            {
                foreach (DataRow item in ds.Tables[0].Rows)
                {
                    Career m = new Career();

                    m.CId = item["CId"].ToString();
                    m.Title = item["Title"].ToString();
                    m.Des = item["Des"].ToString();
                    m.IsActive = item["IsActive"].ToString();
                    CareerList.Add(m);
                }
                ViewBag.CareerList = CareerList;
            }
            catch (Exception ex)
            {

            }
            return View();
        }
        [HttpPost]
        public ActionResult Career(Career c)
        {
            try
            {
                if (dl.InsertCareer_Sp(c) > 0)
                {
                    TempData["CareerMsg"] = "Career Added Successfully.";
                }
            }
            catch (Exception ex)
            {
                TempData["CareerMsg"] = "Something went wrong.";
                return Redirect("/Homepage/Career");
            }

            return Redirect("/Homepage/Career");
        }
        public JsonResult CareerStatus(string id, string status)
        {
            Property a = new Property();
            DataSet ds = new DataSet();
            if (status == "True")
            {
                a.Condition1 = "False";
            }
            else
            {
                a.Condition1 = "True";
            }
            a.Condition2 = id;
            a.OnTable = "ChangeCareerStatus";
            ds = dl.FetchCareer_sp(a);
            return Json(1, JsonRequestBehavior.AllowGet);
        }
        public JsonResult DeleteCareer(string id)
        {
            Property a = new Property();
            DataSet ds = new DataSet();
            a.Condition1 = id;
            a.OnTable = "DeleteCareer";
            ds = dl.FetchCareer_sp(a);
            return Json(1, JsonRequestBehavior.AllowGet);
        }
        public JsonResult getcareer(string id)
        {
            Property p = new Property();
            DataSet ds = new DataSet();

            p.OnTable = "FetchCareer";

            if (id != null)
            {
                p.Condition1 = id;
            }

            ds = dl.FetchCareer_sp(p);

            Career info = new Hospirity.Models.Career();

            try
            {
                info = new Hospirity.Models.Career()
                {
                    CId = ds.Tables[1].Rows[0]["CId"].ToString(),
                    Title = ds.Tables[1].Rows[0]["Title"].ToString(),
                    Des = ds.Tables[1].Rows[0]["Des"].ToString()
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