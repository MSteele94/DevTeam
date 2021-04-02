using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevTeam.Data
{
    public class Team
    {
            //POCOs always come first, then the repo
        
        public string TeamName { get; set; }
        public int TeamID { get; set; }
        public List<Developer> _developers { get; set; } = new List<Developer>();

        public Team() { }

        public Team(string teamName, int teamID, List<Developer> developers)
        {
            TeamName = teamName;
            TeamID = teamID;
            _developers = developers;
           
            
        }
    }
}
