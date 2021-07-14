using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Mail;
using System.Web;
using System.Web.Mvc;
using Hospirity.Models;

namespace Hospirity.Controllers
{
    public class ContactController : Controller
    {
        DLayer dl = new DLayer();

        // GET: Contact
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Index(ContactUs c)
        {
            try
            {
                if (dl.InsertContactUs_Sp(c) > 0)
                {
                    SendRegistration(c.Name, c.Email, c.MobileNo, c.Message);

                    TempData["MSG1"] = "Thanks For Contacting With Us.";
                }
            }
            catch(Exception ex)
            {
                TempData["MSG1"] = "Something went wrong.";
            }
            return Redirect("/Contact");
        }
        public int SendRegistration(string id, string id1, string id2, string id3)
        {
            //id=name , id1=email, id2=phone, id3=message
            string Emaiid = id1;
            string body = string.Empty;
            using (StreamReader reader = new StreamReader(System.Web.HttpContext.Current.Server.MapPath("~/CustomMail.html")))
            {
                body = reader.ReadToEnd();
            }
            body = body.Replace("FullName", id);
            body = body.Replace("Message1", "A warm welcome from the Hospirity Team!");
            body = body.Replace("Message2", "We thank you for contact with us.");
            body = body.Replace("Message3", "Your Email Id is : " + id1);
            body = body.Replace("Message4", "Your Mobile Number is : " + id2);
            body = body.Replace("Message5", "Your Message is : " + id3);

            try
            {
                MailAddress mailfrom = new MailAddress("connect@heartnsoul.co", "Hospirity");
                MailAddress mailto = new MailAddress(Emaiid);
                MailMessage newmsg = new MailMessage(mailfrom, mailto);
                newmsg.IsBodyHtml = true;
                newmsg.Subject = "Welcome To Hospirity";
                newmsg.Body = body;
                SmtpClient smtp = new SmtpClient("relay-hosting.secureserver.net", 25);
                smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
                smtp.UseDefaultCredentials = false;
                smtp.EnableSsl = false;
                smtp.Send(newmsg);
                ModelState.Clear();
                return 1;
            }
            catch (Exception ex)
            {
                return 0;
            }
        }
    }
}