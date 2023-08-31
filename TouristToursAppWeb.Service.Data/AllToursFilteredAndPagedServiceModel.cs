using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TouristToursAppWeb.Web.ViewModel;

namespace TouristToursAppWeb.Service.Data
{
    public class AllToursFilteredAndPagedServiceModel
    {
        public AllToursFilteredAndPagedServiceModel()
        {
            this.Tours = new List<TourAllViewModel>();
        }
        public int TotalTourCount { get; set; }

        public List<TourAllViewModel> Tours { get; set; }
    }
}
