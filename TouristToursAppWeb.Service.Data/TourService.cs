using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TouristToursAppWeb.Service.Data.Interfaces;
using TouristToursAppWeb.Web.ViewModel;

namespace TouristToursAppWeb.Service.Data
{
    public class TourService : ITourService
    {
        public Task CreateTour(TourCreateViewModel viewModel, string userId, int locationId)
        {
            throw new NotImplementedException();
        }
    }
}
