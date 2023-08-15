using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TouristToursAppWeb.Data.Models
{
    public class TourImages
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string FileName { get; set; }

        [ForeignKey(nameof(Tour))]
        public Guid TourId { get; set; }

        public Tour Tour { get; set; }

        [Required]
        public string Extensions { get; set; }
    }
}
