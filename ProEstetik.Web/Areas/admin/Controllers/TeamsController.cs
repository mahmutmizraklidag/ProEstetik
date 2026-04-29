using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ProEstetik.Web.Data;
using ProEstetik.Web.Entities;
using ProEstetik.Web.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProEstetik.Web.Areas.admin.Controllers
{
    [Area("admin")]
    public class TeamsController : Controller
    {
        private readonly DatabaseContext _context;

        public TeamsController(DatabaseContext context)
        {
            _context = context;
        }

        // GET: admin/Teams
        public async Task<IActionResult> Index()
        {
            return View(await _context.Teams.ToListAsync());
        }

       

        // GET: admin/Teams/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: admin/Teams/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Team team,IFormFile? Image)
        {
            if (ModelState.IsValid)
            {
                if (Image is not null) team.Image = await FileHelper.FileLoaderAsync(Image);
                _context.Add(team);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(team);
        }

        // GET: admin/Teams/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var team = await _context.Teams.FindAsync(id);
            if (team == null)
            {
                return NotFound();
            }
            return View(team);
        }

        // POST: admin/Teams/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Team team,IFormFile? Image)
        {
            if (id != team.Id)
            {
                return NotFound();
            }
            if (!ModelState.IsValid)
                return View(team);

            var dbTeam= await _context.Teams.FindAsync(id);
            if (dbTeam is null) return NotFound();
            dbTeam.Name= team.Name;
            dbTeam.Position= team.Position;
            dbTeam.Description= team.Description;
            dbTeam.Keywords= team.Keywords;
            dbTeam.MetaDescription= team.MetaDescription;
            dbTeam.MetaTitle= team.MetaTitle;
            dbTeam.Language= team.Language;
            dbTeam.Slug= team.Slug;

            if (Image is not null)
            {
                dbTeam.Image = await FileHelper.FileLoaderAsync(Image);
            }
            await _context.SaveChangesAsync();
            return RedirectToAction("Index", "Teams", new { area = "Admin" });

            
        }

        // GET: admin/Teams/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var team = await _context.Teams
                .FirstOrDefaultAsync(m => m.Id == id);
            if (team == null)
            {
                return NotFound();
            }

            return View(team);
        }

        // POST: admin/Teams/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var team = await _context.Teams.FindAsync(id);
            if (team != null)
            {
                _context.Teams.Remove(team);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TeamExists(int id)
        {
            return _context.Teams.Any(e => e.Id == id);
        }
    }
}
