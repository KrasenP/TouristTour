using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TouristToursAppWeb.Data.Models;

namespace TouristToursAppWeb.Data.Configuration
{
    public class TourEntityConfig : IEntityTypeConfiguration<Tour>
    {
        public void Configure(EntityTypeBuilder<Tour> builder)
        {
            builder.Property(c => c.CreatedOn)
               .HasDefaultValue(DateTime.UtcNow);

            
        }
    }
}
