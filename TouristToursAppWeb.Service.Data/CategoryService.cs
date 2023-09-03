using Microsoft.EntityFrameworkCore;

using TouristToursAppWeb.Data;
using TouristToursAppWeb.Data.Models;
using TouristToursAppWeb.Service.Data.Interfaces;
using TouristToursAppWeb.Web.ViewModel;

namespace TouristToursAppWeb.Service.Data
{
    public class CategoryService : ICategoryService
    {
        private readonly TouristToursAppWebDbContext _dbContext;

        public CategoryService(TouristToursAppWebDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<string>> AllCategoryNameAsync()
        {
           List<string> list = await _dbContext
                .Categories
                .Select(n=>n.Name)
                .ToListAsync();

            return list;
        }

        public async Task<List<CategoryFromViewModel>> GetAllCategory()
        {
            List<CategoryFromViewModel> categories = await _dbContext.Categories.AsNoTracking().
               Select(c => new CategoryFromViewModel()
               {
                   Id = c.Id,
                   Name = c.Name

               }).ToListAsync();

            return categories;
        }



     
    }
}
