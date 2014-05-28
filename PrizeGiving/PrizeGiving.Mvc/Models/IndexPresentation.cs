using PrizeGiving.Models;
using System.Collections.Generic;

namespace PrizeGiving.Mvc.Models
{
    public class IndexPresentation
    {
        public IEnumerable<MeetupEvent> Events { get; set; }
    }
}