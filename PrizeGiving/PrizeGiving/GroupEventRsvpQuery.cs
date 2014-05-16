using System.Collections.Generic;
using PrizeGiving.Models;

namespace PrizeGiving
{
    public interface GroupEventRsvpQuery
    {
        IEnumerable<MeetupRsvp> Execute();
    }
}