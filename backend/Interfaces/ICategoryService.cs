using backend.DTO;
using Microsoft.AspNetCore.Mvc;

namespace backend.Interfaces
{
    public interface ICategoryService
    {
        public Task<ActionResult<List<CategoryDTO>>> GetAllCategories();
        public Task<ActionResult<CategoryDTO>> GetCategory(int id);

        public Task<IActionResult> AddCategory(CategoryDTO category);

        public Task<IActionResult> UpdateCategory(int id, CategoryDTO category);

        // public Task<IActionResult> DeleteCategory(int id);
    }
}