﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Linq;
using System.Threading.Tasks;
using MediaOrganiser.Models.IRepositories;
using Microsoft.EntityFrameworkCore;

namespace MediaOrganiser.Models.Repositories
{
    public class MediaFileRepository : IMediaFileRepository
    {
        private readonly MediaOrganiserContext context;



        public MediaFileRepository(MediaOrganiserContext context)
        {
            this.context = context;
        }

        public async Task<IEnumerable<MediaFile>> GetAllMediaFilesAsync()
        {
            return await context.MediaFiles.ToListAsync();
        }

        public async Task<MediaFile> GetMediaFileByIdAsync(int? mediaFileId)
        {
            return await context.MediaFiles.SingleOrDefaultAsync(mf => mf.Id == mediaFileId);
        }

        public async Task AddMediaFileAsync(MediaFile mediaFile)
        {
            await context.AddAsync(mediaFile);
            await context.SaveChangesAsync();
        }

        public async Task UpdateMediaFileAsync(MediaFile mediaFile)
        {
            MediaFile tmpMediaFile = await context.MediaFiles.SingleOrDefaultAsync(mf => mf.Id == mediaFile.Id);

            tmpMediaFile.Name = mediaFile.Name;
            tmpMediaFile.Description = mediaFile.Description;
            tmpMediaFile.Categories = mediaFile.Categories;
            tmpMediaFile.DateModified = DateTime.Now;
            tmpMediaFile.MediaType = mediaFile.MediaType;
            tmpMediaFile.Thumbnail = mediaFile.Thumbnail;

            await context.SaveChangesAsync();
        }

        public async Task DeleteMediaFileAsync(MediaFile mediaFile)
        {
            context.Remove(mediaFile);
            await context.SaveChangesAsync();
        }

        public async Task<bool> MediaFileExistsAsync(int id)
        {
            return await context.MediaFiles.AnyAsync(mf => mf.Id == id);
        }

        public async Task<IEnumerable<MediaFile>> GetMediaFilesByCategoryAsync(int categoryId)
        {
            List<MediaFileCategory> mediaFileCategories =
                await context.MediaFileCategories.Where(mfc => mfc.CategoryId == categoryId).ToListAsync();

            List<int> mediaFileIds = mediaFileCategories.Select(mf => mf.MediaFileId).ToList();

            return await context.MediaFiles.Where(mf => mediaFileIds.Contains(mf.Id)).ToListAsync();
        }
    }
}
