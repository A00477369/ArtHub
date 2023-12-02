
using ArtHub.dto;
using ArtHub.Models;

namespace ArtHub.Services.ServicesImpl
{
    public class CategoryServiceImpl : CategoryService
    {
        private readonly IServiceScopeFactory _scopeFactory;

        public CategoryServiceImpl(IServiceScopeFactory scopeFactory)
        {
            _scopeFactory = scopeFactory;
        }

        public Category CreateCategory(Category category)
        {
            using (var scope = _scopeFactory.CreateScope())
            {
                var context = scope.ServiceProvider.GetRequiredService<AppDbContext>();

                Console.WriteLine($"Before adding to DbContext - Id: {category.Id}, Title: {category.Title}, CreatedOn: {category.CreatedOn}, CreatedBy: {category.CreatedBy}");
                context.Category.Add(category);
                Console.WriteLine($"After adding to DbContext - Id: {category.Id}, Title: {category.Title}, CreatedOn: {category.CreatedOn}, CreatedBy: {category.CreatedBy}");

                context.SaveChanges();
                Console.WriteLine($"After adding to DbContext - Id: {category.Id}, Title: {category.Title}, CreatedOn: {category.CreatedOn}, CreatedBy: {category.CreatedBy}");

                return category;
            }
        }

        public List<Category> GetAllCategories()
        {
            using (var scope = _scopeFactory.CreateScope())
            {
                var context = scope.ServiceProvider.GetRequiredService<AppDbContext>();

                List<Category> categoryList = context.Category.ToList();
                return categoryList;
            }
        }
        public Category GetCategoryById(int id)
        {
            throw new NotImplementedException();
        }

        public Category UpdateCategory(UpdateCategoryDto dto, Category existingCategory)
        {
            throw new NotImplementedException();
        }
    }
}
    
