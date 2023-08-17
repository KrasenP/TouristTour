using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TouristToursAppWeb.Web.ViewModel
{
    public class TourImageViewModel
    {
        public Guid Id { get; set; } 
        public string FileName { get; set; }

        public string Extensions { get; set; }
    }
}
