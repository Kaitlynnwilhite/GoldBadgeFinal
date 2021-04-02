using ChallengeThreeClassLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChallengeThreeConsoleApp
{
    public class BadgeIDUI
    {

        private readonly SecurityRepo _securityRepo = new SecurityRepo();


        public BadgeIDUI()
        {
        }

        public void Run()
        {
            SeedBadgeList();
            RunMenu();

        }

        
        private void RunMenu()
        {
            bool continueToRun = true;
            while (continueToRun)
            {
                Console.Clear();
                Console.WriteLine("Hello Security Admin, What would you like to do?\n" +
                    "1: Add A Badge\n" +
                    "2: Edit A Badge\n" +
                    "3: List All Badges\n" +
                    "4: Exit.");
                string userInput = Console.ReadLine();

                switch (userInput)
                {
                    case "1":
                        AddABadge();
                        break;
                    case "2":
                        EditABadge();
                        break;
                    case "3":
                        ListAllBadges();

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

        private void ListAllBadges()
        {
            Console.Clear();
            Dictionary<int, List<string>> allBadges = _securityRepo.ListAllBadges();
            Console.WriteLine("Badge #,   Door Access");
            foreach (KeyValuePair<int, List<string>> badge in allBadges)
            {
                Console.WriteLine($"{badge.Key}");
                foreach (string door in badge.Value)
                {
                    Console.WriteLine(door);
                }
                
            }
        }

        private void EditABadge()
        {
            Dictionary<int, List<string>> allBadges = _securityRepo.ListAllBadges();
            Console.WriteLine("What is the badge number to update?");
            int badgeNum = int.Parse(Console.ReadLine());
            List<string> doorNames = _securityRepo.GetBadgeByNumber(badgeNum);


            Console.WriteLine($"{badgeNum} has access to \n");
           
            foreach (string door in doorNames)
            {
                Console.WriteLine(door);
            }
            Console.WriteLine( $"What would you like to do?\n" +
                $"1: Remove a Door\n" +
                $"2: Add a Door");
            string input = Console.ReadLine();
            switch (input)
            {
                case "1":
                    RemoveDoor(doorNames);
                    break;
                case "2":
                    AddDoor(doorNames);
                    break;
                default:
                    Console.WriteLine("please enter valid input");
                    Console.ReadKey();
                    EditABadge();
                    break;
            }

        }
        private void AddDoor(List<string> doorNames)
        {
            Console.WriteLine("whitch door Would you like to add" );
            string input = Console.ReadLine();
            doorNames.Add(input);
        }
        private void RemoveDoor(List<string> doorNames)
        {
            Console.WriteLine("which Door would you like to remove?");
            string input = Console.ReadLine();
            doorNames.Remove(input);
            
        }

        private void AddABadge()
        {
            Console.Clear();
            Badge badge = new Badge();

            Console.WriteLine("what is the number on the badge?");
            string badgeID = Console.ReadLine();
            badge.BadgeID = Convert.ToInt32(badgeID);
            

            List<string> doorNames = new List<string>();
            bool hadDoor = true;
            while (hadDoor)
            {
                Console.WriteLine("List a door that it needs access to");
                string input = Console.ReadLine();
                badge.DoorAccess.Add(input);
                Console.WriteLine("Any other doors(y/n)?");
                string inputTwo = Console.ReadLine();
                if (inputTwo == "n")
                {
                    hadDoor = false;
                }
                else if (inputTwo == "y")
                {
                    Console.WriteLine("List a door that it needs access to");
                    string inputThree = Console.ReadLine();
                    badge.DoorAccess.Add(inputThree);
                }
                else
                {
                    Console.WriteLine("please enter valid response");
                    Console.ReadKey();
                }
            }
            _securityRepo.AddABadge(badge);
        }
        private void SeedBadgeList()
        {
            Badge one = new Badge(12345, new List<string> {"A7"});
            Badge two = new Badge(22345, new List<string> { "A1", "A4", "B1", "B2" } );
            Badge three = new Badge(32345, new List<string> { "A4", "A5" });
            _securityRepo.AddABadge(one);
            _securityRepo.AddABadge(two);
            _securityRepo.AddABadge(three);

        }
    }
}
