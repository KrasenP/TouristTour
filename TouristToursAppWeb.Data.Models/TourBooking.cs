using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TouristToursAppWeb.Data.Models
{
    public class TourBooking
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        public DateTime BookedDate { get; set; }


        public int CountOfPeople { get; set; }


        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        public string PhoneNumber { get; set; }


        [ForeignKey(nameof(AppUser))]
        public Guid AppUserId { get; set; }
        public ApplicationUser AppUser { get; set; }

        [ForeignKey(nameof(Tour))]
        public Guid? TourId { get; set; }
        public  Tour? Tour { get; set; }

        public bool IsBooked { get; set; }

        public bool IsRefused { get; set; }
    }
}
