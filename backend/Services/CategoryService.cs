using backend.Data;
using backend.DTO;
using backend.Interfaces;
using backend.Utilities;
using backend.Helpers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace backend.Services
{
    public class CategoryService : ICategoryService
    {
        private MyDbContext _context;
        public CategoryService(MyDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> AddCategory(CategoryDTO category)
        {
            var foundCategoryName = _context.Categories.FirstOrDefault(x => x.CategoryName == category.CategoryName);
            if (foundCategoryName != null) throw new AppException("Category is already existed. Please enter a different category");
            var foundCategoryPrefix = _context.Categories.FirstOrDefault(m => m.Prefix == category.Perfix);
            if (foundCategoryPrefix != null) throw new AppException("Prefix is already existed. Please enter a different prefix");
                if (_context.Categories != null)
                {
                    try
                    {
                        await _context.Categories.AddAsync(category.CategoryDTOToEntity());
                        await _context.SaveChangesAsync();
                        return new OkResult();
                    }
                    catch (Exception e)
                    {
                        return new BadRequestObjectResult(e);
                    }
                }
                else
                    return new NoContentResult();
        }
        public async Task<IActionResult> UpdateCategory(int id, CategoryDTO category)
        {
            if (_context.Categories != null)
            {
                try
                {
                    var foundCategory = await _context.Categories.FindAsync(id);
                    if (foundCategory != null)
                    {
                        foundCategory = category.CategoryDTOToEntity();
                        _context.Categories.Update(foundCategory);
                        await _context.SaveChangesAsync();
                        return new OkResult();
                    }
                    else
                        return new NotFoundResult();
                }
                catch (Exception e)
                {
                    return new BadRequestObjectResult(e);
                }
            }
            else
                return new NoContentResult();
        }
        public async Task<IActionResult> DeleteCategory(int id)
        {
            if (_context.Categories != null)
            {
                try
                {
                    var foundCategory = await _context.Categories.FindAsync(id);
                    if (foundCategory != null)
                    {
                        _context.Categories.Remove(foundCategory);
                        await _context.SaveChangesAsync();
                        return new OkResult();
                    }
                    else
                        return new NotFoundResult();
                }
                catch (Exception e)
                {
                    return new BadRequestObjectResult(e);
                }
            }
            else
                return new NoContentResult();
        }
        public async Task<ActionResult<CategoryDTO>> GetCategory(int id)
        {
            if (_context.Categories != null)
            {
                try
                {
                    var foundCategory = await _context.Categories.FindAsync(id);
                    if (foundCategory != null)
                        return new OkObjectResult(foundCategory.CategoryEntityToDTO());
                    else
                        return new NotFoundResult();
                }
                catch (Exception e)
                {
                    return new BadRequestObjectResult(e);
                }
            }
            return new NoContentResult();
        }
        public async Task<ActionResult<List<CategoryDTO>>> GetAllCategories()
        {
            if (_context.Categories != null)
            {
                try
                {
                    var categories = await _context.Categories.Select(category => category.CategoryEntityToDTO()).ToListAsync();
                    return new OkObjectResult(categories);
                }
                catch (Exception e)
                {
                    return new BadRequestObjectResult(e);
                }
            }
            return new NoContentResult();
        }
    }
}