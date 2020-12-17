using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClaimsDepartment_Repository
{
        public enum TypeOfClaim
        {
           Car = 1,
           Home = 2,
           Theft = 3
        }

    public class ClaimItems
    {
        public int ClaimID { get; set; }
        public TypeOfClaim ClaimType { get; set; }
        public string Description { get; set; }
        public double ClaimAmount { get; set; }
        public DateTime DateOfIncident { get; set; }
        public DateTime DateOfClaim { get; set; } 
        public bool IsValid { get; set; }

        public ClaimItems() { }
        public ClaimItems(int claimID, TypeOfClaim claimType, string description, double claimAmount, DateTime dateOfIncident, DateTime dateOfClaim, bool isValid)
        {
            ClaimID = claimID;
            ClaimType = claimType;
            Description = description;
            ClaimAmount = claimAmount;
            DateOfIncident = dateOfIncident;
            DateOfClaim = dateOfClaim;
            IsValid = isValid;
        }
    }
}
