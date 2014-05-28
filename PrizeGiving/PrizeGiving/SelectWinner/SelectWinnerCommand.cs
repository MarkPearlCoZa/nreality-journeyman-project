using PrizeGiving.Domain.SelectWinner;
using PrizeGiving.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrizeGiving.Domain.Commands
{
    public class SelectWinnerCommand
    {
        private GroupEventRsvpQuery _meetupGroupEventRsvpQuery;
        private Randomizer _randomizer;

        public SelectWinnerCommand(GroupEventRsvpQuery meetupGroupEventRsvpQuery, Randomizer randomizer)
        {
            _meetupGroupEventRsvpQuery = meetupGroupEventRsvpQuery;
            _randomizer = randomizer;
        }

        public MeetupMember SelectWinnerForEvent(string groupEventId)
        {
            var rsvpAttendees = _meetupGroupEventRsvpQuery.GetRsvpYesAttendees(groupEventId).ToList();

            var randomNumber = _randomizer.GetRandomNumber(rsvpAttendees.Count);

            return rsvpAttendees[randomNumber];
        }
    }
}
