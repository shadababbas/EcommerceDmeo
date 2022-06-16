using EcommerceDemo.Common;
using EcommerceDemo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Mvc;

namespace EcommerceDemo.Controllers
{
    public class ProductMasterController : Controller
    {
        private EcommerceDemoEntities db = new EcommerceDemoEntities();
        // GET: ProductMaster
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult loaddata()
        {
            try
            {
                List<TBL_Products> Productmaster = (from Product in db.TBL_Products where Product.IsActive == true select Product).ToList();
                List<TBL_Category> Categorymaster = (from Category in db.TBL_Category where Category.IsActive == true select Category).ToList();

                var data = (from P in db.TBL_Products
                            join C in db.TBL_Category on P.CategoryID equals C.ID
                            where P.IsActive == true

                            select new ProductsViewModel
                            {
                                ID = P.ID,
                                CategoryName = (C.CategoryName != null) ? C.CategoryName : " ",
                                ProductName = P.ProductName,
                                Price = 0,//(P.Price != 0) ? Convert.ToInt64(P.Price) : 0,
                                CreatedDate = "",//Convert.ToString(P.CreatedDate)
                            });
                return Json(new { data = data }, JsonRequestBehavior.AllowGet);
            }
            catch(Exception ex)
            {
                Logger.SaveErrorLog(this.ToString(), MethodBase.GetCurrentMethod().Name, ex);
                ViewBag.validationMessage = "Some technical error.Please contact to administrator";
            }
            return View();


        }

        #region Create
        // GET: ProductMaster/Create
        public ActionResult Create()
        {
            List<TBL_Category> CategoryList = new List<TBL_Category>();
            CategoryList = (from Category in db.TBL_Category where Category.IsActive == true select Category).ToList();
            ViewBag.CategoryList = CategoryList;

            ViewBag.validationMessage = "";
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ProductsViewModel ProductsViewModel)
        {
            ViewBag.validationMessage = "";

            try
            {
                if (ModelState.IsValid)
                {
                    TBL_Products Product = new TBL_Products();

                    Product.CategoryID = ProductsViewModel.CategoryID;
                    Product.ProductName = ProductsViewModel.ProductName;
                    Product.Price = ProductsViewModel.Price;
                    Product.CreatedDate = DateTime.Now;
                    Product.IsActive = true;
                    db.TBL_Products.Add(Product);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }

            }
            catch (Exception ex)
            {
                Logger.SaveErrorLog(this.ToString(), MethodBase.GetCurrentMethod().Name, ex);
                ViewBag.validationMessage = "Some technical error.Please contact to administrator";
            }

            List<TBL_Category> CategoryList = new List<TBL_Category>();
            CategoryList = (from Category in db.TBL_Category where Category.IsActive == true select Category).ToList();
            ViewBag.CategoryList = CategoryList;
            
            return View(ProductsViewModel);
        }
        #endregion
    }
}