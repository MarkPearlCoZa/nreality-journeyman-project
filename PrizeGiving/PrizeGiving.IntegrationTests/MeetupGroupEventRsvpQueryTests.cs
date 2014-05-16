using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;

namespace PrizeGiving.Models
{
    [TestFixture]
    public class MeetupGroupEventRsvpQueryTests
    {

        [Test]
        public void RsvpsForTheFirstEventShouldNotBeZero()
        {
            const string groupName = "DeveloperUG";
            var groupEventsQuery = new MeetupGroupEventsQuery();
            var groupEventRsvpQuery = new MeetupGroupEventRsvpQuery();
            var events = groupEventsQuery.GetEventsForGroup(groupName);
            var groupEventId = events.First().Id;

            var attendees = groupEventRsvpQuery.GetRsvpYesAttendees(groupEventId);

            Assert.GreaterOrEqual(attendees.Count(), 1);
        }
    }
}