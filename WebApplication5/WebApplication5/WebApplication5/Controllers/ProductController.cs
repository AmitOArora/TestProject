using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace WebApplication5.Controllers
{
    public class ProductController : Controller
    {
        public IActionResult Index()
        {
            List<ProductModel> model = new List<ProductModel>();
            model = ProductService.getProducts();
            return View(model);
        }

        public IActionResult Create(int ID = 0)
        {
            ProductModel model = new ProductModel();
            if (ID > 0) 
            {
                model = ProductService.getProduct(ID);
            }

            return View(model);
        }

        [HttpPost]
        public IActionResult Create(ProductModel model)
        {
            ProductService.addProduct(model); 
            return Index();
        }


        public IActionResult Edit(int ID)
        {
            ProductModel model = new ProductModel();
            model = ProductService.getProduct(ID);
            return View(model);
        }

        [HttpPost]
        public IActionResult EditProduct(ProductModel model)
        {
            ProductService.updateProduct(model);
            return RedirectToAction("Index");
        }

        public IActionResult Delete(int ID)
        {

            ProductService.deleteProduct(ID);
            return RedirectToAction("Index");
        }
    }
}