using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02_Komodo_Claims
{
    public enum TypeOfClaim
    {
        Car=1,
        Home,
        Theft

    }
    public class Claims
    {
        public Claims() { }

        public Claims(int claimId,
            TypeOfClaim claimType,
            string description,
            decimal claimAmount,
            DateTime dateOfincident,
            DateTime dateOfclaim,
            bool isValid)
        {
            ClaimID = claimId;
            TypeOfClaim = claimType;
            Description = description;
            ClaimAmount = claimAmount;
            DateOfIncident = dateOfincident;
            DateOfClaim = dateOfclaim;
            IsValid = isValid;
        }

        public int ClaimID { get; set; }
        public TypeOfClaim TypeOfClaim { get; set; }
        public string Description { get; set; }
        public decimal ClaimAmount { get; set; }
        public DateTime DateOfIncident { get; set; }
        public DateTime DateOfClaim { get; set; }
        public bool IsValid { get; set; }


    }
}
