using Admin.Model.Models;
using Admin.Service;
using Admin.Web.Infrastructure.Extensions;
using Admin.Web.Models;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Admin.Web.Areas.Administrator.Controllers
{
    public class ProductCategoryController : Controller
    {
        IProductService _productService;
        IProductCategoryService _productCategoryService;
        public ProductCategoryController(IProductService productService, IProductCategoryService productCategoryService)
        {
            this._productService = productService;
            this._productCategoryService = productCategoryService;
        }
        // GET: Administrator/ProductCategory
        public ActionResult Index()
        {
            var model = _productCategoryService.GetAll();
            var responseData = Mapper.Map<IEnumerable<ProductCategory>, IEnumerable<ProductCategoryViewModel>>(model);
            return View(responseData);
        }

        // GET: Administrator/ProductCategory/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Administrator/ProductCategory/Create
        public ActionResult Create()
        {
            return View();
        }

        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ProductCategoryViewModel productCategoryViewModel)
        {
            if (ModelState.IsValid)
            {
                var newProductCategory = new ProductCategory();
                newProductCategory.UpdateProductCategory(productCategoryViewModel);
                newProductCategory.CreatedDate = DateTime.Now;
                _productCategoryService.Add(newProductCategory);
                _productCategoryService.Save();

                //var responseData = Mapper.Map<ProductCategory, ProductCategoryViewModel>(newProductCategory);
                return RedirectToAction("Index");
            }

            return View();
        }

        // GET: Administrator/ProductCategory/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Administrator/ProductCategory/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Administrator/ProductCategory/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Administrator/ProductCategory/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
