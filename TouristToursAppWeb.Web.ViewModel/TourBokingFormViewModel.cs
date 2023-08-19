using System.ComponentModel.DataAnnotations;

using static TouristToursAppWeb.Common.EntityValidationConstants.TourBooking;

namespace TouristToursAppWeb.Web.ViewModel
{
    public class TourBokingFormViewModel
    {
        public Guid Id { get; set; }

        [Required]
        public DateTime BookedDate { get; set; }

        [Required]
        [Range(1,50)]
        public int CountOfPeople { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [RegularExpression(@"[+]*[(]{0,1}[0-9]{1,4}[)]{0,1}[-\\s\\./0-9]*$")]
        public string PhoneNumber { get; set; }

        public Guid TourId { get; set; }

        public Guid BookingUserId { get; set; }
    }
}
