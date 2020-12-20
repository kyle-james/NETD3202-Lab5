using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Lab5.Models;

namespace Lab5.Controllers
{
    public class ShopModelsController : Controller
    {
        private readonly ShopContext _context;

        public ShopModelsController(ShopContext context)
        {
            _context = context;
        }

        // GET: ShopModels
        public async Task<IActionResult> Index()
        {
            return View(await _context.ShopModels.ToListAsync());
        }

        // GET: ShopModels/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var shopModel = await _context.ShopModels
                .FirstOrDefaultAsync(m => m.skuId == id);
            if (shopModel == null)
            {
                return NotFound();
            }

            return View(shopModel);
        }

        // GET: ShopModels/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ShopModels/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("skuId,name,price")] ShopModel shopModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(shopModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(shopModel);
        }

        // GET: ShopModels/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var shopModel = await _context.ShopModels.FindAsync(id);
            if (shopModel == null)
            {
                return NotFound();
            }
            return View(shopModel);
        }

        // POST: ShopModels/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("skuId,name,price")] ShopModel shopModel)
        {
            if (id != shopModel.skuId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(shopModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ShopModelExists(shopModel.skuId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(shopModel);
        }

        // GET: ShopModels/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var shopModel = await _context.ShopModels
                .FirstOrDefaultAsync(m => m.skuId == id);
            if (shopModel == null)
            {
                return NotFound();
            }

            return View(shopModel);
        }

        // POST: ShopModels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var shopModel = await _context.ShopModels.FindAsync(id);
            _context.ShopModels.Remove(shopModel);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ShopModelExists(int id)
        {
            return _context.ShopModels.Any(e => e.skuId == id);
        }
    }
}
