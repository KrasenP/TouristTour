using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

using static TouristToursAppWeb.Common.EntityValidationConstants.UserGuide;

namespace TouristToursAppWeb.Data.Models
{
    public class UserGuide
    {
        public UserGuide()
        {
            this.MyTours = new List<Tour>();
        }
        [Key]
        public Guid Id { get; set; }

        [Required]
        [MaxLength(NameMaxLength)]
        public string Name { get; set; }

        [Required]
        [MaxLength(LegalFirmNameMaxLength)]
        public string LegalFirmName { get; set; }

        [MaxLength(VATNumberMaxLength)]
        public string? ValueAddedTaxIdentificationNumber { get; set; }

        [MaxLength(CRNLenghtMax)]
        public string? CompanyRegistrationNumber { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [MaxLength(RegisteredAddressMaxLength)]
        public string RegisteredAddress { get; set; }

        [ForeignKey(nameof(Guide))]
        public Guid GuideId { get; set; }

        public virtual ApplicationUser Guide { get; set; }

        [Required]
        [MaxLength(AboutMaxLength)]
        public string AboutTheActivityProvider { get; set; }

        public virtual List<Tour> MyTours { get; set; }
    }
}
