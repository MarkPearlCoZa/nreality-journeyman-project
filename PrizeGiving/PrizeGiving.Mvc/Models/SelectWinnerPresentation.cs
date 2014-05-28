using PrizeGiving.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PrizeGiving.Mvc.Models
{
    public class SelectWinnerPresentation
    {
        public MeetupMember Winner { get; set; }

        public SelectWinnerPresentation(MeetupMember winner)
        {
            Winner = winner;
        }
    }
}
