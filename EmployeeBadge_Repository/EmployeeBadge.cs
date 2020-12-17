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
        public string DoorID { get; set; }

        public EmployeeBadge() { }
        public EmployeeBadge(int badgeID, string doorID)
        {
            BadgeID = badgeID;
            DoorID = doorID;
        }
    }
}
