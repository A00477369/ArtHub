using System;
using ArtHub.dto;
using ArtHub.Models;

namespace ArtHub.Services.ServicesImpl
{
    public class CategoryServiceImpl : CategoryService
    {
        private readonly AppDbContext _context;
        public CategoryServiceImpl(AppDbContext context)
        {
            _context = context;
        }
        public Category CreateCategory(Category category)
        {
            throw new NotImplementedException();
        }

        public List<Category> GetAllCategories()
        {
            List<Category> categoryList = _context.Category.ToList();
            return categoryList;
        }

        public Category GetCategoryById(int id)
        {
            return _context.Category.Find(id);
        }

        public Category UpdateCategory(UpdateCategoryDto dto, Category existingCategory)
        {
            throw new NotImplementedException();
        }
    }
}

