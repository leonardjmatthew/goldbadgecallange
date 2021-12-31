using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02_Komodo_Claims
{
    public class ClaimsRepository
    {
        private Queue<Claims> _claims = new Queue<Claims>();

        //Returns List
        public Queue<Claims> GetList()
        {
            return _claims;
        }

        //Add Claim
        public void AddClaim(Claims newClaim)
        {
            _claims.Enqueue(newClaim);
        }

        //Remove Claim
        public void RemoveClaim()
        {
            _claims.Dequeue();
        }

        //Is with in 30 days
        public void IsValid (Claims claim)
        {
            if(claim.DateOfClaim < claim.DateOfIncident)
                claim.DateOfClaim = claim.DateOfIncident;

            TimeSpan difference = claim.DateOfClaim - claim.DateOfIncident;

            if(difference.Days <= 30)
            {
                claim.IsValid = true;
            }
            else
                claim.IsValid = false;
        }

    }
}
