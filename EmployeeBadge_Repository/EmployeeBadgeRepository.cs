using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeBadge_Repository
{
    class EmployeeBadgeRepository
    {
        public Dictionary<int, EmployeeBadge> _employeeBadgeDictionary = new Dictionary<int, EmployeeBadge>();
        
        //CREATE NEW BADGE
        public void AddNewBadge(int key, EmployeeBadge badge)
        {
            _employeeBadgeDictionary.Add(key,badge);
        }
        //ADD DOOR TO EXISTING BADGE
        public void AddDoorToExistingBadge()
        {
            
        }
        //DELETE DOORS FROM EXISTING BADGE
        public void DeleteDoorFromExistingItem()
        {

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
