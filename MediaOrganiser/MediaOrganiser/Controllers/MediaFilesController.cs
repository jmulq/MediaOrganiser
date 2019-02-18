using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MediaOrganiser.Models;
using MediaOrganiser.Models.IRepositories;
using MediaOrganiser.Models.Repositories;
using MediaOrganiser.ViewModels;

namespace MediaOrganiser.Controllers
{
    public class MediaFilesController : Controller
    {
        private IMediaFileRepository mfRepository = null;
        
        public  MediaFilesController(IMediaFileRepository mfRepository)
        {
            this.mfRepository = mfRepository;
        }



        // GET: MediaFiles
        public async Task<IActionResult> Index()
        {
            IEnumerable<MediaFile> mediaFiles = await mfRepository.GetAllMediaFilesAsync();

            return View(mediaFiles);
        }

        // GET: MediaFiles/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            MediaFile mediaFile = await mfRepository.GetMediaFileByIdAsync(id);
            if (mediaFile == null)
            {
                return NotFound();
            }

            return View(mediaFile);
        }

        // GET: MediaFiles/Create
        public IActionResult Create()
        {
            MediaFile mediaFile = new MediaFile();
            
            return View(mediaFile);
        }


        // POST: MediaFiles/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,UserId,MediaTypeId,Name,Thumbnail,Categories,Description,DateCreated,DateModified,SizeMB")] MediaFile mediaFile)
        {
            if (ModelState.IsValid)
            {
                await mfRepository.AddMediaFileAsync(mediaFile);
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

            MediaFile mediaFile = await mfRepository.GetMediaFileByIdAsync(id);
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
        public async Task<IActionResult> Edit(int id, [Bind("Id,UserId,MediaTypeId,Name,Thumbnail,CategoryId,Description,DateCreated,DateModified,SizeMB")] MediaFile mediaFile)
        {
            if (id != mediaFile.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    await mfRepository.UpdateMediaFileAsync(mediaFile);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MediaFileExists(mediaFile.Id))
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

            MediaFile mediaFile = await mfRepository.GetMediaFileByIdAsync(id);
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
            MediaFile mediaFile = await mfRepository.GetMediaFileByIdAsync(id);
            await mfRepository.DeleteMediaFileAsync(mediaFile);
            return RedirectToAction(nameof(Index));
        }

        private bool MediaFileExists(int id)
        {
            return MediaFileExists(id);
        }
    }
}
