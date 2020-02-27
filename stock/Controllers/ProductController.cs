using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using stock.Models;
using Microsoft.EntityFrameworkCore;

namespace stock.Controllers
{
    public class ProductController : Controller
    {
       
        private StorageContext db;
        public ProductController(StorageContext context)
        {
            db = context;
        }
              
        public async Task<IActionResult> Index()
        {
     
            return View(await db.Products.ToListAsync());
        }

     

        public IActionResult Create()
        {
            var storage = from s in db.Storages
                           select s;

            ViewData["Storage"] = new Microsoft.AspNetCore.Mvc.Rendering.SelectList(storage.ToList(),"Id","Name");
            return View();
        }
        public async Task<IActionResult> Edit(int? id)
        {
            if (id != null)
            {
                
                Product product = await db.Products.FirstOrDefaultAsync(p => p.Id == id);
                var storage = from s in db.Storages
                              where s.Id == product.StorageId
                              select s;

                ViewData["Storage"] = new Microsoft.AspNetCore.Mvc.Rendering.SelectList(storage.ToList(), "Id", "Name");
                if (product != null)

                    return View(product);
            }
            return NotFound();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Product product)
        {
            db.Products.Add(product);
            await db.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        [HttpPost]
        public async Task<IActionResult> Edit (Product product)
        {
            db.Products.Update(product);
            await db.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        [HttpGet]
        [ActionName("Delete")]
        public async Task<IActionResult> ConfirmDelete(int? id)
        {
            if (id != null)
            {
                Product product = await db.Products.FirstOrDefaultAsync(p => p.Id == id);
                if (product != null)
                    return View(product);
            }
            return NotFound();
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id != null)
            {
                Product product = await db.Products.FirstOrDefaultAsync(p => p.Id == id);
                if (product != null)
                {
                    db.Products.Remove(product);
                    await db.SaveChangesAsync();
                    return RedirectToAction("Index");
                }
            }
            return NotFound();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
