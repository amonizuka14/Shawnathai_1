using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ShawnaThai_Eiei.Models;

namespace ShawnaThai_Eiei.Controllers
{
    public class HistoryController : Controller
    {
        shawnathaidpuEntities db = new shawnathaidpuEntities();
        // GET: History
        public ActionResult History(int id)
        {
            var A = db.product_rice.Find(id);


            return View(A);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult History(string Sell_NumID, string Sell_Date, string ProD_IDSell, string AD_ID)
        {

            var AID = Session["AD_ID"];
            string AID2 = Convert.ToString(AID);
            int Sell_NumID2 = Convert.ToInt32(ProD_IDSell);
            int ProD_IDSell2 = Convert.ToInt32(ProD_IDSell);
            history_sell h = new history_sell();
            h.ProD_IDSell = ProD_IDSell2;
            h.Sell_NumID = Sell_NumID2;
            h.Sell_Date = Sell_Date;
            h.AD_ID = AID2;

            db.history_sell.Add(h);
            db.SaveChanges();
            return RedirectToAction("HistoryTable", "HistoryTable");


            if (ModelState.IsValid)
            {


                try
                {


                    var product = db.history_sell.Add(h);

                    db.SaveChanges();
                    Session["id"] = product.ProD_IDSell;
                    return RedirectToAction("HistoryTable", "HistoryTable");
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