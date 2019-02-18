using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediaOrganiser.Models.IRepositories;
using Microsoft.EntityFrameworkCore;

namespace MediaOrganiser.Models.Repositories
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly MediaOrganiserContext context;

        public CategoryRepository(MediaOrganiserContext context)
        {
            this.context = context;
        }

        public async Task<IEnumerable<Category>> GetAllCategoriesAsync()
        {
            return await context.Categories.ToListAsync();
        }

        public async Task<Category> GetCategoryById(int? id)
        {
            return await context.Categories.SingleOrDefaultAsync(c => c.Id == id);
        }

        public async Task AddCategoryAsync(Category category)
        {
            await context.AddAsync(category);
            await context.SaveChangesAsync();
        }

        public async Task DeleteCategoryAsync(Category category)
        {
            context.Remove(category);
            await context.SaveChangesAsync();
        }

        public async Task<bool> CategoryExistsAsync(int id)
        {
            return await context.Categories.AnyAsync(c => c.Id == id);
        }
        
    }
}
