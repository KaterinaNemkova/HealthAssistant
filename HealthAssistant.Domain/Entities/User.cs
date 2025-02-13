using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HealthAssistant.Domain.Enums;

namespace HealthAssistant.Domain.Entities
{
    public class User:Entity
    {
        public string Name { get; set; } = string.Empty;
        public SexCategory Sex { get; set; }
        public string Email { get; set; } = string.Empty;
        public double Height { get; set; }
        public double Weight { get; set; }
        public string HashedPassword { get; set; } = string.Empty;
        public DateOnly DateOnly { get; set; }
        public List<Allergy> Allergies { get; set; } = [];
        public List<Intolerance> Intolerances { get; set; } = [];
        public ActivityLevel ActivityLevel { get; set; }
        public double DailyCalories { get; set; }
        public ICollection<FoodTracker> FoodTrackers { get; set; } = [];

        
        public void CalculateDailyCalories()
        {
            int age = DateTime.Now.Year - DateOnly.Year;
            if (DateTime.Now.DayOfYear < DateOnly.DayOfYear) age--;

            // Рассчитываем базовый метаболизм (BMR) по формуле Миффлина-Сан Жеора
            double bmr;
            if (Sex == SexCategory.Male)
            {
                bmr = 10 * Weight + 6.25 * Height - 5 * age + 5;
            }
            else
            {
                bmr = 10 * Weight + 6.25 * Height - 5 * age - 161;
            }

            double activityMultiplier = GetActivityMultiplier(ActivityLevel);
            DailyCalories = bmr * activityMultiplier;
        }

        private static double GetActivityMultiplier(ActivityLevel activityLevel)
        {
            return activityLevel switch
            {
                ActivityLevel.Sedentary => 1.2,       // Минимальная активность
                ActivityLevel.LightlyActive => 1.375, // Легкая активность (1-3 тренировки в неделю)
                ActivityLevel.ModeratelyActive => 1.55, // Умеренная активность (3-5 тренировок в неделю)
                ActivityLevel.VeryActive => 1.725,    // Высокая активность (6-7 тренировок в неделю)
                ActivityLevel.ExtraActive => 1.9,     // Очень высокая активность (тяжелая физическая работа)
                _ => 1.2 // По умолчанию
            };
        }



    }
}
