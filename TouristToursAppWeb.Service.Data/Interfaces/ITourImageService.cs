using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TouristToursAppWeb.Service.Data.Interfaces
{
    public interface ITourImageService
    {
        public Task DelatePicture(string imageFile);

    }
}
