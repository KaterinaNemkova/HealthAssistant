using HealthAssistant.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthAssistant.Infrastructure.Configurations
{
    public class FoodTrackerConfiguration: IEntityTypeConfiguration<FoodTracker>
    {
        public void Configure(EntityTypeBuilder<FoodTracker> builder)
        {
            builder.HasKey(x => x.Id);

            builder.HasOne(x => x.User)
                .WithMany(x => x.FoodTrackers)
                .HasForeignKey(x => x.UserId);

            builder.HasMany(x=>x.Meals)
                .WithOne(x=>x.FoodTracker)
                .HasForeignKey(x=>x.FoodTrackerId)
                .OnDelete(DeleteBehavior.Cascade);
              
        }
    }
}
