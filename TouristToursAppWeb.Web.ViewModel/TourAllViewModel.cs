using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TouristToursAppWeb.Web.ViewModel
{
    public class TourAllViewModel
    {
        public string Id { get; set; }

        [Display(Name ="Tour title")]
        public string Title { get; set; }

        [Display(Name ="Price per person")]
        public decimal PricePerPerson { get; set; }

        [Display(Name ="Location")]
        public string Location { get; set; }
        public TourImageViewModel TourImage { get; set; }


    }
}
