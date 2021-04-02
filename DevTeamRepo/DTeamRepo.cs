using DevTeam.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevTeamRepo
{
    public class DTeamRepo
    {

        protected readonly List<Team> _teamDirectory = new List<Team>();
        //repo for the team
        //Adding Devs to the team
        public bool AddDevelopersToTeam(Team developersOnTeam)
        {
            int startingCount = _teamDirectory.Count;
            _teamDirectory.Add(developersOnTeam);

            bool wasAdded = (_teamDirectory.Count > startingCount) ? true : false;
            return wasAdded;
        }
        //getting team by ID

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

        Team GetTeamByName(string teamName)
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
        public bool DeleteExistingTeamByID(Team existingTeamID)
        {
            bool deleteTeamByID = _teamDirectory.Remove(existingTeamID);
            return deleteTeamByID;
        }
    }
}
