using Microsoft.AspNetCore.Mvc;
using TouristToursAppWeb.Web.ViewModel;

namespace TouristToursAppWeb.Controllers
{
    public class TourBookingController : BaseController
    {
        [HttpGet]
        public IActionResult MakeBooking()
        {
            var model =  new TourBokingFormViewModel();
            return View(model);
        }


    }
}
