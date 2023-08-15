using System.ComponentModel.DataAnnotations;

using static TouristToursAppWeb.Common.EntityValidationConstants.Location;
namespace TouristToursAppWeb.Web.ViewModel
{
    public class LocationViewModel
    {
        public int Id { get; set; }

        [Required]

        [MaxLength(LocationPlaceMaxLength)]
        [MinLength(LocationPlaceMinLength)]
        public string Country { get; set; }

        [Required]

        [MaxLength(LocationPlaceMaxLength)]
        [MinLength(LocationPlaceMinLength)]
        public string City { get; set; }

        [MaxLength(LocationPlaceMaxLength)]
        [MinLength(LocationPlaceMinLength)]
        public string? Village { get; set; }

    }
}
