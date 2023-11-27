using System;
using ArtHub.dto;
using ArtHub.Models;
using ArtHub.Services;
using Microsoft.AspNetCore.Mvc;

namespace ArtHub.Controllers
{

    [ApiController]
    [Route("[controller]")]
    public class CategoryController : ControllerBase
	{
        private readonly CategoryService _categoryService;

        public CategoryController(CategoryService categoryService)
		{
            _categoryService = categoryService;
		}


        [HttpPost]
        public ActionResult CreateCategory([FromBody] CreateCategoryDto dto)
        {
            if (dto == null)
            {
                return BadRequest("Invalid category data");
            }

            Category category = new Category(1, dto.Title, DateTime.Now, dto.CreatedBy);

            category = _categoryService.CreateCategory(category);
            return Ok(category);
        }

        [HttpGet("{id:int}")]
        public ActionResult GetCategoryById(int id)
        {
            Category category = _categoryService.GetCategoryById(id);

            if (category == null)
            {
                return NotFound();
            }

            return Ok(category);
        }

        [HttpGet]
        public ActionResult GetAllCategories()
        {
            List<Category> categories = _categoryService.GetAllCategories();

            return Ok(categories);
        }

        [HttpPut]
        public ActionResult UpdateCategory([FromBody] UpdateCategoryDto dto)
        {
            if (dto == null)
            {
                return BadRequest("Invalid category data");
            }

            Category existingCategory = _categoryService.GetCategoryById(dto.Id);

            if (existingCategory == null)
            {
                return NotFound("Category not found");
            }

            Category updatedCategory = _categoryService.UpdateCategory(dto, existingCategory);

            return Ok(updatedCategory);
        }
    }
}

