using DevTeam.Data;
using DevTeamRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevTeams_UI
{
    public class Program_UI
    {
        //same thing but ref devteam repo and new up
        private   DeveloperRepo _developerRepo  = new DeveloperRepo();
        private  DevTeamRepo _teamDirectory = new DevTeamRepo();
        public void Run()
        {
            //seed is at the bottom of the page and holds our existing developers

            
            Seed();


            //reference DeveloperRepo first, one extra step over the streaming content UI we did in class
            //then reference the team repo

           
            RunMenu();
        }


        private void RunMenu()
        {
            //method to run the console and display our Options to choose from. 
            bool continueToRun = true;
            while (continueToRun)
            {

                Console.WriteLine("Welcome to Komodo Dev Teams\n" +
                                  "1. Enlist a Developer\n" +
                                  "2. View All Developers\n" +
                                  "3. View Developer by ID\n" +
                                  "4. Update Existing Developer\n" +
                                  "5. Delete Existing Developer\n" +
                                  "6. View All Teams\n" +
                                  "7. Create New Teams\n" +
                                  "8. View Teams by ID number\n" +
                                  "9. Delete Teams by ID number\n" +
                                  "25. Close Application");

                string userInput = Console.ReadLine();

                switch (userInput)
                {
                    case "1":
                        AddDeveloper();
                        break;
                    case "2":
                        ViewAllDevelopers();
                        break;
                    case "3":
                        ViewDeveloperByID();
                        break;
                    case "4":
                        UpdateExistingDeveloper();
                        break;
                    case "5":
                        DeleteExistingDeveloper();
                        break;
                    case "6":
                        ViewAllTeams();
                        break;
                    case "7":
                        CreateNewTeams();
                        break;
                    case "8":
                        ViewTeamByID();
                        break;
                    case "9":
                        DeleteTeamsByID();
                        break;
                    case "25":
                        continueToRun = false;
                        Console.WriteLine("Thankyou , Press any key to continue");
                        Console.ReadKey();
                        break;
                        
                    default:
                        break;
                }

                  Console.Clear();


            }
        }


        private void DeleteExistingDeveloper()
        {
            Console.Clear();
            Console.WriteLine("Who would you like to Delete?");
            GiveMeDeveloperData();
            string userInputDevID = Console.ReadLine();
            int value = int.Parse(userInputDevID);

            bool removeDeveloper = _developerRepo.DeleteExistingDevelopers(value);
            if (removeDeveloper)
            {
                Console.WriteLine("Developer has been removed.");
            }
            else
            {
                Console.WriteLine("Developer failed to be removed.");
            }

            Console.WriteLine(removeDeveloper); 
        }
        private void DeleteTeamsByID()
        {
            Console.Clear();
            Console.WriteLine("Please enter the ID of the team you would like to delete");
            GiveMeTeamData();
            string userInputTeamID = Console.ReadLine();
            int teamID = int.Parse(userInputTeamID);

            bool removeTeam = _teamDirectory.DeleteExistingTeamByID(teamID);
            if (removeTeam)
            {
                Console.WriteLine("Team was deleted");
            }
            else 
            {
                Console.WriteLine("Failed to remove the team! Please try again!");
            }
            Console.WriteLine(removeTeam);
        }
        private void CreateNewTeams()
        {
            Console.Clear();

            Team newTeam = new Team();

            Console.WriteLine("Please input Team Name: ");
            string userInputTeamName = Console.ReadLine();
            Console.ReadKey();
            Console.WriteLine("Team ID will be auto assigned in numerical order dependant on the ID of the other teams.");
            Console.ReadKey();
            newTeam.TeamName = userInputTeamName;

            Console.WriteLine("Please pick a developer to add to your new team!");
            //this shows the devs but wont take input to let me chose. View Dev Method needs work
            ViewAllDevelopers();
            // need help displaying my List of Devs not on a team to be chosen from

            bool enlistedAllDevelopers = false;
            while (!enlistedAllDevelopers)
            {
                Console.WriteLine("Do you want anyone on your team? (y/n)");
                string userInputED = Console.ReadLine().ToLower();

                if (userInputED == "y")
                {
                    Console.WriteLine("Input Developer ID: ");
                    int devID = int.Parse(Console.ReadLine());
                    Developer developer = _developerRepo.GetDevelopersByID(devID);
                    if (developer != null)
                    {
                        newTeam._developers.Add(developer);
                    }
                    else
                    {
                        Console.WriteLine("Invalid Selection!");
                    }
                }
                else
                {
                    enlistedAllDevelopers = true;
                }
            }


            Console.WriteLine("");

           
            bool isSuccessful = _teamDirectory.CreateTeams(newTeam);
            if (isSuccessful)
            {
                Console.WriteLine("Team was successfully created!");

            }
            else
            {
                Console.WriteLine("Team creation failed");
            }

            Console.ReadKey();
        }
        //Adding a developer, it does not save after the console closes
        private void AddDeveloper()
        {
            Console.Clear();


            //creates new list "developer" inside the Developer list
            Developer developer = new Developer();
            //Asks the user to input the new Developers last name 
            Console.WriteLine("Please input Developer last name: ");
            string userInputDevLastName = Console.ReadLine();
            //calls on the Last Name property from the Developer Class
            developer.LastName = userInputDevLastName;

            //Asks if thr new developer will have plural sight access
            Console.WriteLine("Does the Dev have access to PluralSight? (y/n)");

            //use a Console.Readline.ToLower b/c we can't trust users to input a lowercase "y" or "n"
            string userInputHasPluralSight = Console.ReadLine().ToLower();

            //if else statement that calls in HasAccess property from the DevRepo to determine if the dev has Pluralsight access
            if (userInputHasPluralSight == "y")
            {
                developer.HasAccess = true;
            }
            else
            {
                developer.HasAccess = false;
            }
                                                                    //passes into "content" in the DevRepo.
            bool isSuccessful = _developerRepo.AddContentToDevelopers(developer);
            if (isSuccessful)
            {
                Console.WriteLine("Developer was successfully created");

            }
            else
            {
                Console.WriteLine("Developer creation failed");
            }

            Console.ReadKey();
        }
        



        private void ViewAllTeams()
        {
            Console.Clear();

            List<Team> teams = _teamDirectory.GetTeams();

            foreach(Team team in teams)
            {
                DisplayTeams(team);
            }
            Console.ReadKey();
        }
            
        //Views the Developers,, calls on the DisplayDeveloperDetails method. 
        private void ViewAllDevelopers()
        {
            Console.Clear();
            //all developers are in the _developerRepo variable from the Repository
            GiveMeDeveloperData();
            Console.ReadKey();
        }
        //extra helper method
        private void GiveMeTeamData()
        {
            List<Team> teams = _teamDirectory.GetTeams();

            foreach (Team developers in teams)
            {
                DisplayTeams(developers);
            }
        }
        private void GiveMeDeveloperData()
        {
            List<Developer> developers = _developerRepo.GetDevelopers();

            foreach (Developer dev in developers)
            {
                DisplayDeveloperDetails(dev);
                
            }
            //readkey goes at the bottom of this method
          // Console.ReadKey();
        }

        public void ViewTeamByID()
        {
            Console.Clear();
            Console.WriteLine("Please input the teams ID: ");
            int userInputTeamID = int.Parse(Console.ReadLine());

            Team selectedTeam = _teamDirectory.GetTeamByID(userInputTeamID);
            if (selectedTeam == null)
            {
                Console.WriteLine("Sorry that team doesn't exist");
            }
            else
            {
                DisplayTeams(selectedTeam);
            }
            Console.ReadKey();
        }

        //Lets you view the developers by inputing the ID, Must know their ID as the console doesn't display options to choose from
        //Calls on the GetDevelopersByID method in the Developer Repo, and uses DisplayDeveloperDetails method to show the devs
        private void ViewDeveloperByID()
        {
            Console.Clear();

            Console.WriteLine("Please input DeveloperID: ");
            int userInputDevID = int.Parse(Console.ReadLine());

            Developer selectedDeveloper = _developerRepo.GetDevelopersByID(userInputDevID);

            if (selectedDeveloper == null)
            {
                Console.WriteLine("Sorry the Developer does not exist");
            }
            else
            {
                DisplayDeveloperDetails(selectedDeveloper);
            }


            Console.ReadKey();
        }

        //Updating Existing Developers
        private void UpdateExistingDeveloper()
        {
            Console.Clear();
            //asks the user who they want to update
            Console.WriteLine("Which Developer would you like to Update?");
           

            //this will display the details of the Developers to give the user a list of active developers to update. 
            List<Developer> updateDevelopers = _developerRepo.GetDevelopers();
            foreach (Developer dev in updateDevelopers)
            {
                DisplayDeveloperDetails(dev);
            }

            //asks the user for the ID of the Developer they would like to update. 
            Console.WriteLine("Please input DeveloperID to select: ");
            int userInputOldDevID = int.Parse(Console.ReadLine());
            Developer newDeveloper = new Developer();

           
            //asks the user for the new last name of the developer
            Console.WriteLine("Please input Developer last name: ");
            string userInputDevLastName = Console.ReadLine();
            newDeveloper.LastName = userInputDevLastName;

            
            //asks the user if the developer has access to PluralSight
            Console.WriteLine("Does the Dev have access to PluralSight? (y/n)");
            string userInputHasPluralSight = Console.ReadLine().ToLower();
            if (userInputHasPluralSight == "y")
            {
                newDeveloper.HasAccess = true;
            }
            else
            {
                newDeveloper.HasAccess = false;
            }
            //calls on the UpdateDeveloper method from the DevRepo, which uses the GetDevelopersByID method
            bool isSucessful = _developerRepo.UpdateDeveloper(userInputOldDevID, newDeveloper);


            if (isSucessful == false)
            {
                Console.WriteLine("Sorry that developer does not exist");
            }
            else
            {
                Console.WriteLine("User Update was sucessful");
            }

            //ignore this for now. 
           // var userInputDeveloperUpdate = Console.ReadLine();
        }

        //Displays the details of the Developers in the Seed, and devs added or updates while the console is open.
       //those don't save though
        //helper method
        private void DisplayTeams(Team team)
        {
            Console.WriteLine($"Team Name: {team.TeamName} \n" +
                $"Team ID: {team.TeamID} \n");
               
            
            foreach (Developer dev in team._developers)
            {
                if (team._developers != null)
                {
                DisplayDeveloperDetails(dev);
                }
                else
                {
                    Console.WriteLine("No Developers");
                }
            }
        }
        private void DisplayDeveloperDetails(Developer dev)
        {
            Console.WriteLine($"DeveloperID: {dev.PersonalID} \n" +
                                 $"Developer Last Name: {dev.LastName}\n" +
                                 $"Developer has PluralSight Access: {dev.HasAccess}\n");
        }

        //
        /*private void DisplayDeveloperDetails(int userInputDevID)
        {
        }
        */

       



        //Seed that adds these existing Developers into the _developerRepo Developer list. Calls on the AddContentToDevelopers
        //method to add the 4 developers. ID will be auto assigned by order, so A =1, and so on. so Developer E would be #5
        private void Seed()
        {
            Developer A = new Developer  ("Jones",  DeveloperType.Age, true );
            Developer B = new Developer  ("Wilson", true );
            Developer C = new Developer  ("Folger", true );
            Developer D = new Developer  ("Johnson", true );
            Developer E = new Developer ("Miller", false);
            Developer F = new Developer ("Malcom", true);

            _developerRepo.AddContentToDevelopers(A);
            _developerRepo.AddContentToDevelopers(B);
            _developerRepo.AddContentToDevelopers(C);
            _developerRepo.AddContentToDevelopers(D);
            _developerRepo.AddContentToDevelopers(E);
            _developerRepo.AddContentToDevelopers(F);

            List<Developer> alphaTeamDevs = new List<Developer>() {A,E,F};
            List<Developer> bravoTeamDevs = new List<Developer>() {B,C,D};


            Team teamOne = new Team("Alpha", 1, alphaTeamDevs);
            Team teamTwo = new Team("Bravo", 2, bravoTeamDevs);
            //_teamDirectory.CreateTeams(teamOne);
            //_teamDirectory.CreateTeams(teamTwo);

            _teamDirectory.AddDevelopersToTeam(teamOne);
            _teamDirectory.AddDevelopersToTeam(teamTwo);
        }
    }

}

    //t key and t value
    //    Dictionary<int, Developer> devDict = new Dictionary<int, Developer>()
    //{
    //    new Developer
    //    {
    //        LastName = Barnes
    //    }
    //};

    ////longhand
    //devDict.Add ( 1, new Developer {LastName = "John" , isNaughty = false;)