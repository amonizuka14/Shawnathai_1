using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Net;
using System.Net.Mail;
using ShawnaThai_Eiei.Models;

namespace ShawnaThai_Eiei.Controllers
{

    public class ForgotPasswordController : Controller
    {
        shawnathaidpuEntities db = new shawnathaidpuEntities();
        // GET: ForgotPassword
        [HttpGet]


        public ActionResult SelectForgot()
        {
            return View();
        }

        public ActionResult ForgotAdminID()
        {
            string AD_Email = Request.Form["AD_Email"];
            string AD_ID = Request.Form["AD_ID"];
            string AD_Tel = Request.Form["AD_Tel"];
            var check = db.admin_cooperative.Where(b => b.AD_ID.Equals(AD_ID)).FirstOrDefault<admin_cooperative>();
            var check2 = db.admin_cooperative.Where(b => b.AD_Tel.Equals(AD_Tel)).FirstOrDefault<admin_cooperative>();
            if (check != null && check2 != null)
            {
                var chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
                var stringChars = new char[8];
                var random = new Random();

                for (int i = 0; i < stringChars.Length; i++)
                {
                    stringChars[i] = chars[random.Next(chars.Length)];
                }

                var finalString = new String(stringChars);
                check.AD_Password = finalString;
                db.SaveChanges();
                using (MailMessage mma = new MailMessage("shawnathaidpu@gmail.com", AD_Email))
                {
                    mma.Subject = "Reset Password";

                    mma.Body = "รหัสผ่านใหม่ของคุณคือ : " + check.AD_Password;


                    mma.IsBodyHtml = false;
                    using (SmtpClient smtp = new SmtpClient())
                    {
                        smtp.Host = "smtp.gmail.com";
                        smtp.Port = 587;
                        smtp.EnableSsl = true;
                        NetworkCredential NetworkCred = new NetworkCredential("shawnathaidpu@gmail.com", "Gear2404");
                        smtp.UseDefaultCredentials = true;
                        smtp.Credentials = NetworkCred;
                        smtp.Send(mma);
                        ViewBag.ok = "OK";
                    }
                }
            }

            return View();

        }

        public ActionResult ForgotUserID()
        {
            string Users_Email = Request.Form["User_Email"];
            string IDCard = Request.Form["IDCard"];
            string User_Tel = Request.Form["User_Tel"];
            var check = db.user.Where(b => b.U_IDCard.Equals(IDCard)).FirstOrDefault<user>();
            var check2 = db.user.Where(b => b.U_Tel.Equals(User_Tel)).FirstOrDefault<user>();
            if (check != null && check2 != null)
            {
                var chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
                var stringChars = new char[8];
                var random = new Random();

                for (int i = 0; i < stringChars.Length; i++)
                {
                    stringChars[i] = chars[random.Next(chars.Length)];
                }

                var finalString = new String(stringChars);
                check.U_Password = finalString;
                db.SaveChanges();
                using (MailMessage mm = new MailMessage("shawnathaidpu@gmail.com", Users_Email))
                {
                    mm.Subject = "Reset Password";

                    mm.Body = "รหัสผ่านใหม่ของคุณคือ : " + check.U_Password;


                    mm.IsBodyHtml = false;
                    using (SmtpClient smtp = new SmtpClient())
                    {
                        smtp.Host = "smtp.gmail.com";
                        smtp.Port = 587;
                        smtp.EnableSsl = true;
                        NetworkCredential NetworkCred = new NetworkCredential("shawnathaidpu@gmail.com", "Gear2404");
                        smtp.UseDefaultCredentials = true;
                        smtp.Credentials = NetworkCred;
                        smtp.Send(mm);
                        ViewBag.ok = "OK";
                    }
                }

            }

            return View();

        }
    }
}