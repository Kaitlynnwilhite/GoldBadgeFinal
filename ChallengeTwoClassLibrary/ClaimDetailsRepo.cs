using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChallengeTwoClassLibrary
{
    public class ClaimDetailsRepo
    {
        protected readonly Queue<ClaimDetails> _claimDetails = new Queue<ClaimDetails>();
        
        
        public Queue<ClaimDetails> SeeAllClaims()
        {
            return _claimDetails;
        }
        public void TakeCareOfNextClaim()
        {
            _claimDetails.Dequeue();
        }
        public bool EnterNewClaim(ClaimDetails claim)
        {
            int claimCount = _claimDetails.Count;
            _claimDetails.Enqueue(claim);
            bool wasAdded = (_claimDetails.Count > claimCount) ? true : false;
            return wasAdded;
        }




    }
}
