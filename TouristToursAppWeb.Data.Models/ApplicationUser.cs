using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TouristToursAppWeb.Data.Models
{
    public class ApplicationUser: IdentityUser<Guid>
    {
        public ApplicationUser()
        {
            this.AppUserTours = new List<Tour>();
        }

        public virtual List<Tour> AppUserTours { get; set; }
    }
}
