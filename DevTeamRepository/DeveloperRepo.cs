using DevTeam.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevTeamRepository
{
    public class DeveloperRepo
    {
        //field 
        int _count = 0;

        //this is my "pretend" data base
        protected readonly List<Developer> _developerDirectory = new List<Developer>();
        



        //adding developers to the _developerDirectory
        public bool AddContentToDevelopers(Developer content)
        {
            _count++;
            content.PersonalID = _count;
            _developerDirectory.Add(content);


            return true;
        }

        //Read the developers on the _developerDirectory
        public List<Developer> GetDevelopers()
        {
            return _developerDirectory;
        }
        //Read the last name of developers on the _developerDirectory
        public Developer GetDevelopersByID(int developerID)
        {
            foreach (Developer content in _developerDirectory)
            {
                if (content.PersonalID == developerID)
                {
                    return content;
                }
            }
            return null;
        }


        //update devs
        public bool UpdateDeveloper(int oldDeveloperID, Developer newDeveloper)
        {
            Developer oldDeveloper = GetDevelopersByID(oldDeveloperID);
            if (oldDeveloper == null)
            {
                return false;
            }
            else
            {
                oldDeveloper.LastName = newDeveloper.LastName;
                oldDeveloper.HasAccess = newDeveloper.HasAccess;
                return true;
            }
        }


        // removing a developer off of the _developerDirectory
        public bool DeleteExistingDevelopers(int devID)
        {
            foreach (var dev in _developerDirectory)
            {
                if(dev.PersonalID == devID)
                {
                    _developerDirectory.Remove(dev);
                    return true;
                }
            }
            return false;
        }

      
    }
}
