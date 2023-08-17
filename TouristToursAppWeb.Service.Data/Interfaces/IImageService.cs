using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TouristToursAppWeb.Web.ViewModel;

namespace TouristToursAppWeb.Service.Data.Interfaces
{
    public interface IImageService
    {
        public Task CreateImage(Guid tourId, string fileName, string extensions);
    }
}
