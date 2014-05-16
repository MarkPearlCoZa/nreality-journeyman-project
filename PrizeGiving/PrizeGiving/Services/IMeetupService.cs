using PrizeGiving.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrizeGiving.Services
{
    public interface IMeetupService
    {
        Task<List<MeetupEvent>> GetEventsByGroupNameAndTime(string groupName, string time);
        Task<List<MeetupEvent>> GetEventsByGroupName(string groupName);
        Task<List<MeetupRsvp>> GetRsvpsByEventIdAndRsvpAnswer(string eventId, string answer);
    }
}
