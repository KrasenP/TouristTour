using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using TouristToursAppWeb.Data;
using TouristToursAppWeb.Data.Models;
using TouristToursAppWeb.Service.Data.Interfaces;
using TouristToursAppWeb.Web.ViewModel;
using static TouristToursAppWeb.Common.EntityValidationConstants;

namespace TouristToursAppWeb.Service.Data
{
    public class TourService : ITourService
    {
        private readonly TouristToursAppWebDbContext _dbContext;
        public TourService(TouristToursAppWebDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<TourDetailsViewModel> GetTourById(Guid tourId)
        {
            var tourById = await _dbContext.Tours.Include(x => x.ToursImages).FirstOrDefaultAsync();

            if (tourById==null)
            {
                return null;
            }

            var viewModel = new TourDetailsViewModel
            {
                Id = tourById.Id,
                Title = tourById.Title,
                Duration = tourById.Duaration,
                Images = tourById.ToursImages.Select(img => new TourImageViewModel
                {
                    FileName = img.FileName,
                    Extensions = img.Extensions
                }).ToList()
            };
            return viewModel;
        }

        public async Task CreateTour(TourCreateViewModel viewModel, Guid userGuideId, int locationId)
        {
            bool t = await _dbContext.Tours.Where(x => x.Title == viewModel.Title).AnyAsync();

            if (t==true)
            {
                throw new NotImplementedException("Somthing when wrong");
            }


            TouristToursAppWeb.Data.Models.Tour newTour = new TouristToursAppWeb.Data.Models.Tour()
            {
                Title = viewModel.Title,
                Duaration = viewModel.Duaration,
                MeetingPoint = viewModel.MeetingPoint,
                ImportInformation = viewModel.ImportInformation,
                LocationId = locationId,
                PricePerPerson = viewModel.PricePerPerson,
                CategoryId = viewModel.CategoryId,
                FullDescription = viewModel.FullDescription,
                UserGuideId = userGuideId
            };

            await _dbContext.Tours.AddAsync(newTour);
            await _dbContext.SaveChangesAsync();
          
        }

       
    }
}
