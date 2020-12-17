using ClaimsDepartment_Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClaimsDepartment_Console
{
    public class ClaimsDepartmentUI
    {
        private ClaimsDepartmentRepository _claimsDepartmentRepository = new ClaimsDepartmentRepository();
        public void run()
        {
            Menu();
        }
        private void Menu()
        {
            bool keepRunning = true;
            while (keepRunning)
            {
                //DISPLAY OPTIONS 
                Console.WriteLine("Select an option below:\n" +
                    "1. View all claims\n" +
                    "2. Process next claim\n" +
                    "3. Enter new claim\n" +
                    "4. Exit\n");
                //GET USER INPUT 
                string userInput = Console.ReadLine();
                //EVALUATE USER INPUT
                switch (userInput)
                {
                    case "1":
                        //View all claims
                        break;
                    case "2":
                        //Process next claim
                        break;
                    case "3":
                        //Enter new claim
                        EnterNewClaim();
                        break;
                    case "4":
                        Console.WriteLine("You are exiting the application.");
                        keepRunning = false;
                        break;
                    default:
                        Console.WriteLine("Please enter valid number.");
                        break;
                }
                Console.WriteLine("Please Press any key to continue...");
                Console.ReadKey();
                Console.Clear();
            }
        }

        private void ViewAllClaims()
        {
            
        }

        private void ProcessNextClaim()
        {

        }

        private void EnterNewClaim()
        {
            ClaimItems newItem = new ClaimItems();
            //ClaimID
            Console.WriteLine("Enter the ID for the claim:");
            string claimIdAsString = Console.ReadLine();
            newItem.ClaimID = int.Parse(claimIdAsString);
            //ClaimType
            Console.WriteLine("Enter the number that corresponds with the claim type:\n" +
                "1. Car\n" +
                "2. Home\n" +
                "3. Theft");
            string claimTypeAsString = Console.ReadLine();
            int claimTypeAsInt = int.Parse(claimTypeAsString);
            newItem.ClaimType = (TypeOfClaim)claimTypeAsInt;
            //Description
            Console.WriteLine("Enter a breif description of claim:");
            newItem.Description = Console.ReadLine();
            //ClaimAmount
            Console.WriteLine("Enter the amount of the claim:");
            string claimAmountAsString = Console.ReadLine();
            newItem.ClaimAmount = double.Parse(claimAmountAsString);
            //Date of incident
            Console.WriteLine("Enter the date of the incidient (ex. mm/dd/yy):");
            newItem.DateOfIncident = DateTime.Parse(Console.ReadLine());
            //Date of Claim
            Console.WriteLine("Enter the date of the claim (mm/dd/yy):");
            newItem.DateOfClaim = DateTime.Parse(Console.ReadLine());
            //IsValid
            Console.WriteLine("Is this claim valid? (y/n)");
            string isValidString = Console.ReadLine();
            if(isValidString == "y")
            {
                newItem.IsValid = true;
            }
            else
            {
                newItem.IsValid = false;
            }
            _claimsDepartmentRepository.AddClaimToQueue(newItem);
        }

    }
}
