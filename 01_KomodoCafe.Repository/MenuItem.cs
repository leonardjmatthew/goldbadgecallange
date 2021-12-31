using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01_KomodoCafe.Repository
{
    public class MenuItem
    {
        public MenuItem() { }

        public MenuItem(
            int mealid, 
            string mealName, 
            string description, 
            string ingredients, 
            int mealprice)
        {
            MealNumb = mealid;
            MealName = mealName;
            Description = description;
            Ingredients = ingredients;
            MealPrice = mealprice;

        }
        public int MealNumb { get; set; }
        public string MealName { get; set;}
        public string Description { get; set;}
        public string Ingredients { get; set;}
        public int MealPrice { get; set;}


    }
}
