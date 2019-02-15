using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;
using MediaOrganiser.Models;

namespace MediaOrganiser.Models
{
    public static class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new MediaOrganiserContext(
                serviceProvider.GetRequiredService<
                    DbContextOptions<MediaOrganiserContext>>()))
            {
                // Look for any movies.
                if (context.MediaFiles.Any())
                {
                    return;   // DB has been seeded
                }

                //Seed Data 
                //Media File data
                context.MediaFiles.AddRange(
                    new MediaFile
                    {
                        UserID = 1,
                        MediaTypeID = 1,
                        Name = "Cat Picture",
                        Thumbnail = ImageConverter.ImageToByteArray("C:\\Users\\James\\MediaOrganiser\\MediaOrganiser\\MediaOrganiser\\Images\breadCat.jpg"),
                        CategoryID = 1,
                        Description = "A cute picture of my cat..."
                    },

                    new MediaFile
                    {
                        UserID = 1,
                        MediaTypeID = 1,
                        Name = "Cat Picture 2",
                        Thumbnail = new byte[9],
                        CategoryID = 1,
                        Description = "A cute picture of another cat..."
                    },
                    new MediaFile
                    {
                        UserID = 1,
                        MediaTypeID = 1,
                        Name = "Dog Picture",
                        Thumbnail = new byte[9],
                        CategoryID = 2,
                        Description = "A dog..."
                    }
                );

                //Category Data
                context.Categories.AddRange(
                    new Category
                    {
                        CategoryName = "Animals"
                    },
                    new Category
                    {
                        CategoryName = "Travel"
                    });

                

                context.SaveChanges();
            }
        }
    }
}