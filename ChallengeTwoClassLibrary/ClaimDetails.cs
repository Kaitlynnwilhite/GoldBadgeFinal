using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;


namespace ChallengeTwoClassLibrary
{
    [TestClass]
    public class ClaimDetails
    { 
        public enum ClaimTypes { Car = 1, Home, Theft };
        
        public ClaimDetails(int claimID, ClaimTypes claimType, string description, double claimAmount, DateTime dateOfIncident, DateTime dateOfClaim)
        {

            ClaimID = claimID;
            ClaimType = claimType;
            Description = description;
            ClaimAmount = claimAmount;
            DateOfIncident = dateOfIncident;
            DateOfClaim = dateOfClaim;
           
        } 
        public ClaimDetails()
        {


        }
        public int ClaimID { get; set; }

        public ClaimTypes ClaimType { get; set; }

        public string Description { get; set; }
        public double ClaimAmount { get; set; }
        public DateTime DateOfIncident { get; set; }
        public DateTime DateOfClaim { get; set; }
        public bool IsValid 
        { 
            get 
            {
                int difference = (DateOfClaim - DateOfIncident).Days;
                if (difference <= 30)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            } 
        }
    }
}
