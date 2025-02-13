using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthAssistant.Domain.Entities
{//трекер для каждого дня получается ? тут все приемы пищи с рассчитаннымим в итоге кбжу
    public class FoodTracker:Entity
    {
        public Guid UserId { get; set; }
        public User? User { get; set; }
        public DateTime Date { get; set; }
        public List<MealEntry> Meals { get; set; } = [];
        // Подсчет общей дневной статистики
        public double TotalCalories => Meals.Sum(m => m.TotalCalories);
        public double TotalProteins => Meals.Sum(m => m.TotalProteins);
        public double TotalFats => Meals.Sum(m => m.TotalFats);
        public double TotalCarbs => Meals.Sum(m => m.TotalCarbs);
        public double TotalFiber => Meals.Sum(m => m.TotalFiber);
        public double TotalSugar => Meals.Sum(m => m.TotalSugar);
    }
}
