using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TouristToursAppWeb.Web.ViewModel;

namespace TouristToursAppWeb.Service.Data.Interfaces
{
    public interface IUserGuideService
    {
        Task<bool> UserGuideByUserId(string userId);

        Task CreateGuide(string userId, BecomeUserGuideFormVIewModel viewModel);

        Task<bool> UserGuideExistByLegalFirmName(string legalFirmName);

        Task<bool> UserGuideExistByEmail(string email);
    }
}
