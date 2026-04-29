using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ProEstetik.Web.Data;
using ProEstetik.Web.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace ProEstetik.Web.Areas.admin.Controllers
{
    [Area("admin")]
    public class SiteSettingsController : Controller
    {
        private readonly DatabaseContext _context;

        public SiteSettingsController(DatabaseContext context)
        {
            _context = context;
        }

        // GET: admin/SiteSettings
        public async Task<IActionResult> Index()
        {
            return View(await _context.SiteSettings.ToListAsync());
        }

        // GET: admin/SiteSettings/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var siteSetting = await _context.SiteSettings
                .FirstOrDefaultAsync(m => m.Id == id);
            if (siteSetting == null)
            {
                return NotFound();
            }

            return View(siteSetting);
        }

        // GET: admin/SiteSettings/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: admin/SiteSettings/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Phone,WhatsApp,Email,Address,Facebook,Instagram,Youtube,Keywords,MetaDescription,MetaTitle,Language")] SiteSetting siteSetting)
        {
            if (ModelState.IsValid)
            {
                _context.Add(siteSetting);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(siteSetting);
        }

        // GET: admin/SiteSettings/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var siteSetting = await _context.SiteSettings.FindAsync(id);
            if (siteSetting == null)
            {
                return NotFound();
            }
            return View(siteSetting);
        }

        // POST: admin/SiteSettings/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, SiteSetting siteSetting)
        {
            if (id != siteSetting.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                // 1. Veritabanındaki asıl kaydı buluyoruz
                var settingToUpdate = await _context.SiteSettings.FirstOrDefaultAsync(s => s.Id == id);

                if (settingToUpdate == null)
                {
                    return NotFound();
                }

                try
                {
                    // 2. Değerleri formdan gelen nesneden asıl nesneye aktarıyoruz
                    // (Property isimlerinize göre burayı düzenleyin)
                    _context.Entry(settingToUpdate).CurrentValues.SetValues(siteSetting);

                    // 3. Değişiklikleri kaydediyoruz
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SiteSettingExists(siteSetting.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
            }
            return View(siteSetting);
        }

        // GET: admin/SiteSettings/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var siteSetting = await _context.SiteSettings
                .FirstOrDefaultAsync(m => m.Id == id);
            if (siteSetting == null)
            {
                return NotFound();
            }

            return View(siteSetting);
        }

        // POST: admin/SiteSettings/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var siteSetting = await _context.SiteSettings.FindAsync(id);
            if (siteSetting != null)
            {
                _context.SiteSettings.Remove(siteSetting);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SiteSettingExists(int id)
        {
            return _context.SiteSettings.Any(e => e.Id == id);
        }
    }
}
