using Menu;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChallengeOneConsoleApp
{
    public class MenuUI
    {

        private readonly MenuItemRepo _menuItemRepo = new MenuItemRepo();

        public MenuUI()
        {
        }

        public void Run()
        {
            SeedMenuItemList();
            RunMenu();
           
        }


        private void RunMenu()
        {
            bool continueToRun = true;
            while (continueToRun)
            {
                Console.Clear();
                Console.WriteLine("Enter The Number Of the Function you Would Like to Access\n" +
                    "1: Create New Menu Items\n" +
                    "2: Delete Menu Items\n" +
                    "3: View All Menu Items\n" +
                    "4: Exit.");
                string userInput = Console.ReadLine();

                switch (userInput)
                {
                    case "1":
                        AddMenuItemToMenu();
                        break;
                    case "2":
                        DeleteMenuItem();
                        break;
                    case "3":
                        GetMenuItems();
                        
                        break;
                    case "4":
                        continueToRun = false;
                        break;
                    default:
                        Console.WriteLine("Please enter a valid command...\n" +
                            " \n" +
                            "Press any key to continue............");
                        break;

                }

            }

        }

        private void GetMenuItems()
        {
            List<MenuItem> menuItems = _menuItemRepo.GetMenuItems();
            
            foreach (MenuItem item in menuItems)
            {
            Console.WriteLine($"Meal Number: {item.MealNumber}\n" +
                $"Name: {item.Name} \n" +
                $"Ingredents: {item.Ingredients}\n" +
                $"Description: {item.Description}\n" +
                $"Price: {item.Price}");

            }
            Console.ReadLine();
        }
        private void SeedMenuItemList()
        {

            MenuItem salad = new MenuItem(1, "Salad", "Lettuce, Tomato, Cheddar cheese, Bacon bits, Ranch Dressing", "Fresh Garden Greens, with ranch cheese and bacon. A classic Favorite", 2.99);
            MenuItem burger = new MenuItem(2, "Burger", "Ground beef, White Bread bun, Lettuce, Tomato, Onion, Miricale Whip", "Classic American Burger with everything you want and nothing you dont!", 4.99);

            _menuItemRepo.AddMenuItemToMenu(salad);
            _menuItemRepo.AddMenuItemToMenu(burger);
        }

        private void DeleteMenuItem()
        {
            Console.Clear();
            MenuItem item = new MenuItem();

            Console.WriteLine("Welcome to you Menu item Removal Page: Please select the meal number you would like to delete");
            List<MenuItem> itemsList = _menuItemRepo.GetMenuItems();
            int count = 0;
            foreach(MenuItem itemList in itemsList)
            {
                count++;
                Console.WriteLine($"{count}. {item.MealNumber}");
            }
            int targetItemNumber = int.Parse(Console.ReadLine());
            int targetIndex = targetItemNumber - 1;
            if (targetIndex >= 0 && targetIndex < itemsList.Count)
            {
                MenuItem desiredItem = itemsList[targetIndex];
                if (_menuItemRepo.DeleteMenuItem(desiredItem))
                {
                    Console.WriteLine($"{desiredItem.MealNumber} was successfully removed.");
                }
                else
                {
                    Console.WriteLine("I'm sorry I can't to follow through that command.");
                }
            }
            else
            {
                Console.WriteLine("No Item has that MealNumber");
            }
            Console.WriteLine("Press any key to continue.....");
            Console.ReadLine();
        }

        private void AddMenuItemToMenu()
        {
            Console.Clear();
            MenuItem item = new MenuItem();

            Console.WriteLine("Welcome to you Menu item Creator page!");

            Console.WriteLine("Please enter you new items Meal Number ");
            string mealNumberString = Console.ReadLine();
            item.MealNumber = Convert.ToInt32(mealNumberString);

            Console.WriteLine("Please enter the Name of your new item:");
            item.Name = Console.ReadLine();

            Console.WriteLine("Please enter Item Ingredients, and seperate with ','...");
            item.Ingredients = Console.ReadLine();
            
            

            Console.WriteLine("Please enter items description");
            item.Description = Console.ReadLine();

            Console.WriteLine("Please enter the new item price. Example 1.99");
            string priceString = Console.ReadLine();
            item.Price = Convert.ToDouble(priceString);

            _menuItemRepo.AddMenuItemToMenu(item);


        }
    }

}

