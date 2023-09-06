using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MongoDB.Driver;
using TouristToursAppWeb.Data;
using TouristToursAppWeb.Data.Models;
using TouristToursAppWeb.Data.Models.MongoDbModel;
using TouristToursAppWeb.Service.Data.Interfaces;
using TouristToursAppWeb.Web.ViewModel;

using static TouristToursAppWeb.Web.Infrastructure.ClaimPrincipalExtensions;
using static TouristToursAppWeb.Common.NotificationMessage;
using Microsoft.AspNetCore.Authorization;
using TouristToursAppWeb.Service.Data;
using MongoDB.Bson;

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

        private readonly TouristToursAppWebDbContext _dbContext;
      
        /// <summary>
        /// TODO remove _dbContext from DeleteTour DeletePicture and add service for operation DeleteTour and DeletePicture
        /// </summary>

        

        private readonly string[] allowedExtensions = new[] { "jpg", "png", "gif", "PNG" };

        public TourController(ICategoryService categoryService,ITourService tourService,
            ILocationService locationService, IUserGuideService userGuideService, 
            IWebHostEnvironment environment,IImageService imageService,IMongoDatabase mongoDatabase,
            TouristToursAppWebDbContext touristToursAppWebDbContext)
        {
            _categoryService = categoryService;
            _tourService = tourService;
            _locationService = locationService;
            _userGuideService = userGuideService;
            _environment = environment;
            _imageService = imageService;
            _imageFileCollection = mongoDatabase.GetCollection<ImageFile>("TouristTourAppMDB");
            _dbContext = touristToursAppWebDbContext;

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

                TempData[WarningMassage] = "Tour not exist or has been deleted";
                return RedirectToAction("Index","Home");
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
        [HttpGet]
        public async Task<IActionResult> Edit(string Id) 
        {
            var categories = await _categoryService.GetAllCategory();
            var model = await _tourService.GetTourForEdit(Id,categories);
            

            return View(model);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(TourCreateViewModel viewModel)
        {
            var gategories = _categoryService.GetAllCategory();
           
            var getTourLocation = await _locationService.LocationManager(viewModel.LocationCountry, viewModel.LocationCity);
            var getNewLocation = await _locationService.getNewLocation(getTourLocation);

            viewModel.Categories = await _categoryService.GetAllCategory();
            await _tourService.EditTour(viewModel,getNewLocation);


            return RedirectToAction("Index", "Home"); 
        }

        [HttpPost]
        public async Task<IActionResult> DelatePicture(string fileName, Guid tourId) 

        {
            //var tour = await _dbContext.Tours.Include(x=>x.ToursImages).FirstOrDefaultAsync(x=>x.Id == tourId);
            // var image = tour.ToursImages.FirstOrDefault(x => x.FileName == fileName);


            // add service for this : 
            //var imageForDelete = await _dbContext.ToursImages.Where(x => x.FileName == fileName).FirstOrDefaultAsync();

            // _dbContext.ToursImages.Remove(imageForDelete);
            //await _dbContext.SaveChangesAsync();

            await _imageService.DelatePicture(fileName);

            var filter = Builders<ImageFile>.Filter.Eq("FileName", fileName);
            await _imageFileCollection.DeleteOneAsync(filter);
            return   Content("success");
        }
        [HttpPost]
        public async Task<IActionResult> DeleteTour(string tourId) 
        {
            var deletePictures = await _dbContext.ToursImages.Where(x => x.TourId.ToString() == tourId).ToListAsync();

            foreach (var picture in deletePictures)
            {
                var mongoDbFilter = Builders<ImageFile>.Filter.Eq("FileName", picture.FileName);
                await  _imageFileCollection.DeleteOneAsync(mongoDbFilter);
            }

             _dbContext.ToursImages.RemoveRange(deletePictures);

            var deleteTour = await _dbContext.Tours.Where(x => x.Id.ToString() == tourId).FirstOrDefaultAsync();
            _dbContext.Tours.Remove(deleteTour);



            await _dbContext.SaveChangesAsync();

            return RedirectToAction("All","Tour");
        }

        // ako nqma tuka allowanonyous to tam kudto ima vizualizaciq na snimka nqma da mojesh da e vidish dokato ne se loginesh 
        [AllowAnonymous]
        public async Task<IActionResult> GetImage(string fileName)
        {
            var imageFile = await _imageFileCollection.Find(x => x.FileName == fileName).FirstOrDefaultAsync();

            if (imageFile == null || imageFile.ImageData == null)
            {
                return NotFound();
            }

            return File(imageFile.ImageData, $"image/{imageFile.Extensions}");
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> All([FromQuery]AllTourQueryModel queryModel) 
        {
            AllToursFilteredAndPagedServiceModel serviceModel = await _tourService.AllAsync(queryModel);

            queryModel.Tours = serviceModel.Tours;
          
            queryModel.Categories = await _categoryService.AllCategoryNameAsync();

            return View(queryModel);
        }



    }
}
