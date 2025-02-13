using HealthAssistant.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthAssistant.Domain.Entities
{//это прием пищи(завтрак,..) здесь список употребленных продуктов 
    public class MealEntry:Entity
    {
        public Guid FoodTrackerId { get; set; } // ID дневного трекера
        public FoodTracker? FoodTracker { get; set; }
        public MealType Type { get; set; } 
        public List<MealEntryProduct> EntriesProducts { get; set; } = []; // Список продуктов
        public double TotalCalories => EntriesProducts.Sum(p => p.Calories);
        public double TotalProteins => EntriesProducts.Sum(p => p.Proteins);
        public double TotalFats => EntriesProducts.Sum(p => p.Fats);
        public double TotalCarbs => EntriesProducts.Sum(p => p.Carbs);
        public double TotalFiber => EntriesProducts.Sum(p => p.Fiber);
        public double TotalSugar => EntriesProducts.Sum(p => p.Sugar);
    }
}
