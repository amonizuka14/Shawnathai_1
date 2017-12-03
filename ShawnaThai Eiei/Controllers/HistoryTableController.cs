using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ShawnaThai_Eiei.Models;

namespace ShawnaThai_Eiei.Controllers
{
    public class HistoryTableController : Controller
    {
        shawnathaidpuEntities db = new shawnathaidpuEntities();
        // GET: HistoryTable
        public ActionResult HistoryTable()
        {

            var id2 = Session["id"];
            int id = Convert.ToInt32(id2);

            var AID = Session["AD_ID"];

            string query = "SELECT * FROM History_Sell where AD_ID = ' " + AID + "'";
            var data = db.Database.SqlQuery<history_sell>(query).OrderByDescending(c => c.ProD_IDSell).ToList();





            //return View();


            return View(Tuple.Create(data));
        }






    }
}