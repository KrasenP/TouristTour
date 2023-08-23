using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TouristToursAppWeb.Data.Models;
using TouristToursAppWeb.Web.ViewModel;

namespace TouristToursAppWeb.Service.Data.Interfaces
{
    public interface ILocationService
    {
        Task<LocationViewModel?> LocationManager(string country, string city);

        Task<Location> getNewLocation(LocationViewModel newLocation);
    }
}
