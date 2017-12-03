using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ShawnaThai_Eiei.Models;
using System.Data.Entity.Validation;
using System.Data.SqlClient;
using System.IO;

namespace ShawnaThai_Eiei.Controllers
{
    public class RegisterFarmerController : Controller
    {
        // GET: RegisterFarmer
        shawnathaidpuEntities db = new shawnathaidpuEntities();
        
    
        public ActionResult RegisterFarmer()
        {
            string query = "SELECT * FROM Cooperative ";
            var dataz = db.Database.SqlQuery<cooperative>(query).ToList();
            return View(dataz);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult RegisterFarmer(string Farmer_IDCard, string Farmer_Name, string Farmer_LastName, string Farmer_Tel, string Farmer_A_No, string Farmer_A_Sup, string Farmer_A_District, string Coop_Name,string Farmer_A_Province) 
            {

            farmer farmer = new farmer();
            farmer.Farmer_IDCard = Farmer_IDCard;
            farmer.Farmer_Name = Farmer_Name;
            farmer.Farmer_LastName = Farmer_LastName;
            farmer.Farmer_Tel = Farmer_Tel;
            farmer.Farmer_A_No = Farmer_A_No;
            farmer.Farmer_A_Sup = Farmer_A_Sup;
            farmer.Farmer_A_District = Farmer_A_District;
            farmer.Coop_Name = Coop_Name;
            farmer.Farmer_A_Province = Farmer_A_Province;
           

            if (ModelState.IsValid)
            {
                if (Farmer_IDCard != null)
                {
                    //var check_User = db.Users.Where(a => a.U_IDCard.Equals(U_IDCard)).FirstOrDefault<User>();
                    //if (check_User != null)
                    //{
                    //    ViewBag.Message = " Please try again.";
                    //    return View();
                    //}
                    //else
                    //{
                    try
                    {
                        db.farmer.Add(farmer);
                                               

                        db.SaveChanges() ;

                        return RedirectToAction("Login", "Login");
                    }
                    catch (DbEntityValidationException ex)
                    {
                        var errorMessages = ex.EntityValidationErrors.SelectMany(e => e.ValidationErrors).Select(e => e.ErrorMessage);
                        var fullErrorMessage = string.Join("; ", errorMessages);
                        var exceptionMessage = string.Concat(ex.Message, " The validation errors are: ", fullErrorMessage);
                        throw new DbEntityValidationException(exceptionMessage, ex.EntityValidationErrors);
                    }
                    //}

                }

            }

            return RedirectToAction("Index", "Index");
        }
    }
}


 