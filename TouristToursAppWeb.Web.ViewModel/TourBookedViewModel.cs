using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TouristToursAppWeb.Web.ViewModel
{
   public class TourBookedViewModel
    {
        public Guid Id { get; set; }

        public DateTime BookedDate { get; set; }
   
        public int CountOfPeople { get; set; }

        public string Email { get; set; }

        public string BookingUserPhoneNumber { get; set; }

        public string TourName { get; set; }

        public string BookingUserName { get; set; }

       public bool Actions { get; set; }


    }
}
