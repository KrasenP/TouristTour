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
        public Task CreateImage(string tourId, string fileName, string extensions);

        public Task DelatePicture(string imageFile);
    }
}
