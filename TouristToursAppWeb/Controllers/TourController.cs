using Microsoft.AspNetCore.Mvc;
using TouristToursAppWeb.Service.Data.Interfaces;
using TouristToursAppWeb.Web.ViewModel;

namespace TouristToursAppWeb.Controllers
{
    public class TourController : BaseController
    {
        private readonly ICategoryService _categoryService;

        public TourController(ICategoryService categoryService)
        {
            _categoryService=categoryService;
        }

        public async Task<IActionResult> Create() 
        {
            var getAllCategory = await _categoryService.GetAllCategory();
            TourCreateViewModel t = new TourCreateViewModel()
            {
                Categories = getAllCategory
            };
            return View(t);

        }
    }
}
