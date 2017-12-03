using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ShawnaThai_Eiei.Models;

namespace ShawnaThai_Eiei.Controllers
{
    public class Sellingz2Controller : Controller
    {
        shawnathaidpuEntities db = new shawnathaidpuEntities();
        // GET: Sellingz2
        public ActionResult Sellingz2()
        {
            string query1 = "SELECT * FROM Product_Rice ";

            var data1 = db.Database.SqlQuery<product_rice>(query1).OrderByDescending(c => c.ProD_IDSell).ToList();
            return View(data1);
        }
    }
}