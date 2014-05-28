using System;
using System.Collections.Generic;
using PrizeGiving.Models;
using PrizeGiving.Services;
using System.Threading.Tasks;

namespace PrizeGiving
{
    public class MeetupGroupEventsQuery : GroupEventsQuery
    {
        private readonly MeetupService _meetupsService;

        public MeetupGroupEventsQuery()
        {
            _meetupsService = new MeetupService(new Configuration());
        }

        public IEnumerable<MeetupEvent> GetEventsForGroup(string groupName)
        {
            EnsureValidParameters(groupName);
            var res = Task.Run(() => _meetupsService.GetEventsByGroupName(groupName)).Result;
            return res;
        }

        private static void EnsureValidParameters(string groupName)
        {
            if (String.IsNullOrEmpty(groupName)) throw new MissingFieldException("group name cannot be blank");
        }
    }
}