using EcommerceDemo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EcommerceDemo.Controllers
{
    public class CommonController : Controller
    {
        public object Logger { get; private set; }
        // GET: CommonController
        public ActionResult Index()
        {
            return View();
        }

        #region Delete
        [HttpPost]
        public ActionResult deletemethod(long Id, string Table_Name, string Coulmn_Name)
        {
            int Result = 0;
            try
            {
                Result = new SQLDbInterface().deletefunction(Id, Table_Name, Coulmn_Name);


            }
            catch (Exception ex)
            {
                ViewBag.validationMessage = "Some technical error.Please contact to administrator";
            }
            //return View();
            return Json(Result, JsonRequestBehavior.AllowGet);
        }
        #endregion
    }
}