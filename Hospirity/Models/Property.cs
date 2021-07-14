using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Hospirity.Models
{
    public class Property
    {
        private string staticSMTPHOST = "#";

        public string StaticSMTPHOST
        {
            get
            {
                return staticSMTPHOST;
            }
        }

        public int staticSMTPPort = 25;
        public int StaticSMTPPort
        {
            get
            {
                return staticSMTPPort;
            }
        }
        public static string erroCheck { get; set; }
        private string staticCredentialEmail = "#";
        // private string staticCredentialEmail = "developer@gowebbi.com";
        public string StaticCredentialEmail
        {
            get
            {
                return staticCredentialEmail;
            }
        }

        //private string staticCredentialPass = "Gowebbi@123";
        private string staticCredentialPass = "#";

        public string StaticCredentialPass
        {
            get
            {
                return staticCredentialPass;
            }
        }

        public string Condition1 { get; set; }
        public string Condition2 { get; set; }
        public string Condition3 { get; set; }
        public string Condition4 { get; set; }
        public string Condition5 { get; set; }
        public string Condition6 { get; set; }
        public string Condition7 { get; set; }
        public string Condition8 { get; set; }
        public string Condition9 { get; set; }
        public string OnTable { get; set; }
    }

    #region AdminLogin
    public class AdminLogin
    {
        public string AdminId { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string MobileNo { get; set; }
        public string IsActive { get; set; }
       
    }
    #endregion

    #region Contact
    public class Contact
    {
        public string ContactId { get; set; }
        public string Country1 { get; set; }
        public string Address1 { get; set; }
        public string Country2 { get; set; }
        public string Address2 { get; set; }
        public string Country3 { get; set; }
        public string Address3 { get; set; }
        public string IsActive { get; set; }
    }
    #endregion

    #region Banner Image
    public class BannerImage
    {
        public string BannerId { get; set; }
        public string BannerImg { get; set; }
        public string BannerTitle { get; set; }
        public string BannerDes { get; set; }
        public string IsActive { get; set; }
    }
    #endregion

    #region Homepage About
    public class HomeAbout
    {
        public string AboutId { get; set; }
        public string Img1 { get; set; }
        public string Img2 { get; set; }
        public string Img3 { get; set; }
        public string Des { get; set; }
        public string IsActive { get; set; }
    }
    #endregion

    #region Homepage Services
    public class HomeServices
    {
        public string ServicesId { get; set; }
        public string Img1 { get; set; }
        public string Img2 { get; set; }
        public string Img3 { get; set; }
        public string Img4 { get; set; }
        public string Title1 { get; set; }
        public string Title2 { get; set; }
        public string Title3 { get; set; }
        public string Title4 { get; set; }
        public string IsActive { get; set; }
    }
    #endregion

    #region Address
    public class Address
    {
        public string Id { get; set; }
        public string Location { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
    }
    #endregion

    #region Contact Us
    public class ContactUs
    {
        public string ContactId { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string MobileNo { get; set; }
        public string Message { get; set; }
        public string AddedOn { get; set; }
    }
    #endregion

    #region Photo
    public class GalleryPhoto
    {
        public string PhotoId { get; set; }
        public string Category { get; set; }
        public string ImageName { get; set; }
        public string SmallImage { get; set; }
        public string BigImage { get; set; }
        public string IsActive { get; set; }
    }
    #endregion

    #region About Us
    public class AboutUs
    {
        public string AboutId { get; set; }
        public string AboutTitle { get; set; }
        public string AboutDes { get; set; }
        public string AboutImg { get; set; }
        public string IsActive { get; set; }
    }
    public class AboutUs1
    {
        public string AboutId { get; set; }
        public string Title { get; set; }
        public string IsActive { get; set; }
    }
    public class AboutUs2
    {
        public string AboutId { get; set; }
        public string Title { get; set; }
        public string Des { get; set; }
        public string IsActive { get; set; }
    }
    public class AboutUs3
    {
        public string AboutId { get; set; }
        public string Title { get; set; }
        public string Des { get; set; }
        public string Des1 { get; set; }
        public string Services1 { get; set; }
        public string Services2 { get; set; }
        public string Services3 { get; set; }
        public string Services4 { get; set; }
        public string Services5 { get; set; }
        public string Img { get; set; }
        public string IsActive { get; set; }
    }
    //public class InsImg
    //{
    //    public string ImgId { get; set; }
    //    public string Img { get; set; }
    //    public string IsActive { get; set; }
    //}
    //public class OurTeam
    //{
    //    public string TeamId { get; set; }
    //    public string Team { get; set; }
    //    public string IsActive { get; set; }
    //}
    #endregion

    #region Services
    public class Services
    {
        public string ServicesId { get; set; }
        public string Title { get; set; }
        public string SubTitle { get; set; }
        //public string Des { get; set; }
        public string Img { get; set; }
        public string IsActive { get; set; }
    }
    #endregion

    #region Company Profile
    public class CompanyProfile
    {
        public string CId { get; set; }
        public string Vision { get; set; }
        public string CValues { get; set; }
        public string Mission { get; set; }
    }
    #endregion

    #region Testimonial
    public class Testimonial
    {
        public string TestimonialId { get; set; }
        public string CName { get; set; }
        public string CDesignation { get; set; }
        public string CImg { get; set; }
        public string Testimonials { get; set; }
        public string IsActive { get; set; }
    }
    #endregion

    #region Blog
    public class Blog
    {
        public string BlogId { get; set; }
        public string BlogTitle { get; set; }
        public string SmallDescription { get; set; }
        public string BlogDescription { get; set; }
        public string BlogImg { get; set; }
        public string IsActive { get; set; }
    }
    #endregion

    #region Career
    public class Career
    {
        public string CId { get; set; }
        public string Title { get; set; }
        public string Des { get; set; }
        public string IsActive { get; set; }
    }
    #endregion
}