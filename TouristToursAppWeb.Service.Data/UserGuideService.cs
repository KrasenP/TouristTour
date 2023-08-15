using Microsoft.EntityFrameworkCore;
using TouristToursAppWeb.Data;
using TouristToursAppWeb.Data.Models;
using TouristToursAppWeb.Service.Data.Interfaces;
using TouristToursAppWeb.Web.ViewModel;

namespace TouristToursAppWeb.Service.Data
{
    public class UserGuideService : IUserGuideService
    {
        private readonly TouristToursAppWebDbContext _dbContext;
        public UserGuideService(TouristToursAppWebDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task CreateGuide(string userId, BecomeUserGuideFormVIewModel viewModel)
        {
            UserGuide uG = new UserGuide()
            {
                Name = viewModel.Name,
                LegalFirmName = viewModel.LegalFirmName,
                ValueAddedTaxIdentificationNumber = viewModel.ValueAddedTaxIdentificationNumber,
                CompanyRegistrationNumber = viewModel.CompanyRegistrationNumber,
                Email = viewModel.Email,
                RegisteredAddress = viewModel.RegisteredAddress,
                AboutTheActivityProvider = viewModel.AboutTheActivityProvider,
                GuideId = Guid.Parse(userId)
            };
            await _dbContext.UserGuides.AddAsync(uG);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<bool> UserGuideByUserId(string userId)
        {
            UserGuide? apU = await _dbContext.UserGuides.Where(x => x.GuideId.ToString() == userId).FirstOrDefaultAsync();

            if (apU == null)
            {
                return false;
            }

            return true;
        }

        public async Task<bool> UserGuideExistByEmail(string email)
        {
            bool isExistEmail = await _dbContext.UserGuides.AnyAsync(x => x.Email == email);

            return isExistEmail;
        }

        public async Task<bool> UserGuideExistByLegalFirmName(string legalFirmName)
        {
            bool isExistSameFirmName = await _dbContext.UserGuides.AnyAsync(x => x.LegalFirmName == legalFirmName);

            return isExistSameFirmName;
        }
    }
}
