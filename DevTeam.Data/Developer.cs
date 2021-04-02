using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevTeam.Data
{

    public class Developer
    {
        //increments personal Id in the Developer Repo 
        public int PersonalID { get; set; }
        public string LastName { get; set; }
        public bool HasAccess { get; set; }

        public Developer() { }
        public Developer(string lastName, bool hasAccess)
        {
            
            LastName = lastName;
            HasAccess = hasAccess;
        }
    }
}
