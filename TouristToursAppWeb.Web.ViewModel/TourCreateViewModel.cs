using System.ComponentModel.DataAnnotations;

using static TouristToursAppWeb.Common.EntityValidationConstants.Tour;
using static TouristToursAppWeb.Common.EntityValidationConstants.Location;


namespace TouristToursAppWeb.Web.ViewModel
{
    public class TourCreateViewModel
    {
        public TourCreateViewModel()
        {

        }

        [Required]
        [MaxLength(TourTitleMaxLength)]
        [MinLength(TourTitleMinLength)]
        [Display(Name = "Tour title")]
        public string Title { get; set; }

        [Required]
        [MaxLength(DuarationMaxLength)]
        [MinLength(DuarationMinLength)]
        [Display(Name = "Duaration of trip")]
        public string Duaration { get; set; }

        [Display(Name = "Price per person")]
        [Range(typeof(decimal), PricePerPersonMin, PricePerPersonMax)]
        public decimal PricePerPerson { get; set; }

        [Required]
        [Display(Name = "Full description for the trip")]
        public string FullDescription { get; set; }

        [Required]
        [Display(Name = "Location for the meeting")]
        public string MeetingPoint { get; set; }

        [Required]
        [MaxLength(ImportInformationMaxLenght)]
        [MinLength(ImportInformationMinLenght)]
        [Display(Name = "Import Information")]
        public string ImportInformation { get; set; }

        [Required]
        [MaxLength(LocationPlaceMaxLength)]
        [MinLength(LocationPlaceMinLength)]
        [Display(Name = "Location city")]
        public string LocationCity { get; set; }

        [Required]
        [MaxLength(LocationPlaceMaxLength)]
        [MinLength(LocationPlaceMinLength)]
        [Display(Name = "Location Country")]
        public string LocationCountry { get; set; }

        [MaxLength(LocationPlaceMaxLength)]
        [MinLength(LocationPlaceMinLength)]
        [Display(Name = "Location village")]
        public string LocationVillage { get; set; }


        public int CategoryId { get; set; }

        public List<CategoryFromViewModel> Categories { get; set; } = new List<CategoryFromViewModel>();
    }
}
