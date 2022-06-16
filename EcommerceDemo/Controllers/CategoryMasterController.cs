using EcommerceDemo.Common;
using EcommerceDemo.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Mvc;

namespace EcommerceDemo.Controllers
{
    public class CategoryMasterController : Controller
    {
        private EcommerceDemoEntities db = new EcommerceDemoEntities();
        // GET: CategoryMaster
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult loaddata()
        {
            List<TBL_Category> Categorymaster = (from Category in db.TBL_Category where Category.IsActive == true select Category).ToList();
            var data = from e in Categorymaster.ToList()



                       select new CategoryViewModel
                       {

                           ID = e.ID,
                           CategoryName = e.CategoryName,
                           CreatedDate = Convert.ToString(e.CreatedDate),

                       };

            return Json(new { data = data }, JsonRequestBehavior.AllowGet);
        }

        #region Create
        // GET: CategoryMaster/Create
        public ActionResult Create()
        {
            ViewBag.validationMessage = "";
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CategoryViewModel CategoryViewModel)
        {
            ViewBag.validationMessage = "";

            try
            {
                if (ModelState.IsValid)
                {
                    TBL_Category Category = new TBL_Category();

                    Category.CategoryName = CategoryViewModel.CategoryName;
                    Category.CreatedDate = DateTime.Now;
                    Category.IsActive = true;
                    db.TBL_Category.Add(Category);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }

            }
            catch (Exception ex)
            {
                Logger.SaveErrorLog(this.ToString(), MethodBase.GetCurrentMethod().Name, ex);
                ViewBag.validationMessage = "Some technical error.Please contact to administrator";
            }
            return View(CategoryViewModel);
        }
        #endregion


        #region Edit
        // GET: Day/Edit/26
        public ActionResult Edit(int? id)
        {
            ViewBag.validationMessage = "";

            CategoryViewModel CategoryViewModel = new CategoryViewModel();
            try
            {
                TBL_Category Category = db.TBL_Category.Find(id);

                CategoryViewModel.CategoryName = Category.CategoryName;
            }
            catch (Exception ex)
            {
                Logger.SaveErrorLog(this.ToString(), MethodBase.GetCurrentMethod().Name, ex);
                ViewBag.validationMessage = "Some technical error.Please contact to administrator";
            }
            return View(CategoryViewModel);
        }



        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(CategoryViewModel CategoryViewModel)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    TBL_Category Category = db.TBL_Category.Find(CategoryViewModel.ID);

                    Category.CategoryName = CategoryViewModel.CategoryName;
                    db.Entry(Category).State = EntityState.Modified;
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }

            }
            catch (Exception ex)
            {
                Logger.SaveErrorLog(this.ToString(), MethodBase.GetCurrentMethod().Name, ex);
                ViewBag.validationMessage = "Some technical error.Please contact to administrator";
            }
            return View(CategoryViewModel);
        }
        #endregion
    }
}