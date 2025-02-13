using HealthAssistant.Domain.Abstractions;
using HealthAssistant.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthAssistant.Infrastructure.Repositories
{
    public class MealEntryRepository: Repository<MealEntry>, IMealEntryRepository
    {
        public MealEntryRepository(HealthAssistantDbContext context) : base(context) { }

        public async Task<MealEntry?> GetMealEntryWithProductsAsync(Guid mealEntryId)
        {
            return await _context.Meals
                                 .Include(m => m.EntriesProducts) // Загружаем MealEntryProduct
                                 .ThenInclude(mp => mp.Product) // Загружаем сам продукт
                                 .FirstOrDefaultAsync(m => m.Id == mealEntryId);
        }
    }
}
