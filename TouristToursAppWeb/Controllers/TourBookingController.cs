using Microsoft.AspNetCore.Mvc;
using TouristToursAppWeb.Service.Data;
using TouristToursAppWeb.Service.Data.Interfaces;
using TouristToursAppWeb.Web.ViewModel;
using static TouristToursAppWeb.Web.Infrastructure.ClaimPrincipalExtensions;
using static TouristToursAppWeb.Common.NotificationMessage;

namespace TouristToursAppWeb.Controllers
{
    public class TourBookingController : BaseController
    {
        private readonly ITourBookingService _tourBookingService; 

        public TourBookingController(ITourBookingService tourBookingService)
        {
            _tourBookingService = tourBookingService;
        }
   
        public IActionResult MakeBooking(string tourId)
        {
            var model = new TourBokingFormViewModel()
            {
                TourId = Guid.Parse(tourId)
            };
            return View(model);
        }
        [HttpPost]
        public async Task<IActionResult> MakeBooking(TourBokingFormViewModel viewModel) 
        {
            if (ModelState.IsValid==false)
            {
                return View(viewModel);
            }

            var currentUser = this.User.GetCurrentUserId();
            await _tourBookingService.MakeBooking(viewModel,currentUser);
          

            return RedirectToAction("Index", "Home");


        }


    }
}
