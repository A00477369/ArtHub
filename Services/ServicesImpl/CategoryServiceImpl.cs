using System;
using System.Collections.Generic;
using System.Linq;
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
            _context.Category.Add(category);
            _context.SaveChanges();
            return category;
        }

        public List<Category> GetAllCategories()
        {
            List<Category> categoryList = _context.Category.ToList();
            return categoryList;
        }

        public Category GetCategoryById(int id)
        {
            Category category = _context.Category.Find(id);
            return category;
        }

        public Category UpdateCategory(UpdateCategoryDto dto, Category existingCategory)
        {
            if (existingCategory != null)
            {
                existingCategory.Title = dto.Title;
         
                _context.SaveChanges();
            }

            return existingCategory;
        }
    }
}
