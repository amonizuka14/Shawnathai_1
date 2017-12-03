using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.SqlClient;
using ShawnaThai_Eiei.Models;
using System.Data.Entity.Validation;
using System.IO;

namespace ShawnaThai_Eiei.Controllers
{

    public class PostSellController : Controller
    {
        shawnathaidpuEntities db = new shawnathaidpuEntities();

        // GET: RegistorDriver
        public ActionResult PostSell()
        {
            string query = "SELECT * FROM RiceType ";
            var testz = db.Database.SqlQuery<ricetype>(query).ToList();
            return View(testz);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]

        public ActionResult PostSell(HttpPostedFileBase ProD_Pic, string ProD_IDSell, string ProD_Moisture, string ProD_Weight, string ProD_Price, HttpPostedFileBase ProD_CertiWeightRice,
            string Farmer_IDCard, string RType_Name, string ProD_Topic)

        {
            int ProD_IDSell2 = Convert.ToInt32(ProD_IDSell);
            product_rice post = new product_rice();
            post.ProD_IDSell = ProD_IDSell2;
            //  post.ProD_Pic = ProD_Pic;
            post.ProD_Topic = ProD_Topic;
            post.ProD_Moisture = ProD_Moisture;
            post.ProD_Weight = ProD_Weight;
            post.ProD_Price = ProD_Price;
            // post.ProD_CertiWeightRice = ProD_CertiWeightRice;
            post.RType_Name = RType_Name;
            post.Farmer_IDCard = Farmer_IDCard;
            












            string query = "SELECT * FROM Product_Rice";
            var data = db.Database.SqlQuery<product_rice>(query).OrderByDescending(c => c.ProD_IDSell).ToList();

            foreach (var key in data)
            {
                if (key.Equals(ProD_IDSell))
                {
                    ViewBag.Message = "รหัสมีผู้ใช้แล้ว";
                    return View();
                }
            }

            var nameimg = ProD_IDSell + ProD_Pic.FileName;


            var nameimg1 = ProD_IDSell + ProD_CertiWeightRice.FileName;


            string path = Path.Combine(Server.MapPath("~/Images"),
                                      Path.GetFileName(nameimg));
            ProD_Pic.SaveAs(path);
            post.ProD_Pic = "http://localhost:52954/Images/" + nameimg;



            string path2 = Path.Combine(Server.MapPath("~/Images"),
                                      Path.GetFileName(nameimg1));
            ProD_CertiWeightRice.SaveAs(path2);
            post.ProD_CertiWeightRice = "http://localhost:52954/Images/" + nameimg1;



            if (ModelState.IsValid)
            {


                try
                {


                    var product = db.product_rice.Add(post);

                    
                    db.SaveChanges();
                    //Session["id"] = product.ProD_IDSell;
                    return RedirectToAction("Sellingz2", "Sellingz2");
                }
                catch (Exception ex)
                {
                    //var errorMessages = ex.EntityValidationErrors.SelectMany(x => x.ValidationErrors).Select(x => x.ErrorMessage);
                    //var fullErrorMessage = string.Join("; ", errorMessages);
                    //var exceptionMessage = string.Concat(ex.Message, " The validation errors are: ", fullErrorMessage);
                    //throw e;

                    throw ex;



                }

            }
            return RedirectToAction("Index", "Index");

        }

    }


}
