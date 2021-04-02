using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChallengeThreeClassLibrary
{
    public class SecurityRepo
    {
        protected readonly Dictionary<int, List<string>> _badgeDictionary = new Dictionary<int, List<string>>();
        public bool AddABadge(Badge newBadge)
        {
            int badgeCount = _badgeDictionary.Count;
            _badgeDictionary.Add(newBadge.BadgeID, newBadge.DoorAccess);
            bool wasAdded = (_badgeDictionary.Count > badgeCount) ? true : false;
            return wasAdded;

        }
       public bool EditABadge(Badge oldBadge, List<string> newDoors)
       {
           
            oldBadge.DoorAccess = newDoors;
            if(oldBadge.DoorAccess != newDoors)
            {
                return false;
            }
            else
            {
                return true;
            }
       }
       public  Dictionary<int, List<string>> ListAllBadges()
       {
            return _badgeDictionary;
       }
        public List<string> GetBadgeByNumber(int badgeNum)
        {
            Dictionary<int, List<string>> allBadges = ListAllBadges();
            allBadges.TryGetValue(badgeNum, out List<string> doorNames);
            return doorNames;
        }
        
    }
}
