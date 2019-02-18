using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MediaOrganiser.Models.IRepositories
{
    public interface ICategoryRepository
    {
        Task<IEnumerable<Category>> GetAllCategoriesAsync();

        Task<Category> GetCategoryById(int? id);

        Task AddCategoryAsync(Category category);

        Task DeleteCategoryAsync(Category category);

        Task<bool> CategoryExistsAsync(int id);
    }
}
