
using System.ComponentModel.DataAnnotations;

using static TouristToursAppWeb.Common.EntityValidationConstants.UserGuide;

namespace TouristToursAppWeb.Web.ViewModel
{
   public class BecomeUserGuideFormVIewModel
    {
        public Guid Id { get; set; }

        [Required]
        [MaxLength(NameMaxLength)]
        [MinLength(NameMinLength)]
        public string Name { get; set; }

        [Required]
        [MaxLength(LegalFirmNameMaxLength)]
        [MinLength(LegalFirmNameMinLength)]
        public string LegalFirmName { get; set; }

        [MaxLength(VATNumberMaxLength)]
        [MinLength(VATNumberMinLength)]
        public string ValueAddedTaxIdentificationNumber { get; set; }

        [MaxLength(CRNLenghtMax)]
        [MinLength(CRNLenghtMin)]
        public string CompanyRegistrationNumber { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [MaxLength(RegisteredAddressMaxLength)]
        [MinLength(RegisteredAddressMinLength)]
        public string RegisteredAddress { get; set; }



        [Required]
        [MaxLength(AboutMaxLength)]
        public string AboutTheActivityProvider { get; set; }
    }
}
