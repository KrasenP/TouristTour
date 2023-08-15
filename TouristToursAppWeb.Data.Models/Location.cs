using System;
using System.ComponentModel.DataAnnotations;

using static TouristToursAppWeb.Common.EntityValidationConstants.Location;


namespace TouristToursAppWeb.Data.Models
{
    public class Location
    {
        public Location()
        {
            this.Tours = new List<Tour>();
        }
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(LocationPlaceMaxLength)]
        public string Country { get; set; }

        [Required]
        [MaxLength(LocationPlaceMaxLength)]
        public string City { get; set; }


        public virtual List<Tour> Tours { get; set; }
    }
}
