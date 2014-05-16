using System;
using System.Collections.Generic;
using PrizeGiving.Models;

namespace PrizeGiving
{
    public interface GroupEventsQuery
    {
        IEnumerable<MeetupEvent> GetEventsForGroup(string groupName);
    }
}