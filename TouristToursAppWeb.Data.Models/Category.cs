using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using static TouristToursAppWeb.Common.EntityValidationConstants.Category;

namespace TouristToursAppWeb.Data.Models
{
   public class Category
    {
        public Category()
        {
            this.Tours = new List<Tour>();
        }
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(25)]
        public string Name { get; set; } = null!;

        public virtual List<Tour> Tours { get; set; }
    }
}
