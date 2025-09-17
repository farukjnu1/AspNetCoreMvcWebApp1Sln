using AspNetCoreMvcWebApp1.Models.Db;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AspNetCoreMvcWebApp1.Controllers
{
    public class ProductController : Controller
    {
        // GET: ProductController
        public ActionResult Index()
        {
            var ctx = new AuthDbContext();
            return View(ctx.TblProducts.ToList());
        }

        // GET: ProductController/Details/5
        public ActionResult Details(int id)
        {
            var ctx = new AuthDbContext();
            return View(ctx.TblProducts.Where(o => o.ProductId == id).FirstOrDefault());
        }

        // GET: ProductController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ProductController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                var ctx = new AuthDbContext();
                var productId = ctx.TblProducts.Max(o=>o.ProductId) + 1;
                var oTblProduct = new TblProduct();
                oTblProduct.ProductId = productId;
                oTblProduct.ProductName = collection["ProductName"];
                oTblProduct.Qty = Convert.ToInt32(collection["Qty"]);
                ctx.TblProducts.Add(oTblProduct);
                ctx.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ProductController/Edit/5
        public ActionResult Edit(int id)
        {
            var ctx = new AuthDbContext();
            return View(ctx.TblProducts.Where(o => o.ProductId == id).FirstOrDefault());
        }

        // POST: ProductController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                var ctx = new AuthDbContext();
                var oTblProduct = ctx.TblProducts.Where(o => o.ProductId == id).FirstOrDefault();
                if (oTblProduct != null)
                {
                    oTblProduct.ProductName = collection["ProductName"];
                    oTblProduct.Qty = Convert.ToInt32(collection["Qty"]);
                    ctx.SaveChanges();
                }
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ProductController/Delete/5
        public ActionResult Delete(int id)
        {
            var ctx = new AuthDbContext();
            return View(ctx.TblProducts.Where(o => o.ProductId == id).FirstOrDefault());
        }

        // POST: ProductController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                var ctx = new AuthDbContext();
                var oTblProduct = ctx.TblProducts.Where(o => o.ProductId == id).FirstOrDefault();
                if (oTblProduct != null)
                {
                    ctx.Remove(oTblProduct);
                    ctx.SaveChanges();
                }
                
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
