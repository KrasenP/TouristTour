using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TouristToursAppWeb.Data.Models
{
    public class DateSet
    {
        [Key]
        public int Id { get; set; }

        public DateTime? ToursClosedDate { get; set; }
        public List<ToursDatesSet> ToursDatesSet { get; set; }
    }
}
