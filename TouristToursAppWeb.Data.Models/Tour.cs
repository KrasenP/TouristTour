using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

using static TouristToursAppWeb.Common.EntityValidationConstants.Tour;


namespace TouristToursAppWeb.Data.Models
{
    public class Tour
    {
        public Tour()
        {
            this.Id = Guid.NewGuid();
            this.ToursImages = new List<TourImages>();
            this.Dates = new List<ToursDatesSet>();
            this.TourBookings = new List<TourBooking>();
        }
        [Key]
        public Guid Id { get; set; }

        [Required]
        [MaxLength(TourTitleMaxLength)]
        public string Title { get; set; }

        [Required]
        [MaxLength(DuarationMaxLength)]
        public string Duaration { get; set; }

        public decimal PricePerPerson { get; set; }

        [Required]
        public string FullDescription { get; set; }

        [Required]
        public string MeetingPoint { get; set; }

        [Required]
        [MaxLength(ImportInformationMaxLenght)]
        public string ImportInformation { get; set; }

        public DateTime CreatedOn { get; set; }


        [ForeignKey(nameof(Location))]
        public int? LocationId { get; set; }

        public Location? Location { get; set; }

        [ForeignKey(nameof(UserGuide))]
        public Guid UserGuideId { get; set; }

        public UserGuide UserGuide { get; set; }

        [ForeignKey(nameof(Category))]
        public int CategoryId { get; set; }

        public virtual Category Category { get; set; }

        public virtual List<TourImages> ToursImages { get; set; }

        public virtual List<ToursDatesSet> Dates { get; set; }

        public virtual List<TourBooking> TourBookings { get; set; }
    }
}
