using ChallengeThreeClassLibrary;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace ChallengeThreeTest
{
    [TestClass]
    public class BadgeRepoTest
    {
        private readonly SecurityRepo _securityRepo = new SecurityRepo();
        
        private void SeedBadgeList()
        {
            Badge one = new Badge(12345, new List<string> { "A7" });
            Badge two = new Badge(22345, new List<string> { "A1", "A4", "B1", "B2" });
            Badge three = new Badge(32345, new List<string> { "A4", "A5" });
            _securityRepo.AddABadge(one);
            _securityRepo.AddABadge(two);
            _securityRepo.AddABadge(three);

        }
        [TestMethod]
        public void AddABadge()
        {
            Badge newBadge = new Badge();
            SecurityRepo repo = new SecurityRepo();
            bool wasAdded = repo.AddABadge(newBadge);
            Assert.IsTrue(wasAdded);
        }
        [TestMethod]
        public void EditABadge()
        {
            List<string> doors = new List<string> { "A1" };
            Badge two = new Badge(22345, new List<string> { "A1", "A4", "B1", "B2" });
            SecurityRepo repo = new SecurityRepo();
            bool wasUpdated = repo.EditABadge(two, doors);
            Assert.IsTrue(wasUpdated);


        }
        [TestMethod]
        public void ListAllBadges()
        {
       
           
            Badge one = new Badge(12345, new List<string> { "A7" });
            Badge two = new Badge(22345, new List<string> { "A1", "A4", "B1", "B2" });
            Badge three = new Badge(32345, new List<string> { "A4", "A5" });
            _securityRepo.AddABadge(one);
            _securityRepo.AddABadge(two);
            _securityRepo.AddABadge(three);
           
            Dictionary<int, List<string>> actual = _securityRepo.ListAllBadges();
            bool success = actual.ContainsKey(12345);
            Assert.IsTrue(success);
           

        }
    }
}
