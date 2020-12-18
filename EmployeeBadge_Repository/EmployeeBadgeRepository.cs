using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeBadge_Repository
{
    public class EmployeeBadgeRepository
    {
        private Dictionary<int, EmployeeBadge> _employeeBadgeDictionary = new Dictionary<int, EmployeeBadge>();
        
        //CREATE NEW BADGE
        public void AddNewBadge(int key, EmployeeBadge badge)
        {
            _employeeBadgeDictionary.Add(key,badge);
        }

        //ADD DOOR TO EXISTING BADGE
        public bool AddDoorToExistingBadge(int badgeID, string doorNames)
        {
            EmployeeBadge badgeToEdit = GetBadgeByID(badgeID);
            if (badgeToEdit == null)
            {
                return false;
            }
            int initialCount = badgeToEdit.ListOfDoors.Count;
            badgeToEdit.ListOfDoors.Add(doorNames);
            int secondCount = badgeToEdit.ListOfDoors.Count;
            if(initialCount < secondCount)
            {
                return true;
            }
            return false;

        }

        //DELETE DOORS FROM EXISTING BADGE
        public bool RemoveDoorFromExistingItem(int badgeID, string doorNames)
        {
            EmployeeBadge badgeToEdit = GetBadgeByID(badgeID);
            if(badgeToEdit == null)
            {
                return false;
            }
            int initialCount = badgeToEdit.ListOfDoors.Count;
            bool removed = badgeToEdit.ListOfDoors.Remove(doorNames);
            if (removed)
            {
                return true;
            }
            return false;
        }

        //SHOW A LIST OF ALL BADGES
        public Dictionary<int, EmployeeBadge> GetEmployeeDictionary()
        {
            return _employeeBadgeDictionary;
        }


        //Helper 
        public EmployeeBadge GetBadgeByID(int badgeID)
        {
           foreach(KeyValuePair<int, EmployeeBadge> badge in _employeeBadgeDictionary)
            {
                if(badge.Value.BadgeID == badgeID)
                {
                    return badge.Value;
                }
            }
            return null;
        }
    }   

}
