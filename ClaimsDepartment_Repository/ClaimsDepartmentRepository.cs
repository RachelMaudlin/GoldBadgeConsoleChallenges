using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClaimsDepartment_Repository
{
    public class ClaimsDepartmentRepository
    {
       public Queue<ClaimItems> _ClaimsQueue = new Queue<ClaimItems>();

        //VIEW ALL CLAIMS
        public Queue<ClaimItems> ReadClaimsQueue()
        {
            return _ClaimsQueue;
        }
        //TAKING CARE OF CLAIM 
        public void TakeCareOfClaim()
        {
            _ClaimsQueue.First();
        }
        //CREATE CLAIM
        public void AddClaimToQueue(ClaimItems claim)
        {
            _ClaimsQueue.Enqueue(claim);
        }
        
        
    }
}
