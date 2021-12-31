using _01_KomodoCafe.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

namespace _01_KomodoCafe.UI
{
    public class ProgramUI
    {
        private MenuItemRepository _orderRepo = new MenuItemRepository();
        public void Run()
        {
            SeedContent();
            RunMenu();
        }

        private void RunMenu()
        {
            bool continueRunning = true;

            while (continueRunning)
            {
                Clear();
                WriteLine("Welcome to Komodo.\n" +
                    "\n" +
                    "1. List all orders\n" +
                    "2. Add a order\n" +
                    "3. Remove a order\n");

                string userInput = ReadLine();
                switch (userInput)
                {
                    case "1":
                        ListAllOrders();
                        break;
                    case "2":
                        CreateOrder();
                        break;
                    case "3":
                        RemoveOrder();
                        break;
                    default:
                        continueRunning = false;
                        break;
                }
            }
        }
        public void ListAllOrders()
        {
           List<MenuItem> ItemList = _orderRepo.ListOrders(); 

            foreach (MenuItem item in ItemList)
            {
                WriteLine(
                    $"{item.MealNumb} {item.MealName}\n" +
                    $"Description: {item.Description}\n" +
                    $"Ingredients: {item.Ingredients}\n" +
                    $"Price: {item.MealPrice}");
            }

            WriteLine("Press any key to continue...");
            ReadKey();
            ReadLine();
        }
        public void CreateOrder()
        {
            MenuItem item = new MenuItem();

           Clear();
           WriteLine("(MealNumber) (MealName) (Description) (Ingredients) (Price)\n");

           WriteLine("Enter the new item's item number: ");
           item.MealNumb = int.Parse(ReadLine());

            Clear();
            WriteLine($"({item.MealNumb}) (MealName) (Description) (Ingrediants) (Price)\n");

            WriteLine("Enter the item's MealName: ");
            item.MealName = ReadLine();

            Clear();
            WriteLine($"({item.MealNumb}) ({item.MealName}) (Description) (Ingrediants) (Price)\n");

            WriteLine($"Enter a description for {item.MealName}: ");
            item.Description = ReadLine();

            Clear();
            WriteLine($"({item.MealNumb}) ({item.MealName}) ({item.Description}) (Ingrediants) (Price)\n");

            WriteLine($"Enter the ingrediants for {item.MealName}: ");
            item.Ingredients = ReadLine();

            Clear();
            WriteLine($"({item.MealNumb}) ({item.MealName}) ({item.Description}) ({item.Ingredients}) (Price)\n");

            WriteLine($"Enter the price for {item.MealPrice}: ");
            item.Ingredients = ReadLine();

            Clear();

            WriteLine("Order Summary:\n");

            WriteLine($"Item Number: {item.MealNumb}\n" +
                $"MealName: {item.MealName}\n" +
                $"Description: {item.Description}\n" +
                $"Ingrediants: {item.Ingredients}\n" +
                $"Price: {item.MealPrice}");

            WriteLine("Press any key to confirm order");
            ReadKey();

            Clear();
            WriteLine("Order successfully added!\n" +
                "Press any key to continue...");
            ReadKey();

            _orderRepo.AddOrder(item);
        }
        public void RemoveOrder()
        {
            WriteLine("What order needs removed?\n" +
                "Select by number)");
            List<MenuItem> ItemList = _orderRepo.ListOrders();

            foreach(MenuItem order in ItemList)
            {
                WriteLine($"{order.MealNumb} {order.MealName}\n");
            }

            int removeNumber = int.Parse(ReadLine());

            MenuItem item = _orderRepo.GetItemById(removeNumber);

            _orderRepo.RemoveOrder(item);

            WriteLine(
                "Order removed.\n" +
                "Press any key to continue...");
            ReadKey();
        }
        public void SeedContent()
        {
            MenuItem hamBurger = new MenuItem(1, 
                "Hamburger",
                "Classic burger",
                "Toasted Bun, Meat pattie, Lettuce, Tomato, Mayo, Mustard, Ketchup",
                3);

            MenuItem cheeseBurger = new MenuItem(2, 
                "Cheeseburger",
                "Classic cheeseburger",
                "Toasted Bun, Meat pattie, Cheese, Lettuce, Tomato, Mayo, Mustard, Ketchup",
                4);

            MenuItem bbqBurger = new MenuItem(3, 
                "BBQ Burger",
                "Bbq covered Burger",
                "Toasted Bun, Meat pattie, Cheese, Bbq Sauce, Bacon",
                6);

            _orderRepo.AddOrder(hamBurger);
            _orderRepo.AddOrder(cheeseBurger);
            _orderRepo.AddOrder(bbqBurger);
        }
    }
}
