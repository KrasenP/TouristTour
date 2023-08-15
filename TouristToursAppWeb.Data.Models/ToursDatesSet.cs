using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TouristToursAppWeb.Data.Models
{
    public class ToursDatesSet
    {
        [ForeignKey(nameof(TourId))]
        public Guid TourId { get; set; }
        public virtual Tour Tour { get; set; }

        [ForeignKey(nameof(DateSet))]
        public int DateSetId { get; set; }
        public DateSet DateSet { get; set; }
    }
}
