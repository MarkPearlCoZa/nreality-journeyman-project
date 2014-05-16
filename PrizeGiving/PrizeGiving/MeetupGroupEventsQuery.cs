using System.Collections.Generic;
using PrizeGiving.Models;
using PrizeGiving.Services;

namespace PrizeGiving
{
    public class MeetupGroupEventsQuery : GroupEventsQuery
    {
        public MeetupGroupEventsQuery()
        {
        }

        public IEnumerable<MeetupEvent> GetEventsForGroup(string groupName)
        {
            var meetupsService = new MeetupService(new Configuration());
            return meetupsService.GetEventsByGroupName(groupName).Result;
        }
    }
}