using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthAssistant.Domain.Entities
{//это класс с именно продуктом, который мы съели, его весом и уже рассчитанными кбжу исходя из веса
    public class MealEntryProduct:Entity
    {
        public Guid MealEntryId { get; set; }
        public MealEntry? MealEntry { get; set; }
        public Guid ProductId { get; set; }
        public Product? Product { get; set; }
        public double Weight { get; set; } // Вес в граммах

        // Автоматический расчет калорий и БЖУ на основе веса продукта
        public double Calories => Product != null ? (Product.CaloriesPer100g * Weight / 100) : 0;
        public double Proteins => Product != null ? (Product.ProteinsPer100g * Weight / 100) : 0;
        public double Fats => Product != null ? (Product.FatsPer100g * Weight / 100) : 0;
        public double Carbs => Product != null ? (Product.CarbsPer100g * Weight / 100) : 0;
        public double Fiber => Product != null ? (Product.FiberPer100g * Weight / 100) : 0;
        public double Sugar => Product != null ? (Product.SugarPer100g * Weight / 100) : 0;
    }
}
