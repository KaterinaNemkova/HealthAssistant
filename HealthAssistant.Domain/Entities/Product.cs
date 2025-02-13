using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthAssistant.Domain.Entities
{// просто класс с каждым продуктом, где рассчитаны кбжу на 100г
    public class Product:Entity
    {
        public string Name { get; set; } = string.Empty;
        public double CaloriesPer100g { get; set; }
        public double ProteinsPer100g { get; set; }
        public double FatsPer100g { get; set; }
        public double CarbsPer100g { get; set; }
        public double FiberPer100g { get; set; }
        public double SugarPer100g { get; set; }
        public List<MealEntryProduct> MealEntries { get; set; } = [];


    }
}
