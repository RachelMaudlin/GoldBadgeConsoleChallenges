using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CafeMenu_Repository
{
    public class CafeMenu
    {
        public int MealNumber { get; set; }
        public string MealName { get; set; }
        public string MealDescription { get; set; }
        public string Ingredients { get; set; }
        public double MealPrice { get; set; }

        public CafeMenu() { }
        public CafeMenu(int mealNumber, string mealName, string mealDescription, string ingredients, double mealPrice)
        {
            MealNumber = mealNumber;
            MealName = mealName;
            MealDescription = mealDescription;
            Ingredients = ingredients;
            MealPrice = mealPrice;
        }
    }
}
