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
    public class FoodTrackerRepository:Repository<FoodTracker>,IFoodTrackerRepository 
    {
        public FoodTrackerRepository(HealthAssistantDbContext context):base(context) { }

        public async Task<FoodTracker?> GetByDateAsync(Guid userId, DateTime date)
        {
            return await _context.FoodTrackers
                .Include(f => f.Meals) // Загружаем приемы пищи
                    .ThenInclude(m => m.EntriesProducts) // Загружаем продукты в этих приемах
                        .ThenInclude(mp => mp.Product) // Загружаем сам продукт
                .FirstOrDefaultAsync(f => f.UserId == userId && f.Date.Date == date.Date);
        }

    }
}
