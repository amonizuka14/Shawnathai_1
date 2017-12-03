using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ShawnaThai_Eiei.Models;

namespace ShawnaThai_Eiei.Controllers
{
    public class ProductController : Controller
    {
        shawnathaidpuEntities db = new shawnathaidpuEntities();
        // GET: Product
        public ActionResult Product(int id)
        {
            var A = db.product_rice.Find(id);



            return View(A);


        }
    }
}






