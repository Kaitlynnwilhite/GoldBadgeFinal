using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Menu
{
    public class MenuItem
    {
        public MenuItem() 
        { 

        }
        public MenuItem(int mealNumber, string name, string ingredients, string description, double price)
            
        {
            MealNumber = mealNumber;
            Name = name;
            Ingredients = ingredients;
            Description = description;
            Price = price;
        }
        public int MealNumber { get; set; }
        public string Name { get; set; }
        public string Ingredients { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
    }
    
}
