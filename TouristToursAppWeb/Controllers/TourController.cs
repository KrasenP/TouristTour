using Microsoft.AspNetCore.Mvc;
using TouristToursAppWeb.Service.Data.Interfaces;
using TouristToursAppWeb.Web.ViewModel;

using static TouristToursAppWeb.Web.Infrastructure.ClaimPrincipalExtensions;

namespace TouristToursAppWeb.Controllers
{
    public class TourController : BaseController
    {
        private readonly ICategoryService _categoryService;
        private readonly ITourService _tourService;
        private readonly ILocationService _locationService;
        private readonly IUserGuideService _userGuideService;

        public TourController(ICategoryService categoryService,ITourService tourService,ILocationService locationService,IUserGuideService userGuideService)
        {
            _categoryService=categoryService;
            _tourService = tourService;
            _locationService=locationService;
            _userGuideService = userGuideService;
        }

        [HttpGet]
        public async Task<IActionResult> Create() 
        {
            var getAllCategory = await _categoryService.GetAllCategory();
            TourCreateViewModel t = new TourCreateViewModel()
            {
                Categories = getAllCategory
            };
            return View(t);

        }

        [HttpPost]
        public async Task<IActionResult> Create(TourCreateViewModel tourCreateViewModel)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

            var getLocation = await _locationService.LocationManager(tourCreateViewModel.LocationCountry, tourCreateViewModel.LocationCity);

            var currentuserId = this.User.GetCurrentUserId();
            var guideUserId = await _userGuideService.TakeUserGuide(currentuserId);

            await _tourService.CreateTour(tourCreateViewModel, guideUserId.Id, getLocation.Id);

          

            return RedirectToAction("Index", "Home");

        }


    }
}
