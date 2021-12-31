using _02_Komodo_Claims;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

namespace _02_KomodoClaims.UI
{
    public class ProgramUI
    {
        private ClaimsRepository _repo = new ClaimsRepository();
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
                WriteLine("Welcome to Komodo Claims Department\n" +
                    "1.Take next claim\n" +
                    "2.List all claims\n" +
                    "3.Add claim\n" +
                    "4.Exit");

                string userInput = ReadLine();
                switch(userInput)
                {
                    case "1":
                        TakeClaim();
                        break;
                        case "2":
                        ListAllClaims();
                        break;
                    case "3":
                        AddNewClaim();
                        break;
                    case "4":
                        isRunning = false;
                        break;
                }
            }
        }

        public void TakeClaim()
        {
            Clear();
            WriteLine("Here are the details of the next claim:\n");

            Queue<Claims> newList = _repo.GetList();
            Claims nextClaim = newList.Peek();

            WriteLine(
                $"ID: {nextClaim.ClaimID}\n" +
                $"Type: {nextClaim.TypeOfClaim}\n" +
                $"Description: {nextClaim.Description}\n" +
                $"Amount: ${nextClaim.ClaimAmount}\n" +
                $"Incident Date: {nextClaim.DateOfIncident.ToShortDateString()}\n" +
                $"Claim Date: {nextClaim.DateOfClaim.ToShortDateString()}\n" +
                $"Valid: {nextClaim.IsValid}\n" +
                $"\n" +
                $"Do you want to take this claim? (y/n)");

            string userInput = ReadLine();
            switch (userInput)
            {
                case "y":
                    newList.Dequeue();
                    WriteLine("You have successfully taken the claim\n" +
                        "Press any key to continue...");
                    break;
                case "n":
                    RunMenu();
                    break;
                default:
                    WriteLine("Please enter either y or n");
                    break;
            }
            ReadLine();
        }
        public void ListAllClaims()
        {
            Clear();
            Queue<Claims> claimList = _repo.GetList();

            WriteLine("ClaimID" + 
                "Type" +
                "DateOfAccident" +
                "DateOfClaim" +
                "IsValid" +
                "Amount" +
                "Description\n");
            foreach (Claims content in claimList)
            {
                Console.WriteLine($"{ content.ClaimID} " +
                    $"{content.TypeOfClaim} " +
                    $"{content.DateOfIncident.ToShortDateString()}" +
                    $"{content.DateOfClaim.ToShortDateString()} " +
                    $"{content.IsValid}" +
                    $"${content.ClaimAmount}" +
                    $"{content.Description}\n");
            }

           WriteLine("Press any key to continue...");
            ReadKey();
        }
        public void AddNewClaim()
        {
            Claims content = new Claims();

            Clear();
            WriteLine($"(ID)" +
                "(Type)" +
                "(Description)" +
                "(Damage)" +
                "(Accident Date)" +
                "(Claim Date)" +
                "(Valid)\n");

            WriteLine("Enter the claim ID: ");
            content.ClaimID = int.Parse(ReadLine());

            Clear();
            WriteLine($"({content.ClaimID})" +
                "(Type) " +
                "(Description)" +
                "(Damage)" +
                "(Accident Date)" +
                "(Claim Date)" +
                "(Valid)\n");

            WriteLine("Enter the type of claim:\n" +
                "1. Car\n" +
                "2. Home\n" +
                "3. Theft\n");

            string input = ReadLine();
            switch (input)
            {
                case "1":
                    content.TypeOfClaim = TypeOfClaim.Car;
                    break;
                case "2":
                    content.TypeOfClaim = TypeOfClaim.Home;
                    break;
                case "3":
                    content.TypeOfClaim = TypeOfClaim.Theft;
                    break;
            }

            Clear();
            WriteLine($"({content.ClaimID})" +
                "({content.TypeOfClaim})" +
                "(Description)" +
                "(Damage)" +
                "(Accident Date)" +
                "(Claim Date)" +
                "(Valid)\n");

            WriteLine("Enter a description of the claim ");
            content.Description = ReadLine();

            Clear();
           WriteLine($"({content.ClaimID})" +
               $" ({content.TypeOfClaim})" +
               $" ({content.Description})" +
               $" (Damage)" +
               $" (Accident Date)" +
               $" (Claim Date)" +
               $" (Valid)\n");

           WriteLine("Enter the claim amount:");
            content.ClaimAmount = decimal.Parse(ReadLine());

           Clear();
           WriteLine($"({content.ClaimID})" +
               $" ({content.TypeOfClaim})" +
               $" ({content.Description})" +
               $" (${content.ClaimAmount})" +
               $" (Accident Date)" +
               $" (Claim Date)" +
               $" (Valid)\n");

            WriteLine("Enter the date of the incident: ");
            content.DateOfIncident = DateTime.Parse(ReadLine());

            Clear();
            WriteLine($"({content.ClaimID})" +
                $" ({content.TypeOfClaim})" +
                $" ({content.Description})" +
                $" (${content.ClaimAmount})" +
                $" ({content.DateOfIncident})" +
                $" (Claim Date) " +
                $"(Valid)\n");

            WriteLine("Enter the date of claim: ");
            content.DateOfClaim = DateTime.Parse(ReadLine());

            _repo.IsValid(content);

            
                
                Clear();
            
            WriteLine($"You are about to add the following claim to the queue: \n" +
                $"\n" +
                $"ID: {content.ClaimID}\n" +
                $"Type: {content.TypeOfClaim}\n" +
                $"Description: {content.Description}\n" +
                $"Amount: ${content.ClaimAmount}\n" +
                $"Incident Date: {content.DateOfIncident}\n" +
                $"Claim Date: {content.DateOfClaim}\n" +
                $"Valid: {content.IsValid}\n" +
                $"\n" +
                $"Press any key to confirm the entry...");
            
            ReadKey();

            _repo.AddClaim(content);

            
            Clear();
            
            WriteLine("Claim successfully added to the queue!\n" +
                "Press any key to return to the menu...");
            
            ReadKey();
        }

        public void SeedContent()
        {
            Claims claimOne = new Claims(1,
                TypeOfClaim.Car,
                "Fender Bender",
                1000,
                DateTime.Parse("08/5/2020"),
                DateTime.Parse("08/15/2020"),
                true);
            Claims claimTwo = new Claims(2,
                TypeOfClaim.Home,
                "Broken Window",
                255.99m,
                DateTime.Parse("07/14/2020"),
                DateTime.Parse("08/22/2020"),
                false);
            Claims claimThree = new Claims(3,
                TypeOfClaim.Theft,
                "Iphone stolen from purse",
                1500,
                DateTime.Parse("09/29/2020"),
                DateTime.Parse("10/14/2020"),
                true);

            _repo.AddClaim(claimOne);
            _repo.AddClaim(claimTwo);
            _repo.AddClaim(claimThree);
        }
        

    }
}
