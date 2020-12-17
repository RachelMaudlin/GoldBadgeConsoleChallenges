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
        public Queue<ClaimItems> _claimsQueue = new Queue<ClaimItems>();

        public void Run()
        {
            LocalData();
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
                        ViewAllClaims();
                        break;
                    case "2":
                        //Process next claim
                        ProcessNextClaim();
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
            Console.Clear();
            Queue<ClaimItems> claimsQueue = _claimsDepartmentRepository.ReadClaimsQueue();
            foreach(ClaimItems item in claimsQueue)
            {
                Console.WriteLine($"Claim ID: {item.ClaimID}\n" +
                    $"Claim Type: {item.ClaimType}\n" +
                    $"Description: {item.Description}\n" +
                    $"Claim Amount: {item.ClaimAmount}\n" +
                    $"Date of Incident: {item.DateOfIncident}\n" +
                    $"Date of Claim: {item.DateOfClaim}\n" +
                    $"Is this claim valid: {item.IsValid}");
            }
        }

        private void ProcessNextClaim()
        {
            Console.Clear();
            //Get Claim from top of the list using "Take Care of claim method"
            //Display the claim
            ClaimItems nextUpClaim = _claimsDepartmentRepository.TakeCareOfClaim();
            Console.WriteLine($"Claim Type: {nextUpClaim.ClaimType}\n" +
                $"Description: {nextUpClaim.Description}\n" +
                $"Claim Amount: {nextUpClaim.ClaimAmount}" +
                $"Date of Incident: {nextUpClaim.DateOfIncident}\n" +
                $"Date of Claim: {nextUpClaim.DateOfClaim}\n" +
                $"Is this Valid: {nextUpClaim.IsValid}\n");


            //Ask user if they would like to process the claim
            Console.WriteLine("Do you want to process this claim? (y/n)");

            //Remove from top of the list if yes
            string processClaimInput = Console.ReadLine();
            if (processClaimInput == "y")
            {
                _claimsQueue.Dequeue();
                Console.Clear();
                ProcessNextClaim();
            }
            //Return to main menu if no
            else
            {
                Console.Clear();
                Menu();
            }


        }

        private void EnterNewClaim()
        {
            Console.Clear();
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

        private void LocalData()
        {
            ClaimItems itemOne = new ClaimItems(1, TypeOfClaim.Car, "Car accident on 465", 400.00, DateTime.Parse("04/25/20"), DateTime.Parse("04 / 27 / 20"), true);
            ClaimItems itemTwo = new ClaimItems(2, TypeOfClaim.Home, "House fire in kitchen", 4000.00, DateTime.Parse("4/11/20"), DateTime.Parse("04/12/20"), true);
            ClaimItems itemThree = new ClaimItems(3, TypeOfClaim.Theft, "Stolen Pancakes", 4.00, DateTime.Parse("4/27/20"), DateTime.Parse("06/01/20"), false);
            _claimsDepartmentRepository.AddClaimToQueue(itemOne);
            _claimsDepartmentRepository.AddClaimToQueue(itemTwo);
            _claimsDepartmentRepository.AddClaimToQueue(itemThree);
        }

    }
}
