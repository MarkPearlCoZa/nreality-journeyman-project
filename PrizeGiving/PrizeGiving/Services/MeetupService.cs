using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using PrizeGiving.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace PrizeGiving.Services
{
    public class MeetupService : IMeetupService
    {
        HttpClient _client = new HttpClient() { BaseAddress = new Uri("https://api.meetup.com/2/") };
        private IConfiguration _configuration;

        public MeetupService(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task<List<MeetupEvent>> GetEventsByGroupNameAndTime(string groupName, string time)
        {
            string queryStringValues = String.Format("group_urlname={0}&time={1}", groupName, time);
            return await GetAsync<List<MeetupEvent>>("events", queryStringValues);
        }

        public async Task<List<MeetupEvent>> GetEventsByGroupName(string groupName)
        {
            string queryStringValues = String.Format("group_urlname={0}", groupName);
            return await GetAsync<List<MeetupEvent>>("events", queryStringValues);
        }

        public async Task<List<MeetupRsvp>> GetRsvpsByEventIdAndRsvpAnswer(string eventId, string rsvpStatus)
        {
            string queryStringValues = String.Format("event_id={0}&rsvp={1}", eventId, rsvpStatus);
            return await GetAsync<List<MeetupRsvp>>("rsvps", queryStringValues);
        }

        private async Task<T> GetAsync<T>(string methodName, string queryStringSearchFields)
        {
            string url = String.Format("{0}?sign=true&key={1}&{2}", methodName, _configuration.ApiKey, queryStringSearchFields);
            var eventsResponse = await _client.GetAsync(url);
            string jsonResponse = await eventsResponse.Content.ReadAsStringAsync();

            var meetups = (JObject)JsonConvert.DeserializeObject(jsonResponse);

            var value = meetups.GetValue("results");
            return JsonConvert.DeserializeObject<T>(value.ToString());

        }

    }
}
