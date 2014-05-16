using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json;

namespace PrizeGiving.Models
{
    public class MeetupRsvp
    {
        public string Response { get; set; }
        [JsonProperty("member")]
        public MeetupMember MeetupMember { get; set; }
    }
}
