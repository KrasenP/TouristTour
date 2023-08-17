using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TouristToursAppWeb.Web.ViewModel;

namespace TouristToursAppWeb.Service.Data.Interfaces
{
   public interface ITourService
    {
        Task CreateTour(TourCreateViewModel viewModel, Guid userGuideId, int locationId);

        Task<TourDetailsViewModel> GetTourById(Guid tourId);


    }
}
