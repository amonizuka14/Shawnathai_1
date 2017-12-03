using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ShawnaThai_Eiei.Models;
using System.Data.Entity.Validation;

namespace ShawnaThai_Eiei.Controllers
{
    public class UserController : Controller
    {
        // GET: User
        public ActionResult Index()
        {
            return View();
        }

        shawnathaidpuEntities db = new shawnathaidpuEntities();
        [HttpGet]
        // GET: GoogleMap

        public ActionResult Selling()
        {
            return View();
        }
        public ActionResult Sellingz()
        {
            return View();
        }
        public ActionResult Rice2()
        {
            return View();
        }
        public ActionResult Product()
        {
            return View();
        }
    }
}