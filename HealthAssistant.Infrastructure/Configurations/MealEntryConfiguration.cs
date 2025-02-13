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
    public class MealEntryConfiguration: IEntityTypeConfiguration<MealEntry>

    {
        public void Configure(EntityTypeBuilder<MealEntry> builder)
        {
            builder.HasKey(x => x.Id);

            builder.HasMany(x => x.EntriesProducts)
                .WithOne(x => x.MealEntry)
                .HasForeignKey(x => x.ProductId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(f => f.FoodTracker)
                .WithMany(m => m.Meals)
                .HasForeignKey(k => k.FoodTrackerId);
                

        }
    }
}
