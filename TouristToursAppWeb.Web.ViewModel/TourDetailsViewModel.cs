using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TouristToursAppWeb.Web.ViewModel
{
    public class TourDetailsViewModel
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Duration { get; set; }
        public List<TourImageViewModel> Images { get; set; }
    }
}
