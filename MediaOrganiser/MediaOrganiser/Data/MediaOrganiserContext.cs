using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace MediaOrganiser.Models
{
    public class MediaOrganiserContext : DbContext
    {
        public MediaOrganiserContext (DbContextOptions<MediaOrganiserContext> options)
            : base(options)
        {
        }

        public DbSet<MediaFile> MediaFiles { get; set; }
        public DbSet<MediaType> MediaTypes { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<MediaFileCategory> MediaFileCategories { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<MediaFileCategory>().HasKey(mf => new {mf.MediaFileId, mf.CategoryId});
        }

    }
}
