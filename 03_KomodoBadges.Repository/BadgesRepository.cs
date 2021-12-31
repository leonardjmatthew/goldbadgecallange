using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03_KomodoBadges.Repository
{
    public class BadgesRepository
    {
        private Dictionary<int, List<string>> _doorAccess = new Dictionary<int, List<string>>();

        public Dictionary<int, List<string>> GetDictonary()
        {
            return _doorAccess;
        }

        //Creates Dictionary of Badges
        public void AddBadge(Badges badge)
        {
            _doorAccess.Add(badge.BadgeID, badge.DoorAccess);
        }

        //Add door to badge
        public void GiveAccess (int badgeid, string doorAccess)
        {
            List<string> doors = _doorAccess[badgeid];
            doors.Add(doorAccess);
        }

        //Remove door from badge
        public void RemoveAccess(int badgeid, string doorAcess)
        {
            List<string> doors = _doorAccess[badgeid];
            doors.Remove(doorAcess);
        }
            
            
    }
}
