using ChallengeTwoClassLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChallengeTwoConsoleApp
{
    public class ClaimUI
    {
        
        private readonly ClaimDetailsRepo _claimDetailsRepo = new ClaimDetailsRepo();
       
        public void Run()
        {
            SeedClaims();
            RunMenu();
        }
        private void RunMenu()
        {
            bool continueToRun = true;
            while (continueToRun)
            {
                Console.Clear();
                Console.WriteLine("Enter The Number Of the Function you Would Like to Access\n" +
                    "1: See All Claims\n" +
                    "2: Take Care of Next Claim\n" +
                    "3: Enter New Claim\n" +
                    "4: Exit.");
                string userInput = Console.ReadLine();

                switch (userInput)
                {
                    case "1":
                        SeeAllClaims();
                        break;
                    case "2":
                        TakeCareOfNextClaim();
                        break;
                    case "3":
                        EnterNewClaim();

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
        private void SeedClaims()
        {
            ClaimDetails claimOne = new ClaimDetails(1, ClaimDetails.ClaimTypes.Car, "Car accident on 465", 400, DateTime.Parse("04/18/2018"), DateTime.Parse("04/27/2018"));
            ClaimDetails claimeTwo = new ClaimDetails(2, ClaimDetails.ClaimTypes.Home, "House Fire in Kitchen", 4000, DateTime.Parse("04/11/2018"), DateTime.Parse("04/12/2018"));
            ClaimDetails claimThree = new ClaimDetails(3, ClaimDetails.ClaimTypes.Theft, "stolen pancakes", 4, DateTime.Parse("04/27/2018"), DateTime.Parse("06/01/2018"));
            _claimDetailsRepo.EnterNewClaim(claimOne);
            _claimDetailsRepo.EnterNewClaim(claimeTwo);
            _claimDetailsRepo.EnterNewClaim(claimThree);
        }

        private void EnterNewClaim()
        {
            Console.Clear();
            ClaimDetails claim = new ClaimDetails();

            Console.WriteLine("Welcome to the new Claim Creator Page");
            Console.WriteLine("Please enter this new claims ID number");
            string claimID = Console.ReadLine();
            claim.ClaimID = Convert.ToInt32(claimID);

            Console.WriteLine("Select a Claim Type as a number 1-3: 1 = Car, 2 = Home, 3 = Theft");


            string claimType = Console.ReadLine();
            switch (claimType)
            {
                case "1":
                    claim.ClaimType = ClaimDetails.ClaimTypes.Car;
                    break;
                case "2":
                    claim.ClaimType = ClaimDetails.ClaimTypes.Home;
                    break;
                case "3":
                    claim.ClaimType = ClaimDetails.ClaimTypes.Theft;
                    break;

            }
            Console.WriteLine("Can you explain the reason for Your new claim");
            string description = Console.ReadLine();
            claim.Description = Convert.ToString(description);

            Console.WriteLine("Please enter the the cost of the damages. ex: 400.00");
            string claimAmount = Console.ReadLine();
            claim.ClaimAmount = Convert.ToDouble(claimAmount);

            Console.WriteLine("Please enter the date of the incident. ex: mm/dd/yyyy");
            string dateOfIncident = Console.ReadLine();
            claim.DateOfIncident = Convert.ToDateTime(dateOfIncident);

            Console.WriteLine("please enter the date the claim was filed ex: mm/dd/yyyy");
            string dateOfClaim = Console.ReadLine();
            claim.DateOfClaim = Convert.ToDateTime(dateOfClaim);

            _claimDetailsRepo.EnterNewClaim(claim);

        }
      
        private void TakeCareOfNextClaim()
        {
            Queue<ClaimDetails> claimDetails = _claimDetailsRepo.SeeAllClaims();
            ClaimDetails claim = claimDetails.Peek();
            Console.WriteLine($"{claim.ClaimID}" + $"   {claim.ClaimType}" + $"   {claim.Description}" + $"  {claim.ClaimAmount}" + $"    {claim.DateOfIncident}" + $" {claim.DateOfClaim}" + $"    {claim.IsValid}");
            Console.WriteLine("Do you want to deal with this claim now(y/n)?");
            string input = Console.ReadLine();
            switch (input)
            {
                case "n":
                    RunMenu();
                    break;
                case "y":
                    _claimDetailsRepo.TakeCareOfNextClaim();
                    break;
                default:
                    Console.WriteLine("Please enter valid input");
                    Console.ReadKey();
                    TakeCareOfNextClaim();
                    break;
            }
        }

        private void SeeAllClaims()
        {
            Queue<ClaimDetails> allClaims = _claimDetailsRepo.SeeAllClaims();

            Console.WriteLine($"ClaimID,    Claim Type,    Description,     Claim Amount,   Date of Incident,   Date of Claim,  Valid Claim?");
            foreach (ClaimDetails claim in allClaims)
            {
                Console.WriteLine($"{claim.ClaimID}" + $"   {claim.ClaimType}" + $"   {claim.Description}" + $"  {claim.ClaimAmount}" + $"    {claim.DateOfIncident}" + $" {claim.DateOfClaim}" + $"    {claim.IsValid}");
            }
            
            Console.ReadLine();
        
        
        }
    }
}
