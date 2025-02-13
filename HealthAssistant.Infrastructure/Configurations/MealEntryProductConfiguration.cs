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
    public class MealEntryProductConfiguration: IEntityTypeConfiguration<MealEntryProduct>
    {
        public void Configure(EntityTypeBuilder<MealEntryProduct> builder)
        {
            builder.HasKey(p => p.Id);
            //один принимаемый продукт = один продукт, но ожин продукт может встречаться у нескольких принимаемых продуктов
            builder.HasOne(p=>p.Product)
                .WithMany(x=>x.MealEntries)
                .HasForeignKey(x=>x.ProductId);
            //один принимаемый продукт может быть только у одного приема пищи, но у приема пищи может быть несколько принимаемых продуктов
            builder.HasOne(x=>x.MealEntry)
                .WithMany(x=>x.EntriesProducts)
                .HasForeignKey(x=>x.MealEntryId);


        }
    }
}
