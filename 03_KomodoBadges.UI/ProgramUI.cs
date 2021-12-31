using _03_KomodoBadges.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

namespace _03_KomodoBadges.UI
{
    public class ProgramUI
    {
        private BadgesRepository _repo = new BadgesRepository();

        public void Run()
        {
            SeedContent();
            RunMenu();
        }

        public void RunMenu()
        {
            bool isRunning = true;
            while (isRunning)
            {
                Clear();
                WriteLine("Komodo Badge Admin Access\n" +
                    "1.Add badge\n" +
                    "2.Edit badge\n" +
                    "3.List badges\n" +
                    "4.Exit");

                string userInput = ReadLine();

                switch (userInput)
                {
                    case "1":
                        AddAndCreateBadge();
                        break;
                    case "2":
                        EditBadge();
                        break;
                    case "3":
                        ListDoors();
                        break;
                    case "4":
                        isRunning = false;
                        break;
                    default:
                        WriteLine("Enter a valid number");
                        break;
                }
            }
        }

        public void AddAndCreateBadge()
        {
            Badges content = new Badges();
            content.DoorAccess = new List<string>();

            Clear();
            WriteLine("New Badge\n" +
                "\n" +
                "Enter a new badge number:");
            content.BadgeID = int.Parse(ReadLine());

            Clear();
            WriteLine($"New Badge\n" +
                $"Badge ID: {content.BadgeID}\n");
            WriteLine($"Enter door that Badge #{content.BadgeID} needs access to: \n" +
                $"\n");
            content.DoorAccess.Add(ReadLine());

            bool yes = true;

            WriteLine($"Door added to Badge #{content.BadgeID}");

            while(yes)
            {
                WriteLine($"Add another door to Badge #{content.BadgeID} (y/n)");
                string userinput = ReadLine();
                switch(userinput)
                {
                 case "y":
                    WriteLine($"Enter door that Badge #{content.BadgeID} needs access to: ");
                    content.DoorAccess.Add(ReadLine());
                    break;
                 case "n":
                    yes = false;
                    break;
                }
            }

            _repo.AddBadge(content);
            Clear();
            WriteLine($"Badge #{content.BadgeID} has been created\n" +
                $"\n" +
                $"Press any key to continue...");

            ReadKey();


        }

        public void EditBadge()
        {
            Badges content = new Badges();
        content.DoorAccess = new List<string>();

            Clear();
            WriteLine("Enter badge number that need edited: ");
            content.BadgeID = int.Parse(ReadLine());

            Clear();
            WriteLine($"What would you like to do with {content.BadgeID}\n" +
                $"\n" +
                $"1. Add a door\n" +
                $"2. Remove a door\n" +
                $"3. Return to menu\n");

            string userInput = ReadLine();

            switch (userInput)
            {
                case "1":
                    //Add a door
                    AddDoorToEdit(content.BadgeID);
                    break;
                case "2":
                    //Remove a door
                    RemoveDoorFromEdit(content.BadgeID);
                    break;
                case "3":
                    RunMenu();
                    break;
            }
        }


        public void AddDoorToEdit(int badgeid)
        {
            WriteLine("Enter a door to add:");
            string door = ReadLine();
            _repo.GiveAccess(badgeid, door);

            WriteLine("Door access has been added!");
            WriteLine("Press any key to continue...");

            ReadKey();

        }

        public void RemoveDoorFromEdit(int badgeid)
        {
            WriteLine("Enter a door that you would like to remove:");
            string door = ReadLine();
            _repo.RemoveAccess(badgeid, door);

            WriteLine("Door access has been revoked!");
            WriteLine("Press any key to continue...");

            ReadKey();
        }

        public void ListDoors()
        {
            Dictionary<int, List<string>> BadgeList = _repo.GetDictonary();

            WriteLine("=============");
            foreach (KeyValuePair<int, List<string>> badge in BadgeList)
            {
                WriteLine($"Badge: {badge.Key}");

                foreach (string door in badge.Value)
                {
                    WriteLine(door);
                }
                WriteLine("=============");
            }
            WriteLine("\nPress any key to return to the menu...");
            ReadLine();
        }

        public void SeedContent()
        {
            Badges badgeOne = new Badges(22, new List<string> { "Door_3" });
            Badges badgeTwo = new Badges(34, new List<string> { "Door_4", "Door_5" });
            _repo.AddBadge(badgeOne);
            _repo.AddBadge(badgeTwo);
        }

    }
}
