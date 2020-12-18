using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeBadge_Repository
{
   
    public class EmployeeBadge
    {
        public int BadgeID { get; set; }
        public List<string> ListOfDoors { get; set; } = new List<string>();

        public EmployeeBadge() { }
        public EmployeeBadge(int badgeID, List<string> listOfDoors)
        {
            BadgeID = badgeID;
            ListOfDoors = listOfDoors;
        }
    }
}
