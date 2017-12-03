using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ShawnaThai_Eiei.Models;

namespace ShawnaThai_Eiei.Controllers
{
    public class BuyController : Controller
    {

        shawnathaidpuEntities db = new shawnathaidpuEntities();
        // GET: Buy

        public ActionResult Buy(int id)
        {


            string query = "SELECT Coop_Name FROM Farmer ";
            var data = db.Database.SqlQuery<farmer>(query).OrderByDescending(c => c.Coop_Name).ToList();

           
            return View(data);
        }
    }
}