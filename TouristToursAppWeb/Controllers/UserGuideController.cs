using Microsoft.AspNetCore.Mvc;
using TouristToursAppWeb.Service.Data.Interfaces;
using TouristToursAppWeb.Web.Infrastructure;
using TouristToursAppWeb.Web.ViewModel;
using static TouristToursAppWeb.Common.NotificationMessage;

namespace TouristToursAppWeb.Controllers
{
    public class UserGuideController : BaseController
    {
        private readonly IUserGuideService _userGuideService;

        public UserGuideController(IUserGuideService userGuideService)
        {
            _userGuideService = userGuideService;
        }

        [HttpGet]
        public async Task<IActionResult> BecomeGuide()
        {
            string currentLoadedUser = this.User.GetCurrentUserId();

            bool isUserGuide = await _userGuideService.UserGuideByUserId(currentLoadedUser);
            if (isUserGuide == true)
            {
                TempData[ErrorMassage] = "You are alredy an tourist Guide";

                return RedirectToAction("Index", "Home");
            }

            return View();
        }

        public async Task<IActionResult> BecomeGuide(BecomeUserGuideFormVIewModel viewModel)
        {
            var userId = this.User.GetCurrentUserId();
            if (ModelState.IsValid == false)
            {
                return View(viewModel);
            }

            if (await _userGuideService.UserGuideExistByEmail(viewModel.Email))
            {
                TempData[ErrorMassage] = "Email address already exist";

                return View(viewModel);
            }

            if (await _userGuideService.UserGuideExistByLegalFirmName(viewModel.LegalFirmName))
            {
                TempData[ErrorMassage] = "This travel guide or travel firm alredy exist";

                return View(viewModel);
            }

            await _userGuideService.CreateGuide(userId, viewModel);

            if (await _userGuideService.UserGuideByUserId(userId))
            {
                TempData[SuccessMassage] = "You have successfully become a tour guide";
            }

            return RedirectToAction("Index", "Home");


        }
    }
}
