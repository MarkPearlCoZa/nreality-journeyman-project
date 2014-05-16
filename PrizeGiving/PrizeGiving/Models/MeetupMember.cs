using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json;

namespace PrizeGiving.Models
{
    public class MeetupMember
    {
        [JsonProperty("member_id")]
        public string Member_Id { get; set; }
        [JsonProperty("name")]
        public string Name { get; set; }
    }
}
