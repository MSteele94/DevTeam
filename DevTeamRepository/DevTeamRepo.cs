using DevTeam.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevTeamRepository
{
    public class DevTeamRepo
    {
        //protected readonly List<Developer> developers = new List<Developer>();
        protected readonly List<Team> _teamDirectory = new List<Team>() { };
        int _count = 2;
        //repo for the team
        //Adding Devs to the team
        public bool AddDevelopersToTeam(Team developersOnTeam)
        {
            int startingCount = _teamDirectory.Count;
            _teamDirectory.Add(developersOnTeam);

            bool wasAdded = (_teamDirectory.Count > startingCount) ? true : false;
            return true;
        }
        //getting team by ID
        public bool CreateTeams(Team newTeam)
        {
            _count++;
            newTeam.TeamID = _count;
            _teamDirectory.Add(newTeam);
            

            return true;
        }


        public List<Team> GetTeams()
        {
            return _teamDirectory;
        }
        public Team GetTeamByID(int teamID)
        {
            foreach (Team content in _teamDirectory)
            {
                if (content.TeamID == teamID)
                {
                    return content;
                }
            }
            return null;
        }

        //Getting team by name

        public Team GetTeamByName(string teamName)
        {
            foreach (Team content in _teamDirectory)
                if (content.TeamName == teamName)
                {
                    return content;

                }
            return null;
        }

        //updating team by name I think?? not sure if this is correct
        public bool UpdateTeamByName(string oldTeamName, Team newTeamName)
        {
            Team oldTeam = GetTeamByName(oldTeamName);
            if (oldTeamName == null)
            {
                return false;
            }
            else
            {
                oldTeam.TeamName = newTeamName.TeamName;
                return true;
            }
        }

        //delete a team by ID
        public bool DeleteExistingTeamByID(int existingTeamID)
        {
           foreach (var team in _teamDirectory)
            {
                if (team.TeamID == existingTeamID) 
                {
                    _teamDirectory.Remove(team);
                    return true;
                }
            }
            return false;
        }
    }
}

