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
    public class TouristDatesSetConfig : IEntityTypeConfiguration<ToursDatesSet>
    {
        public void Configure(EntityTypeBuilder<ToursDatesSet> builder)
        {
            builder.HasKey(x => new { x.TourId, x.DateSetId });
        }
    }
}
