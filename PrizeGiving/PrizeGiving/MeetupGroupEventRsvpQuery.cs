using System;
using System.Collections.Generic;
using System.Linq;
using PrizeGiving.Models;
using PrizeGiving.Services;
using System.Threading.Tasks;

namespace PrizeGiving
{
    public class MeetupGroupEventRsvpQuery : GroupEventRsvpQuery
    {
        public IEnumerable<MeetupMember> GetRsvpYesAttendees(string groupEventId)
        {
            EnsureValidFields(groupEventId);

            const string yesRsvpStatus = "Yes";
            var meetupService = new MeetupService(new Configuration());
            var result = Task.Run(() => meetupService.GetRsvpsByEventIdAndRsvpAnswer(groupEventId, yesRsvpStatus))
                .Result
                .Select(x => x.MeetupMember);

            return result;
        }

        private void EnsureValidFields(string groupEventId)
        {
            if (string.IsNullOrEmpty(groupEventId)) throw new MissingFieldException("group event id cannot be empty");
        }
    }
}