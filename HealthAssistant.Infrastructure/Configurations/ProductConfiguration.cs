﻿using HealthAssistant.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthAssistant.Infrastructure.Configurations
{
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.HasKey(x => x.Id);

            builder.HasMany(x=>x.MealEntries)
                .WithOne(x => x.Product)
                .HasForeignKey(x => x.MealEntryId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
