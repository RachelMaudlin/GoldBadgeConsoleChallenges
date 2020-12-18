using EmployeeBadge_Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeBadge_Console
{
    class EmployeeBadgeUI
    {
        private EmployeeBadgeRepository _employeeBadgeRepo = new EmployeeBadgeRepository();
        public void Run()
        {
            LocalDataBase();
            MainMenu();
        }

        //Menu
        private void MainMenu()
        {
            bool keepRunning = true;
            while (keepRunning)
            {
                //Display Options:
                Console.WriteLine("Hello Security Admin, what would you like to do?\n" +
                    "1. Add a badge\n" +
                    "2. Edit a badge\n" +
                    "3. List all badges\n" +
                    "4. Exit\n");
                //Get User Input
                string userInput = Console.ReadLine();
                //Evaluate user input
                switch (userInput)
                {
                    case "1":
                        AddBadge();
                        break;
                    case "2":
                        EditBadge();
                        break;
                    case "3":
                        ListAllBadges();
                        break;
                    case "4":
                        Console.WriteLine("Now exiting application.");
                        keepRunning = false;
                        break;
                    default:
                        Console.WriteLine("Please enter a valid option to continue...");
                        break;
                }
                Console.WriteLine("Press any key to continue.");
                Console.ReadKey();
                Console.Clear();
            }
        }
        //Create Method
        private void AddBadge()
        {
            Console.Clear();
            EmployeeBadge newBadge = new EmployeeBadge();
            //Badge ID
            Console.WriteLine("What is the number on the badge: (ex. 1234)");
            string badgeAsString = Console.ReadLine();
            newBadge.BadgeID = int.Parse(badgeAsString);
            //Door ID
            Console.WriteLine("List a door that it needs access to:");
            newBadge.ListOfDoors.Add(Console.ReadLine());
            Console.WriteLine("Any other doors? (y/n)");
            string userInput = Console.ReadLine().ToLower();
            if(userInput == "y")
            {
                Console.WriteLine("List a door that it needs access to:");
                newBadge.ListOfDoors.Add(Console.ReadLine());
            }
            else
            {
                Console.Clear();
                MainMenu();
            }
        }

        //EDIT METHOD(S)
        private void EditBadge()
        {
            Console.Clear();
            //List all badges
            ListAllBadges();
            //Get badge ID they would like to update 
            Console.WriteLine("\nWhat is the badge number you would like to update?");
            //Evaluate user input 
            int badgeID = int.Parse(Console.ReadLine());
            EmployeeBadge badgeToEdit = _employeeBadgeRepo.GetBadgeByID(badgeID);
            Console.Clear();
            Console.WriteLine($"- Badge ID: {badgeToEdit.BadgeID}\n");
            foreach(var item in badgeToEdit.ListOfDoors)
            {
                Console.WriteLine($"- Door Access: {item}\n");
            }
            Console.WriteLine("Enter number for action you would like to take\n" +
                "1. Add Access to a door\n" +
                "2. Remove access to a door\n");
            string userInputAsString = Console.ReadLine();
            if (userInputAsString == "1")
            {
                Console.WriteLine("Enter the name of the door you would like to add:");
                string doorName = Console.ReadLine();
                _employeeBadgeRepo.AddDoorToExistingBadge(badgeID, doorName);
            }
            if(userInputAsString == "2")
            {
                Console.WriteLine("Enter the name of the door you would like to remove:");
                string doorName = Console.ReadLine();
                _employeeBadgeRepo.RemoveDoorFromExistingItem(badgeID, doorName);
            }
            else
            {
                Console.WriteLine("Please enter a valid option.");
                EditBadge();
            }

        }
        //READ ALL METHOD
        private void ListAllBadges()
        {
            Console.Clear();
            Dictionary<int, EmployeeBadge> badgeDictionary = _employeeBadgeRepo.GetEmployeeDictionary();
            Console.WriteLine("Badge ID:\tDoor Access:");
            foreach(KeyValuePair<int, EmployeeBadge> badge in badgeDictionary)
            {
                Console.Write($"{badge.Value.BadgeID, -17}");
                foreach (var item in badge.Value.ListOfDoors)
                {
                    Console.Write($"{item}");
                }
                Console.WriteLine();    
            }
        }

        //LOCAL DATABASE
        private void LocalDataBase()
        {
            EmployeeBadge itemOne = new EmployeeBadge(12345, new List<string> { "A7" });
            EmployeeBadge itemTwo = new EmployeeBadge(22345, new List<string> { "A1, A4, B1, B2" });
            EmployeeBadge itemThree = new EmployeeBadge(32345, new List<string> { "A4, A5" });
            EmployeeBadge itemFour = new EmployeeBadge(45132, new List<string> { "A2, A3, B4" });
            EmployeeBadge itemFive = new EmployeeBadge(25134, new List<string> { "A6, B3" });
            _employeeBadgeRepo.AddNewBadge(itemOne.BadgeID, itemOne);
            _employeeBadgeRepo.AddNewBadge(itemTwo.BadgeID, itemTwo);
            _employeeBadgeRepo.AddNewBadge(itemThree.BadgeID, itemThree);
            _employeeBadgeRepo.AddNewBadge(itemFour.BadgeID, itemFour);
            _employeeBadgeRepo.AddNewBadge(itemFive.BadgeID, itemFive);
           
        }
    }
}
