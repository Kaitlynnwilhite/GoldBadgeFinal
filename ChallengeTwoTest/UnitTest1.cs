using ChallengeTwoClassLibrary;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ChallengeTwoTest
{
    [TestClass]
    public class UnitTest1
    {
        
        [TestMethod]
        public void SeeAllClaims()
        {
            ClaimDetails claim = new ClaimDetails();
            ClaimDetailsRepo repo = new ClaimDetailsRepo();
            repo.EnterNewClaim(claim);
            Queue<ClaimDetails> claims = repo.SeeAllClaims();

            bool claimsOnFile = claims.Contains(claim);
            Assert.IsTrue(claimsOnFile);

        }
        [TestMethod]
        public void EnterNewClaim()
        {
            ClaimDetails claim = new ClaimDetails();
            ClaimDetailsRepo repo = new ClaimDetailsRepo();
            bool addClaim = repo.EnterNewClaim(claim);
            Assert.IsTrue(addClaim);
        }
        [TestMethod]
        public void TakeCareOfNextClaim()
            
        {
            ClaimDetails claim = new ClaimDetails();
            ClaimDetailsRepo repo = new ClaimDetailsRepo();
            bool claimsOnFile = repo.EnterNewClaim(claim);
            Assert.IsTrue(claimsOnFile);
            Queue<ClaimDetails> listOfClaims = repo.SeeAllClaims();
            bool hasClaims = listOfClaims.Contains(claim);
            if (hasClaims)
            {
                repo.TakeCareOfNextClaim();
                Assert.IsTrue(claimsOnFile);
            }
        }
    }
}
