using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebAppShiba.DataBase;
using WebAppShiba.Models;
using WebAppShiba.Service;

namespace WebAppShiba.Controllers
{
    public class ShibasController : Controller
    {
        private readonly ShibaContext _context;

        public ShibasController(ShibaContext context)
        {
            _context = context;
        }

        // GET: Shibas
        public async Task<IActionResult> Index()
        {
            return View(await _context.Url.ToListAsync());
        }

        // GET: Shibas/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var shiba = await _context.Url
                .FirstOrDefaultAsync(m => m.Url == id);
            if (shiba == null)
            {
                return NotFound();
            }

            return View(shiba);
        }

        // GET: Shibas/Create
        [EnableCors("AllowOrigin")]
        public IActionResult Create()
        {
            return View();
        }

        // POST: Shibas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [EnableCors("AllowOrigin")]
        public async Task<IActionResult> Create(string url)
        {
            if(DataFetcherShiba.IsShibaInDb(url))
            {
                Shiba myShiba=new Shiba(url);
                _context.Url.Add(myShiba);
                await _context.SaveChangesAsync();
                return Ok("Aggiunto con sucesso al DataBase");
            }
            return Ok("Non Aggiunto al DataBase");
        }

        // GET: Shibas/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var shiba = await _context.Url.FindAsync(id);
            if (shiba == null)
            {
                return NotFound();
            }
            return View(shiba);
        }

        // POST: Shibas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("Url")] Shiba shiba)
        {
            if (id != shiba.Url)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(shiba);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ShibaExists(shiba.Url))
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
            return View(shiba);
        }

        // GET: Shibas/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var shiba = await _context.Url
                .FirstOrDefaultAsync(m => m.Url == id);
            if (shiba == null)
            {
                return NotFound();
            }

            return View(shiba);
        }

        // POST: Shibas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var shiba = await _context.Url.FindAsync(id);
            _context.Url.Remove(shiba);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ShibaExists(string id)
        {
            return _context.Url.Any(e => e.Url == id);
        }
    }
}
