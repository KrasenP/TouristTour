using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TouristToursAppWeb.Web.ViewModel
{
    public class TourAddPictureViewModel
    {
        public Guid TourId { get; set; } 
        public List<IFormFile> Images { get; set; }
    }
}
