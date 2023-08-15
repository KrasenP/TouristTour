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
    public class CategoryConfig : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.HasData(this.CreateCategory());
        }

        private List<Category> CreateCategory()
        {
            List<Category> categories = new List<Category>();

            Category culture = new Category()
            {
                Id = 1,
                Name = "Culture"
            };
            categories.Add(culture);
            Category sports = new Category()
            {
                Id = 2,
                Name = "Sports"
            };
            categories.Add(sports);
            Category nature = new Category()
            {
                Id = 3,
                Name = "Nature"
            };
            categories.Add(nature);
            Category food = new Category()
            {
                Id = 4,
                Name = "Food"
            };

            return categories;

        }
    }
}
