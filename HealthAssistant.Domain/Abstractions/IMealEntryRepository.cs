using HealthAssistant.Domain.Entities;

namespace HealthAssistant.Domain.Abstractions
{
    public interface IMealEntryRepository
    {
        Task<MealEntry?> GetMealEntryWithProductsAsync(Guid mealEntryId);
    }
}