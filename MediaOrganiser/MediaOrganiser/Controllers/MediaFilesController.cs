using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MediaOrganiser.Models;

namespace MediaOrganiser.Controllers
{
    public class MediaFilesController : Controller
    {
        private readonly MediaOrganiserContext _context;

        public MediaFilesController(MediaOrganiserContext context)
        {
            _context = context;
        }

        // GET: MediaFiles
        public async Task<IActionResult> Index()
        {
            return View(await _context.MediaFiles.ToListAsync());
        }

        // GET: MediaFiles/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var mediaFile = await _context.MediaFiles
                .SingleOrDefaultAsync(m => m.ID == id);
            if (mediaFile == null)
            {
                return NotFound();
            }

            return View(mediaFile);
        }

        // GET: MediaFiles/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: MediaFiles/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,UserID,MediaTypeID,Name,Thumbnail,CategoryID,Description,DateCreated,DateModified,SizeMB")] MediaFile mediaFile)
        {
            if (ModelState.IsValid)
            {
                _context.Add(mediaFile);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(mediaFile);
        }

        // GET: MediaFiles/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var mediaFile = await _context.MediaFiles.SingleOrDefaultAsync(m => m.ID == id);
            if (mediaFile == null)
            {
                return NotFound();
            }
            return View(mediaFile);
        }

        // POST: MediaFiles/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,UserID,MediaTypeID,Name,Thumbnail,CategoryID,Description,DateCreated,DateModified,SizeMB")] MediaFile mediaFile)
        {
            if (id != mediaFile.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(mediaFile);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MediaFileExists(mediaFile.ID))
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
            return View(mediaFile);
        }

        // GET: MediaFiles/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var mediaFile = await _context.MediaFiles
                .SingleOrDefaultAsync(m => m.ID == id);
            if (mediaFile == null)
            {
                return NotFound();
            }

            return View(mediaFile);
        }

        // POST: MediaFiles/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var mediaFile = await _context.MediaFiles.SingleOrDefaultAsync(m => m.ID == id);
            _context.MediaFiles.Remove(mediaFile);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MediaFileExists(int id)
        {
            return _context.MediaFiles.Any(e => e.ID == id);
        }
    }
}
