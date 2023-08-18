using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MongoDB.Driver;
using TouristToursAppWeb.Data.Models;
using TouristToursAppWeb.Data.Models.MongoDbModel;
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
        private readonly IImageService _imageService;
 
        private readonly IMongoCollection<ImageFile> _imageFileCollection;
        private readonly IWebHostEnvironment _environment;

        

        private readonly string[] allowedExtensions = new[] { "jpg", "png", "gif", "PNG" };

        public TourController(ICategoryService categoryService,ITourService tourService,
            ILocationService locationService, IUserGuideService userGuideService, 
            IWebHostEnvironment environment,IImageService imageService,IMongoDatabase mongoDatabase)
        {
            _categoryService = categoryService;
            _tourService = tourService;
            _locationService = locationService;
            _userGuideService = userGuideService;
            _environment = environment;
            _imageService = imageService;
            _imageFileCollection = mongoDatabase.GetCollection<ImageFile>("TouristTourAppMDB");

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

        public async Task<IActionResult> Details(string Id)
        {
            var tour = await _tourService.GetTourById(Id);
            if (tour == null)
            {
                return NotFound();
            }
           
            return View(tour);
        }
    
        [HttpPost]
        public async Task<IActionResult> AddImageToTour(string tourId, IFormFile file)
        {
            var tour = await _tourService.GetTourById(tourId);

            if (tour == null)
            {
                return NotFound();
            }

            if (file != null && file.Length > 0)
            {
                var fileName = $"{Guid.NewGuid()}{Path.GetExtension(file.FileName)}";
                var extension = Path.GetExtension(file.FileName).TrimStart('.');

                if (!allowedExtensions.Any(x => extension.EndsWith(x)))
                {
                    return BadRequest("Invalid image extension");
                }

                using (var memoryStream = new MemoryStream())
                {
                    await file.CopyToAsync(memoryStream);

                    var imageFile = new ImageFile
                    {
                        FileName = fileName,
                        Extensions = extension,
                        ImageData = memoryStream.ToArray(),
                        TourId = tourId.ToString()
                    };

                    await _imageFileCollection.InsertOneAsync(imageFile);

                    await _imageService.CreateImage(tourId, imageFile.FileName, imageFile.Extensions);
                   
                }
            }

            return RedirectToAction("Details", new { id = tourId });
        }


        public async Task<IActionResult> GetImage(string fileName)
        {
            var imageFile = await _imageFileCollection.Find(x => x.FileName == fileName).FirstOrDefaultAsync();

            if (imageFile == null || imageFile.ImageData == null)
            {
                return NotFound();
            }

            return File(imageFile.ImageData, $"image/{imageFile.Extensions}");
        }



    }
}
