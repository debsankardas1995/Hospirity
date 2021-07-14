using Hospirity.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Hospirity.Controllers
{
    public class HomeController : Controller
    {
        DLayer dl = new DLayer();
        public ActionResult Index()
        {
            List<BannerImage> BannerList = new List<BannerImage>();
            List<Services> ServicesList = new List<Services>();
            List<Career> CareerList = new List<Career>();
            List<Testimonial> TestimonialList = new List<Testimonial>();
            List<Blog> BlogList = new List<Blog>();

            Property p = new Property();
            DataSet ds = new DataSet();

            p.OnTable = "FetchHomepage";

            ds = dl.FetchHomePage_sp(p);

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

            CompanyProfile info = new Hospirity.Models.CompanyProfile();
            try
            {
                info = new Hospirity.Models.CompanyProfile()
                {
                    Vision = ds.Tables[1].Rows[0]["Vision"].ToString(),
                    CValues = ds.Tables[1].Rows[0]["CValues"].ToString(),
                    Mission = ds.Tables[1].Rows[0]["Mission"].ToString()
                };
            }
            catch(Exception ex)
            {

            }

            ViewBag.Company = info;

            try
            {
                foreach (DataRow item in ds.Tables[2].Rows)
                {
                    Services m = new Services();

                    m.ServicesId = item["ServicesId"].ToString();
                    m.Title = item["Title"].ToString();
                    m.SubTitle = item["SubTitle"].ToString();
                    m.Img = item["Img"].ToString();
                    m.IsActive = item["IsActive"].ToString();
                    ServicesList.Add(m);
                }
                ViewBag.ServicesList = ServicesList;
            }
            catch (Exception ex)
            {

            }

            try
            {
                foreach (DataRow item in ds.Tables[3].Rows)
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

            try
            {
                foreach (DataRow item in ds.Tables[4].Rows)
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

            try
            {
                foreach (DataRow item in ds.Tables[5].Rows)
                {
                    Blog m = new Blog();

                    m.BlogId = item["BlogId"].ToString();
                    m.BlogTitle = item["BlogTitle"].ToString();
                    m.BlogDescription = item["BlogDescription"].ToString();
                    m.SmallDescription = item["SmallDescription"].ToString();
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
        
    }
}