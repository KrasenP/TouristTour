using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TouristToursAppWeb.Web.ViewModel.Enum;

namespace TouristToursAppWeb.Web.ViewModel
{
    public class AllTourQueryModel
    {
        public AllTourQueryModel()
        {

            this.Categories = new List<string>();
            this.Tours = new List<TourAllViewModel>();
        }
        public string? Category { get; set; }

        [Display(Name = "Serching by word")]
        public string? SerchByString { get; set; }

        [Display(Name ="Sort tour by")]
        public TourSorting TourSorting { get; set; }

        public int CurrentPage { get; set; } = 1;

        public int TourPerPage { get; set; } = 3;

        public List<string> Categories { get; set; }

        public List<TourAllViewModel> Tours { get; set; }


    }
}
