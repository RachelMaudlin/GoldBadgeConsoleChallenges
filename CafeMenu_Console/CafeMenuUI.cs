using CafeMenu_Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CafeMenu_Console
{
    class KomodoUI
    {
        private CafeMenuRepository _cafeMenuRepo = new CafeMenuRepository();
        public void Run()
        {
            LocalDataBase();
            MainMenu();
        }

        //MENU
        private void MainMenu()
        {
            bool keepRunning = true;
            while (keepRunning)
            {

                //DISPLAY OPTIONS
                Console.WriteLine("Select Menu Option:\n" +
                    "1. View All Menu Items\n" +
                    "2. Add New Menu Item\n" +
                    "3. Update Existing Menu Item\n" +
                    "4. Delete Menu Item\n" +
                    "5. Exit");

                //GET USER INPUT
                string userInput = Console.ReadLine();


                //EVALUATE USER INPUT
                switch (userInput)
                {
                    case "1":
                        ViewEntireMenu();
                        break;
                    case "2":
                        AddMenuItem();
                        break;
                    case "3":
                        UpdateMenuItem();
                        break;
                    case "4":
                        DeleteMenuItem();
                        break;
                    case "5":
                        Console.WriteLine("Now Exiting Applciation.");
                        keepRunning = false;
                        break;
                    default:
                        Console.WriteLine("Please enter a valid command.");
                        break;
                }
                Console.WriteLine("Press any key to continue.");
                Console.ReadKey();
                Console.Clear();
            }
        }
        //READ METHOD
        private void ViewEntireMenu()
        {
            Console.Clear();
            List<CafeMenu> listOfItems = _cafeMenuRepo.GetCafeMenu();
            foreach (CafeMenu item in listOfItems)
            {
                Console.WriteLine($"Meal Nnumber: {item.MealNumber}\n" +
                    $"Meal Name: {item.MealName}\n" +
                    $"Meal Description: {item.MealDescription}\n" +
                    $"List of Ingredients: {item.Ingredients}\n" +
                    $"Price: {item.MealPrice}");
            }
        }
        //CREATE METHOD
        private void AddMenuItem()
        {
            Console.Clear();
            CafeMenu newItem = new CafeMenu();

            //MEAL NUMBER
            Console.WriteLine("Enter a number for the meal:");
            string mealNoString = Console.ReadLine();
            newItem.MealNumber = int.Parse(mealNoString);
            //MEAL NAME
            Console.WriteLine("Enter name of the meal:");
            newItem.MealName = Console.ReadLine();
            //DEESCRIPTION
            Console.WriteLine("Enter breif description of meal:");
            newItem.MealDescription = Console.ReadLine();
            //LIST OF INGREDIENTS
            Console.WriteLine("List basic ingredients:");
            newItem.Ingredients = Console.ReadLine();
            //PRICE
            Console.WriteLine("Enter meal price (eg., 2.75, 6.00, ect)");
            string priceString = Console.ReadLine();
            newItem.MealPrice = double.Parse(priceString);

            _cafeMenuRepo.AddItemToMenu(newItem);
        }
        //UPDATE METHOD
        private void UpdateMenuItem()
        {
            //DISPLAY MENU
            ViewEntireMenu();
            //GET ITEM TO UPDATE
            Console.WriteLine("\nEnter the meal number you would like to update:");
            //GET ITEM
            string oldMealAsString = Console.ReadLine();
            int oldMealAsInt = int.Parse(oldMealAsString);
            //BUILD NEW ITEM
            CafeMenu newItem = new CafeMenu();

            //MEAL NUMBER
            Console.WriteLine("\nEnter new number for the meal:");
            string mealNoString = Console.ReadLine();
            newItem.MealNumber = int.Parse(mealNoString);

            //MEAL NAME
            Console.WriteLine("Enter name of the meal:");
            newItem.MealName = Console.ReadLine();
            //DEESCRIPTION
            Console.WriteLine("Enter breif description of meal:");
            newItem.MealDescription = Console.ReadLine();
            //LIST OF INGREDIENTS
            Console.WriteLine("List basic ingredients:");
            newItem.Ingredients = Console.ReadLine();
            //PRICE
            Console.WriteLine("Enter meal price (eg., 2.75, 6.00, ect)");
            string priceString = Console.ReadLine();
            newItem.MealPrice = double.Parse(priceString);
            //VERIFY IT UPDATED
            bool wasUpdated = _cafeMenuRepo.UpdateExistingMenu(oldMealAsInt, newItem);
            if (wasUpdated)
            {
                Console.WriteLine("Menu Item Updated");
            }
            else
            {
                Console.WriteLine("Could Not Update Item");
            }
        }
        //DELETE METHOD
        private void DeleteMenuItem()
        {
            ViewEntireMenu();
            //GET ITEM TO DELETE
            Console.WriteLine("\nEnter meal no. of menu item you would like to remove:");
            string mealNoAsString = Console.ReadLine();
            int mealNoAsInt = int.Parse(mealNoAsString);
            //CALL DELETE METHOD
            bool wasDeleted = _cafeMenuRepo.RemoveItemFromMenu(mealNoAsInt);
            //STATE IF DELETED
            if (wasDeleted)
            {
                Console.WriteLine("Menu Item Deleted");
            }
            //STATE IF NOT DELETED
            else
            {
                Console.WriteLine("Menu Item Could Not Deleted");
            }
        }

        //LOCAL DATABASE
        private void LocalDataBase()
        {
            CafeMenu itemOne = new CafeMenu(1, "Big Joe", "An extra large meal", "Cheese Pizza, Cheese Fries, Mozzarella Sticks, Choice of Drink", 24.99);
            CafeMenu itemTwo = new CafeMenu(2, "Chubby's Choice", "A Large Meal", "Veggie Lasagna, Small Salad, Garlic Bread, Choice of Drink", 19.99);
            CafeMenu itemThree = new CafeMenu(3, "Medium Maudi", "Regular size meal", "Large Salad, Garlic Bread, Choice of Drink", 15.75);
            CafeMenu itemFour = new CafeMenu(4, "Little Kitty", "Small Meal", "Small salad, Cup of Soup, Choice of Drink", 11.75);
            CafeMenu itemFive = new CafeMenu(5, "Skinny's Snack", "Just a snack", "Garlic Knots, Choice of Drink", 6.99);
            CafeMenu itemSix = new CafeMenu(6, "Bix's Buffet", "Endless Food", "Access to the whole buffet and unlimited refills", 25.99);
            _cafeMenuRepo.AddItemToMenu(itemOne);
            _cafeMenuRepo.AddItemToMenu(itemTwo);
            _cafeMenuRepo.AddItemToMenu(itemThree);
            _cafeMenuRepo.AddItemToMenu(itemFour);
            _cafeMenuRepo.AddItemToMenu(itemFive);
            _cafeMenuRepo.AddItemToMenu(itemSix);

        }
    }
}
