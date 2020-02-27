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
    public class StorageController : Controller
    {
       
        private StorageContext db;
        public StorageController(StorageContext context)
        {
            db = context;
        }
              
        public async Task<IActionResult> Index()
        {
            return View(await db.Storages.ToListAsync());
        }
        public IActionResult Create()
        {
            return View();
        }
        public async Task<IActionResult> Edit(int? id)
        {
            if (id != null)
            {
                Storage storage = await db.Storages.FirstOrDefaultAsync(p => p.Id == id);
                if (storage != null)

                    return View(storage);
            }
            return NotFound();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Storage storage)
        {
            db.Storages.Add(storage);
            await db.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        [HttpPost]
        public async Task<IActionResult> Edit (Storage storage)
        {
            db.Storages.Update(storage);
            await db.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        [HttpGet]
        [ActionName("Delete")]
        public async Task<IActionResult> ConfirmDelete(int? id)
        {
            if (id != null)
            {
                Storage storage = await db.Storages.FirstOrDefaultAsync(p => p.Id == id);
                if (storage != null)
                    return View(storage);
            }
            return NotFound();
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id != null)
            {
                Storage storage = await db.Storages.FirstOrDefaultAsync(p => p.Id == id);
                if (storage != null)
                {
                    db.Storages.Remove(storage);
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
